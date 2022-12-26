// namespace ET
// {
//     [FriendClassAttribute(typeof(ET.RoleInfo))]
//     [FriendClassAttribute(typeof(ET.Unit))]
//     [FriendClassAttribute(typeof(ET.RankInfo))]
//     public static class RankInfoHelper
//     {
//         public static void AddOrUpdateLevelRank(Unit unit)
//         {
//             using (RankInfo rankInfo = unit.DomainScene().AddChild<RankInfo>())
//             {
//                 rankInfo.UnitId = unit.Id;
//                 rankInfo.Name = unit.GetComponent<RoleInfo>().Name;
//                 rankInfo.Count = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Glod);
//
//                 Map2Rank_AddOrUpdateRankInfo message = new Map2Rank_AddOrUpdateRankInfo();
//                 message.RankInfo = rankInfo;
//                 long instanceId = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), "Rank").InstanceId;
//                 MessageHelper.SendActor(instanceId, message);
//             }
//         }
//     }
// }