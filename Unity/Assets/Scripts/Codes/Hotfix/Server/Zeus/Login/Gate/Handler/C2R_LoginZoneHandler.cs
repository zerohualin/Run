using System;
using System.Diagnostics;

namespace ET.Server
{
    [MessageHandler(SceneType.Realm)]
    [FriendOfAttribute(typeof (ET.Server.AccountDB))]
    [FriendOfAttribute(typeof (ET.Server.RealmAccountComponent))]
    public class C2R_LoginZoneHandler: AMRpcHandler<C2R_LoginZone, R2C_LoginZone>
    {
        protected override async ETTask Run(Session session, C2R_LoginZone request, R2C_LoginZone response, Action reply)
        {
            RealmAccountComponent realmAccountComponent = session.GetComponent<RealmAccountComponent>();
            if (realmAccountComponent == null)
            {
                response.Error = ErrorCode.ERR_Login_AccountNotLogin;
                reply();
                return;
            }

            if (!StartZoneConfigCategory.Instance.Contain(request.ZoneId))
            {
                response.Error = ErrorCode.ERR_Login_ZoneNotExist;
                reply();
                return;
            }

            string account = realmAccountComponent.AccountDB.Account;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginZone, account.GetLongHashCode()))
            {
                var startSceneConfig = SceneHelper2.GetGateConfig(request.ZoneId, account);

                var g2R_GetGateKey = (G2R_GetGateKey)await MessageHelper.CallActor(startSceneConfig.InstanceId,
                    new R2G_GetGateKey() { Info = new LoginGateInfo() { Account = account, LogicZone = request.ZoneId } });

                if (g2R_GetGateKey.Error != ErrorCode.ERR_Success)
                {
                    response.Error = g2R_GetGateKey.Error;
                    reply();
                    return;
                }

                response.GateAddress = startSceneConfig.InnerIPOutPort.ToString();
                response.GateKey = g2R_GetGateKey.GateKey;
                
                reply();
                response.Error = ErrorCode.ERR_Success;
                session?.Disconnect().Coroutine();
            }
        }
    }
}