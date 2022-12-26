// namespace ET
// {
//     [FriendClass(typeof(RoomUnitsComponent))]
//     public static class RoomUnitsComponentSystem
//     {
//         public static RoomUnit Get(this RoomUnitsComponent self, long id)
//         {
//             self.RoomUnitDict.TryGetValue(id, out RoomUnit roomUnit);
//             return roomUnit;
//         }
//
//         public static void Add(this RoomUnitsComponent self, RoomUnit roomUnit)
//         {
//             if (self.RoomUnitDict.ContainsKey(roomUnit.Id))
//             {
//                 Log.Error($"room unit is exits! {roomUnit.Id}");
//                 return;
//             }
//             self.RoomUnitDict.Add(roomUnit.Id, roomUnit);
//         }
//
//         public static void Remove(this RoomUnitsComponent self, long id)
//         {
//             if (self.RoomUnitDict.TryGetValue(id, out RoomUnit roomUnit))
//             {
//                 self.RoomUnitDict.Remove(id);
//                 roomUnit?.Dispose();
//             }
//         }
//     }
// }