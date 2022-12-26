namespace ET.Server
{
    [ActorMessageHandler(SceneType.Queue)]
    public class G2Queue_DisconnectHander: AMActorHandler<Scene, G2Queue_Disconnect>
    {
        protected override async ETTask Run(Scene scene, G2Queue_Disconnect message)
        {
            QueueMgrComponent queueMgrComponent = scene.GetComponent<QueueMgrComponent>();
            queueMgrComponent.Disconnect(message.UnitId, message.IsProtect);
            await ETTask.CompletedTask;
        }
    }
}