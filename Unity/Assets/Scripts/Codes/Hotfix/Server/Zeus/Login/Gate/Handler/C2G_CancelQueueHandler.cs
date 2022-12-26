using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Gate)]
    [FriendOfAttribute(typeof (ET.Server.GateUser))]
    [FriendOfAttribute(typeof (ET.Server.AccountZoneDB))]
    public class C2G_CancelQueueHandler: AMRpcHandler<C2G_CancelQueue, G2C_CancelQueue>
    {
        protected override async ETTask Run(Session session, C2G_CancelQueue request, G2C_CancelQueue response, Action reply)
        {
            var (result, accountZoneDb) = session.CheckAccountZoneDB();
            if (result != ErrorCode.ERR_Success)
            {
                response.Error = result;
                reply();
                return;
            }

            GateUser gateUser = accountZoneDb.GetParent<GateUser>();
            long instanceId = gateUser.InstanceId;
            using (await gateUser.GetGateUserLock())
            {
                if (instanceId != gateUser.InstanceId)
                {
                    response.Error = ErrorCode.ERR_Login_NoneAccountZone;
                    reply();
                    return;
                }

                if (gateUser.State == GateUserState.InMap)
                {
                    response.Error = ErrorCode.ERR_Login_RoleInMap;
                    reply();
                    return;
                }

                gateUser.RemoveComponent<GateQueueComponent>();
                MessageHelper.SendActor(session.DomainZone(), SceneType.Queue,
                    new G2Queue_Disconnect() { UnitId = accountZoneDb.LastRoleId, IsProtect = false });
            }

            reply();

            await ETTask.CompletedTask;
        }
    }
}