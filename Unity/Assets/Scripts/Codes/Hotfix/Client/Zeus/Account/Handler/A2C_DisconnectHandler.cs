using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Client)]
    public class A2C_DisconnectHandler: AMHandler<A2C_Disconnect>
    {
        protected override async ETTask Run(Session session, A2C_Disconnect message)
        {
            EventSystem.Instance.Publish(session.DomainScene(), new NetDisconnect()
            {
                Code = message.Error
            });
            await ETTask.CompletedTask;
        }
    }
}