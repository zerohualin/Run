// using System.Collections.Generic;
//
// namespace ET
// {
//     [FriendClassAttribute(typeof(ET.RoomComponent))]
//     public static class RoomComponentSystem
//     {
//         public static RoomInfo GetRoomInfoByIndex(this RoomComponent self, int index)
//         {
//             return self.RoomInfos[index];
//         }
//
//         public static RoomUnitProto GetRoomUnitProto(this RoomComponent self, int index)
//         {
//             if (index > self.RoomUnitList.Count - 1)
//             {
//                 return null;
//             }
//             return self.RoomUnitList[index];
//         }
//         
//         public static RoomUnitProto GetMyUnitProto(this RoomComponent self)
//         {
//             long myId = self.DomainScene().GetComponent<PlayerComponent>().MyId;
//             for (int i = 0; i < self.RoomUnitList.Count; i++)
//             {
//                 if (self.RoomUnitList[i].Id == myId)
//                     return self.RoomUnitList[i];
//             }
//             return null;
//         }
//
//         public static void SetMyRoom(this RoomComponent self, long roomId)
//         {
//             foreach (var roomInfo in self.RoomInfos)
//             {
//                 if (roomInfo.Id == roomId)
//                     self.MyRoomInfo = roomInfo;
//             }
//         }
//
//         public static void SetRoomList(this RoomComponent self, List<RoomInfoProto> protos)
//         {
//             self.RoomInfos.Clear();
//             self.Children.Clear();
//             
//             for (int i = 0; i < protos.Count; i++)
//             {
//                 var roomInfo = self.AddChild<RoomInfo>();
//                 roomInfo.FromMessage(protos[i]);
//                 self.RoomInfos.Add(roomInfo);
//             }
//         }
//     }
// }