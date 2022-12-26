// namespace ET
// {
//     [FriendClass(typeof(RankInfo))]
//     public static class RankInfoSystem
//     {
//         public static void FromMessage(this RankInfo self, RankInfoProto proto)
//         {
//             self.Id = proto.Id;
//             self.Count = proto.Count;
//             self.Name = proto.Name;
//             self.UnitId = proto.UnitId;
//         }
//
//         public static RankInfoProto ToMessage(this RankInfo self)
//         {
//             RankInfoProto proto = new RankInfoProto();
//             proto.Id = self.Id;
//             proto.UnitId = self.UnitId;
//             proto.Name = self.Name;
//             proto.Count = self.Count;
//             return proto;
//         }
//     }
// }