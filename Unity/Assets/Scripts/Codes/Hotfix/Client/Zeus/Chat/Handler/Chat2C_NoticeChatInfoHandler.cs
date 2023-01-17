namespace ET
{
    [FriendOf(typeof (ET.ChatInfo))]
    [MessageHandler(SceneType.Client)]
    public class Chat2C_NoticeChatInfoHandler: AMHandler<Chat2C_NoticeChatInfo>
    {
        protected override async ETTask Run(Session session, Chat2C_NoticeChatInfo message)
        {
            ChatInfo chatInfo = session.DomainScene().GetComponent<ChatComponent>().AddChild<ChatInfo>(true);
            chatInfo.UnitId = message.UnitId;
            chatInfo.Name = message.Name;
            chatInfo.Message = message.ChatMessage;
            session.DomainScene().GetComponent<ChatComponent>().Add(chatInfo);
            EventSystem.Instance.Publish(session.ClientScene(), new EventType.UpdateChatInfo() { });
            await ETTask.CompletedTask;
        }
    }
}