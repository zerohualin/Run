using System;

namespace ET.Server
{
    [ActorMessageHandler(SceneType.Gate)]
    [FriendOfAttribute(typeof (ET.Server.AccountDB))]
    [FriendOfAttribute(typeof (ET.Server.RealmAccountComponent))]
    [FriendOfAttribute(typeof (ET.Server.GateUserMgrComponent))]
    public class R2G_GetGateKeyHandler : AMActorRpcHandler<Scene, R2G_GetGateKey, G2R_GetGateKey>
    {
        protected override async ETTask Run(Scene scene, R2G_GetGateKey request, G2R_GetGateKey response)
        {
            GateUserMgrComponent gateUserMgrComponent = scene.GetComponent<GateUserMgrComponent>();
            gateUserMgrComponent.Users.TryGetValue(request.Info.Account, out GateUser gateUser);

            if (gateUser != null)
            {
                //TODO 执行下线顶号逻辑
                long instanceId = gateUser.InstanceId;
                using (await gateUser.GetGateUserLock())
                {
                    if (instanceId != gateUser.InstanceId)
                    {
                        return;
                    }
                    gateUser.OfflineSession();
                }
            }

            GateSessionKeyComponent gateSessionKeyComponent = scene.GetComponent<GateSessionKeyComponent>();
            long Key = RandomGenerator.RandInt64();

            gateSessionKeyComponent.Add(Key, request.Info);
            response.GateKey = Key;
            
            await ETTask.CompletedTask;
        }
    }
}