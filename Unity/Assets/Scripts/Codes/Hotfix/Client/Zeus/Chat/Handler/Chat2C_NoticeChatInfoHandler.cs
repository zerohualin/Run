// namespace ET
// {
//     [FriendClassAttribute(typeof(ET.ChatInfo))]
//     public class Chat2C_NoticeChatInfoHandler : AMHandler<Chat2C_NoticeChatInfo>
//     {
//         protected override void Run(Session session, Chat2C_NoticeChatInfo message)
//         {
//             ChatInfo chatInfo = session.DomainScene().GetComponent<ChatComponent>().AddChild<ChatInfo>(true);
//             chatInfo.UnitId = message.UnitId;
//             chatInfo.Name = message.Name;
//             chatInfo.Message = message.ChatMessage;
//             session.DomainScene().GetComponent<ChatComponent>().Add(chatInfo);
//             Game.EventSystem.Publish(new EventType.UpdateChatInfo() { ZoneScene = session.ZoneScene() });
//         }
//     }
// }