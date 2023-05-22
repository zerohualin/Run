using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Gate)]
    [FriendOfAttribute(typeof (ET.Server.AccountZoneDB))]
    [FriendOfAttribute(typeof (ET.Server.RoleInfoDB))]
    [FriendOfAttribute(typeof (ET.Server.GateUser))]
    [FriendOfAttribute(typeof (ET.Server.GateQueueComponent))]
    public class C2G_Enter2MapHandler: AMRpcHandler<C2G_Enter2Map, G2C_Enter2Map>
    {
        protected override async ETTask Run(Session session, C2G_Enter2Map request, G2C_Enter2Map response)
        {
            var (result, accountZoneDB) = session.CheckAccountZoneDB();
            if (result != ErrorCode.ERR_Success)
            {
                response.Error = result;
                return;
            }

            long instanceId = accountZoneDB.InstanceId;
            long unitId = request.UnitId;
            string account = accountZoneDB.Account;

            GateUser gateUser = accountZoneDB.GetParent<GateUser>();
            using (await gateUser.GetGateUserLock())
            {
                if (instanceId != accountZoneDB.InstanceId)
                {
                    response.Error = ErrorCode.ERR_Login_NoneAccountZone;
                    return;
                }

                if (gateUser.GetComponent<MultiLoginComponent>() != null)
                {
                    if (accountZoneDB.LastRoleId != unitId)
                    {
                        await gateUser.Offline(false);
                    }

                    //等上面下线后再移除顶号状态，防止这时候刚好排队服到了上一个号
                    gateUser.RemoveComponent<MultiLoginComponent>();
                    if (gateUser.State == GateUserState.InQueue)
                    {
                        GateQueueComponent gateQueueComponent = gateUser.GetComponent<GateQueueComponent>();
                        response.InQueue = true;
                        response.Index = gateQueueComponent.Index;
                        response.Count = gateQueueComponent.Count;
                        return;
                    }

                    if (gateUser.State == GateUserState.InMap)
                    {
                        gateUser.EnterMap().Coroutine();
                        return;
                    }
                }

                RoleInfoDB targetRoleInfo = accountZoneDB.GetChild<RoleInfoDB>(unitId);
                if (targetRoleInfo == null || targetRoleInfo.IsDeleted)
                {
                    response.Error = ErrorCode.ERR_Login_NoRoleDB;
                    return;
                }

                //正常的选角流程
                accountZoneDB.LastRoleId = unitId;
                //询问排队服务器要不要排队

                Queue2G_Enqueue queue2G_Enqueue = (Queue2G_Enqueue)await MessageHelper.CallActor(accountZoneDB.LoginZoneId,
                    new G2Queue_Enqueue() { Account = account, UnitId = unitId, GateActorId = session.DomainScene().InstanceId });
                if (queue2G_Enqueue.Error != ErrorCode.ERR_Success)
                {
                    response.Error = queue2G_Enqueue.Error;
                    return;
                }

                response.InQueue = queue2G_Enqueue.NeedQueue;
                if (queue2G_Enqueue.NeedQueue)
                {
                    gateUser.State = GateUserState.InQueue;
                    GateQueueComponent GateQueueComponent = gateUser.GetComponent<GateQueueComponent>();
                    if (GateQueueComponent == null)
                    {
                        GateQueueComponent = gateUser.AddComponent<GateQueueComponent>();
                    }

                    GateQueueComponent.UnitId = unitId;
                    GateQueueComponent.Count = queue2G_Enqueue.Count;
                    GateQueueComponent.Index = queue2G_Enqueue.Index;

                    response.Index = queue2G_Enqueue.Index;
                    response.Count = queue2G_Enqueue.Count;
                    Log.Console($"-> 账号{account} 需要排队 {response.Count} / {response.Count}");
                }
                
                DBComponent db = session.GetDirectDB();
                await db.Save(accountZoneDB);

                if (!queue2G_Enqueue.NeedQueue)
                {
                    Log.Console($"-> 账号{account} 免排队直接进游戏");
                    //角色直接进游戏
                    gateUser.EnterMap().Coroutine();
                }
            }

            await ETTask.CompletedTask;
        }
    }
}