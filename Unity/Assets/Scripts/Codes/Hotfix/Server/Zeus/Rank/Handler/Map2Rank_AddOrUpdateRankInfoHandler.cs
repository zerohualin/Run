// namespace ET
// {
//     public class Map2Rank_AddOrUpdateRankInfoHandler: AMActorHandler<Scene, Map2Rank_AddOrUpdateRankInfo>
//     {
//         protected override async ETTask Run(Scene scene, Map2Rank_AddOrUpdateRankInfo message)
//         {
//             RankInfosComponent rankInfosComponent = scene.GetComponent<RankInfosComponent>();
//             rankInfosComponent.AddOrUpdate(message.RankInfo);
//             await ETTask.CompletedTask;
//         }
//     }
// }