// using System;
//
// namespace ET
// {
//     [FriendClass(typeof (RankInfosComponent))]
//     public class C2Rank_GetRanksInfoHandler: AMActorRpcHandler<Scene, C2Rank_GetRanksInfo, Rank2C_GetRanksInfo>
//     {
//         protected override async ETTask Run(Scene scene, C2Rank_GetRanksInfo request, Rank2C_GetRanksInfo response, Action reply)
//         {
//             RankInfosComponent rankInfosComponent = scene.GetComponent<RankInfosComponent>();
//             foreach (var rankInfo in rankInfosComponent.SortedRankInfoList)
//             {
//                 response.RankInfoProtoList.Add(rankInfo.Key.ToMessage());
//             }
//
//             reply();
//             await ETTask.CompletedTask;
//         }
//     }
// }