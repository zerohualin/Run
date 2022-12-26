// using System.Collections.Generic;
//
// namespace ET
// {
//     [FriendClassAttribute(typeof(ET.RoomInfo))]
//     public static class RoomHelper
//     {
//         public static void BoardcastRoomInfo(this RoomInfo roomInfo)
//         {
//             RoomUnitsComponent roomUnitsComponent = roomInfo.DomainScene().GetComponent<RoomUnitsComponent>();
//             List<RoomUnitProto> RoomUnitProtoList = new List<RoomUnitProto>();
//             List<long> ActorList = new List<long>();
//             
//             foreach (var V in roomInfo.RoomUnitStateDict)
//             {
//                 RoomUnit unit = roomUnitsComponent.Get(V.Key);
//                 ActorList.Add(unit.GateSessionActorId);
//                 RoomUnitProto proto = new RoomUnitProto();
//                 proto.Id = unit.Id;
//                 proto.ReadyState = V.Value;
//                 RoomUnitProtoList.Add(proto);
//             }
//
//             for (int i = 0; i < ActorList.Count; i++)
//             {
//                 MessageHelper.SendActor(ActorList[i], new Room2C_NoticeRoomInfo() { RoomUnitProtoList = RoomUnitProtoList});
//             }
//         }
//     }
// }