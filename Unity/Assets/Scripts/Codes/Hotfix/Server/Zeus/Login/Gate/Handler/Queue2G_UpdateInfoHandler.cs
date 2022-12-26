namespace ET.Server
{
    [ActorMessageHandler(SceneType.Gate)]
    [FriendOfAttribute(typeof (ET.Server.GateUser))]
    [FriendOfAttribute(typeof (ET.Server.GateQueueComponent))]
    public class Queue2G_UpdateInfoHandler: AMActorHandler<Scene, Queue2G_UpdateInfo>
    {
        protected override async ETTask Run(Scene scene, Queue2G_UpdateInfo message)
        {
            if (message.Account.Count != message.Index.Count)
            {
                return;
            }

            G2C_UpdateInfo g2CUpdateInfo = new G2C_UpdateInfo() { Count = message.Count };
            GateUserMgrComponent gateUserMgrComponent = scene.GetComponent<GateUserMgrComponent>();
            for (int i = 0; i < message.Account.Count; i++)
            {
                string account = message.Account[i];
                GateUser gateUser = gateUserMgrComponent.Get(account);
                if (gateUser == null || gateUser.State != GateUserState.InQueue)
                    continue;
                GateQueueComponent gateQueueComponent = gateUser.GetComponent<GateQueueComponent>();
                gateQueueComponent.Index = message.Index[i];
                gateQueueComponent.Count = message.Count;

                g2CUpdateInfo.Index = message.Index[i];

                gateUser.Session.Send(g2CUpdateInfo);
                
                if ((i + 1) % 5 == 0)
                {
                    await TimerComponent.Instance.WaitFrameAsync();
                }
            }

            await ETTask.CompletedTask;
        }
    }
}