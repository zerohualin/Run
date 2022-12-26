// using ET.EventType;
//
// namespace ET
// {
//     [NumericWatcher(NumericType.Glod)]
//     public class NumericWatercher_Glod: INumericWatcher
//     {
//         public void Run(NumbericChange args)
//         {
//             if (!(args.Parent is Unit unit))
//             {
//                 return;
//             }
//
//             unit = args.Parent as Unit;
//
//             RankInfoHelper.AddOrUpdateLevelRank(unit);
//         }
//     }
// }