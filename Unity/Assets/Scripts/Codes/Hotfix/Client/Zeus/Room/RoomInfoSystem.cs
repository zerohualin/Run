// using System.Collections.Generic;
//
// namespace ET
// {
//     [FriendClass(typeof (RoomInfo))]
//     public static class RoomInfoSystem
//     {
//         public static void FromMessage(this RoomInfo self, RoomInfoProto proto)
//         {
//             self.Id = proto.Id;
//             self.CurrentNum = proto.CurrentNum;
//             self.Name = proto.Name;
//             self.MaxNum = proto.MaxNum;
//         }
//
//         public static RoomInfoProto ToMessage(this RoomInfo self)
//         {
//             RoomInfoProto proto = new RoomInfoProto();
//             self.CurrentNum = self.RoomUnitStateDict.Count;
//             proto.Id = self.Id;
//             proto.CurrentNum = self.CurrentNum;
//             proto.Name = self.Name;
//             proto.MaxNum = self.MaxNum;
//             return proto;
//         }
//
//         public static List<RoomUnitProto> GetRoomUnitProtos(this RoomInfo self)
//         {
//             List<RoomUnitProto> infoProtos = new List<RoomUnitProto>();
//             foreach (var VARIABLE in self.RoomUnitStateDict)
//             {
//                 RoomUnitProto roomUnitProto = new RoomUnitProto();
//                 roomUnitProto.Id = VARIABLE.Key;
//                 roomUnitProto.ReadyState = VARIABLE.Value;
//                 infoProtos.Add(roomUnitProto);
//             }
//             return infoProtos;
//         }
//         
//         public static void Join(this RoomInfo self, long roomUnitId)
//         {
//             self.RoomUnitStateDict[roomUnitId] = 0;
//         }
//
//         public static void Level(this RoomInfo self, long roomUnitId)
//         {
//             self.RoomUnitStateDict.Remove(roomUnitId);
//         }
//
//         public static void ChangeUnitReadyState(this RoomInfo self, long roomUnitId)
//         {
//             int state = self.RoomUnitStateDict[roomUnitId];
//             if (state == 0)
//             {
//                 self.RoomUnitStateDict[roomUnitId] = 1;
//             }
//             else
//             {
//                 self.RoomUnitStateDict[roomUnitId] = 0;
//             }
//         }
//     }
// }