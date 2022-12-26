// using System.Collections.Generic;
//
// namespace ET
// {
//     [FriendClass(typeof (RoomInfosComponent))]
//     [FriendClassAttribute(typeof (ET.RoomInfo))]
//     public static class RoomInfosComponentSystem
//     {
//         public static List<RoomInfoProto> GetRoomInfoProtoss(this RoomInfosComponent self)
//         {
//             List<RoomInfoProto> infoProtos = new List<RoomInfoProto>();
//             foreach (var VARIABLE in self.RoomInfos)
//             {
//                 infoProtos.Add(VARIABLE.Value.ToMessage());
//             }
//
//             return infoProtos;
//         }
//
//         public static RoomInfo AddRoom(this RoomInfosComponent self, string name)
//         {
//             RoomInfo roomInfo = self.AddChild<RoomInfo>();
//             roomInfo.RoomType = RoomType.FreeStyleGomoku;
//             roomInfo.MaxNum = 2;
//             roomInfo.Name = $"{name} 的房间";
//
//             self.RoomInfos.Add(roomInfo.Id, roomInfo);
//             return roomInfo;
//         }
//
//         public static RoomInfo Get(this RoomInfosComponent self, long roomId)
//         {
//             self.RoomInfos.TryGetValue(roomId, out RoomInfo roomInfo);
//             return roomInfo;
//         }
//     }
//
//     [FriendClassAttribute(typeof (ET.RoomInfo))]
//     [ObjectSystem]
//     public class RoomInfosComponentAwakeSystem: AwakeSystem<RoomInfosComponent>
//     {
//         public override void Awake(RoomInfosComponent self)
//         {
//             RoomInfo roomInfo = self.AddRoom("官方测试");
//         }
//     }
// }