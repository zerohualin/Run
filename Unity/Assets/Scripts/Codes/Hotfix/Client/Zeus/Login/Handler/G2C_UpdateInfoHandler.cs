using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Client)]
    public class G2C_UpdateInfoHandler: AMHandler<G2C_UpdateInfo>
    {
        protected override async ETTask Run(Session session, G2C_UpdateInfo message)
        {
            EventSystem.Instance.Publish(session.DomainScene(), new UpdateQueueInfo() { Index = message.Index, Count = message.Count });
            await ETTask.CompletedTask;
        }
    }
}