using System;
using ET.Client;

namespace ET.Server
{
    [ActorMessageHandler(SceneType.Gate)]
    [FriendOfAttribute(typeof (ET.Server.GateUser))]
    public class Queue2G_EnterMapHandler: AMActorRpcHandler<Scene, Queue2G_EnterMap, G2Queue_EnterMap>
    {
        protected override async ETTask Run(Scene scene, Queue2G_EnterMap request, G2Queue_EnterMap response)
        {
            using (await GateUserSystem.GetGateUserLock(request.Account))
            {
                GateUser gateUser = scene.GetComponent<GateUserMgrComponent>().Get(request.Account);
                Log.Console($"-> 账号{request.Account} 排队完了");
                if (gateUser == null
                    || gateUser.GetComponent<MultiLoginComponent>() != null
                    || gateUser.State == GateUserState.InGate)
                {
                    response.NeedRemove = true;
                    return;
                }

                if (gateUser.State == GateUserState.InMap)
                {
                    return;
                }
                
                gateUser.EnterMap().Coroutine();
            }

            await ETTask.CompletedTask;
        }
    }
}