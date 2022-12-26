using System;
using System.Collections.Generic;
using ET.Client;

namespace ET.Server
{
    [MessageHandler(SceneType.Gate)]
    [FriendOfAttribute(typeof (ET.Server.GateUser))]
    [FriendOfAttribute(typeof (ET.Server.AccountZoneDB))]
    [FriendOfAttribute(typeof (ET.Server.RoleInfoDB))]
    public class C2G_Login2GateHandler: AMRpcHandler<C2G_Login2Gate, G2C_Login2Gate>
    {
        protected override async ETTask Run(Session session, C2G_Login2Gate request, G2C_Login2Gate response, Action reply)
        {
            session.RemoveComponent<SessionAcceptTimeoutComponent>();
            Scene scene = session.DomainScene();
            //判断是否又LoginGateInfo
            GateSessionKeyComponent gateSessionKeyComponent = scene.GetComponent<GateSessionKeyComponent>();
            LoginGateInfo loginGateInfo = gateSessionKeyComponent.Get(request.GateKey);
            if (loginGateInfo == null)
            {
                response.Error = ErrorCode.ERR_Login_NoLoginGateInfo;
                reply();
                return;
            }

            string account = loginGateInfo.Account;
            //判断停服 账号黑名单

            long sessionInstanceId = session.InstanceId;

            using (await GateUserSystem.GetGateUserLock(account))
            {
                if (sessionInstanceId != session.InstanceId)
                    return;

                GateUserMgrComponent gateUserMgrComponent = scene.GetComponent<GateUserMgrComponent>();
                GateUser gateUser = gateUserMgrComponent.Get(account);
                if (gateUser == null)
                {
                    DBComponent db = scene.GetDirectDB();
                    List<AccountZoneDB> list = await db.Query<AccountZoneDB>(d => d.Account == account);
                    if (list.Count == 0)
                    {
                        gateUser = gateUserMgrComponent.Create(account, loginGateInfo.LogicZone);
                    }
                    else
                    {
                        gateUser = gateUserMgrComponent.Create(list[0]);
                    }

                    long id = gateUser.GetComponent<AccountZoneDB>().Id;

                    List<RoleInfoDB> listRole = await db.Query<RoleInfoDB>(d => d.AccountZoneId == id && !d.IsDeleted);
                    if (listRole.Count > 0)
                    {
                        foreach (RoleInfoDB roleInfoDB in listRole)
                        {
                            gateUser.GetComponent<AccountZoneDB>().AddChild(roleInfoDB);
                        }
                    }
                }
                else
                {
                    gateUser.RemoveComponent<GateUserDisconnectComponent>();
                    gateUser.RemoveComponent<MultiLoginComponent>();
                }

                //链接到新的Session
                gateUser.SessionInstanceId = session.InstanceId;
                session.AddComponent<SessionUserComponent, long>(gateUser.InstanceId);

                if (gateUser.State != GateUserState.InGate)
                {
                    gateUser.AddComponent<MultiLoginComponent>();
                }

                reply();
            }

            await ETTask.CompletedTask;
        }
    }
}