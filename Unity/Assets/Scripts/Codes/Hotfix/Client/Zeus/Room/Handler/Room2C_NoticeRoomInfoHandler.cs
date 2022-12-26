// namespace ET
// {
//     [FriendClassAttribute(typeof(ET.ChatInfo))]
//     [FriendClassAttribute(typeof(ET.RoomComponent))]
//     public class Room2C_NoticeRoomInfoHandler : AMHandler<Room2C_NoticeRoomInfo>
//     {
//         protected override void Run(Session session, Room2C_NoticeRoomInfo message)
//         {
//             session.DomainScene().GetComponent<RoomComponent>().RoomUnitList = message.RoomUnitProtoList;
//             Game.EventSystem.Publish(new EventType.UpdateMyRoomInfo() { ZoneScene = session.ZoneScene() });
//         }
//     }
// }