// namespace ET
// {
//     [FriendClass(typeof (RankInfosComponent))]
//     [FriendClass(typeof (RankInfo))]
//     public static class RankInfosComponentSystem
//     {
//         public static async ETTask LoadRankInfo(this RankInfosComponent self)
//         {
//             var ranInfoList = await DBManagerComponent.Instance.GetZoneDB(self.DomainZone())
//                     .Query<RankInfo>(d => true, collection: "RankInfosComponent");
//             foreach (RankInfo rankInfo in ranInfoList)
//             {
//                 self.AddChild(rankInfo);
//                 self.RankInfosDisctionary.Add(rankInfo.UnitId, rankInfo);
//                 self.SortedRankInfoList.Add(rankInfo, rankInfo.UnitId);
//             }
//         }
//
//         public static void AddOrUpdate(this RankInfosComponent self, RankInfo newRankInfo)
//         {
//             if (self.RankInfosDisctionary.ContainsKey(newRankInfo.UnitId))
//             {
//                 RankInfo oldRankInfo = self.RankInfosDisctionary[newRankInfo.UnitId];
//                 if (oldRankInfo.Count == newRankInfo.Count)
//                     return;
//
//                 DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Remove<RankInfo>(oldRankInfo.UnitId, oldRankInfo.Id, "RankInfosComponent")
//                         .Coroutine();
//
//                 self.RankInfosDisctionary.Remove(oldRankInfo.UnitId);
//                 self.SortedRankInfoList.Remove(oldRankInfo);
//             }
//
//             self.AddChild(newRankInfo);
//             self.RankInfosDisctionary.Add(newRankInfo.UnitId, newRankInfo);
//             self.SortedRankInfoList.Add(newRankInfo, newRankInfo.UnitId);
//             DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(newRankInfo.UnitId, newRankInfo, "RankInfosComponent").Coroutine();
//         }
//     }
// }