// using System;
//
// namespace ET
// {
//     public static class RankHelper
//     {
//         public static async ETTask<int> GetRankInfo(Scene ClientScene)
//         {
//             Rank2C_GetRanksInfo rank2GetRanksInfo = null;
//             try
//             {
//                 rank2GetRanksInfo =
//                         (Rank2C_GetRanksInfo)await ClientScene.GetComponent<SessionComponent>().Session.Call(new C2Rank_GetRanksInfo() { });
//             }
//             catch (Exception e)
//             {
//                 Log.Error(e.ToString());
//                 return ErrorCode.ERR_NetworkError;
//             }
//
//             if (rank2GetRanksInfo.Error != ErrorCode.ERR_Success)
//                 return rank2GetRanksInfo.Error;
//             
//             ClientScene.GetComponent<RankComponent>().ClearAll();
//             for (int i = 0; i < rank2GetRanksInfo.RankInfoProtoList.Count; i++)
//             {
//                 ClientScene.GetComponent<RankComponent>().Add(rank2GetRanksInfo.RankInfoProtoList[i]);
//             }
//             
//             return ErrorCode.ERR_Success;
//         }
//     }
// }