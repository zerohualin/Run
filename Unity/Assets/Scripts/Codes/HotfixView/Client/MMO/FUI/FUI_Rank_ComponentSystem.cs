// /** This is an automatically generated class by FairyGUI. Please do not modify it. **/
//
// using System;
// using Cfg;
// using FairyGUI;
//
// namespace ET.Client
// {
//     [Timer(TimerType.RankUI)]
//     public class RankUITimer : ATimer<FUI_Rank_Component>
//     {
//         public override void Run(FUI_Rank_Component t)
//         {
//             t?.Refresh();
//         }
//     }
//
//     [FriendOf(typeof(FUI_Rank_Component))]
//     [FriendOf(typeof(Cell_Rank))]
//     [FriendOf(typeof(RankInfo))]
//     public static class FUI_Rank_ComponentSystem
//     {
//         public static void Init(this FUI_Rank_Component self)
//         {
//         }
//
//         public static void Refresh(this FUI_Rank_Component self)
//         {
//             self.GetRankInfo().Coroutine();
//         }
//
//         public static async ETTask GetRankInfo(this FUI_Rank_Component self)
//         {
//             try
//             {
//                 var list = self.List.asList;
//                 Scene ZoneScene = self.DomainScene();
//                 int errorCode = await RankHelper.GetRankInfo(ZoneScene);
//                 if (errorCode != ErrorCode.ERR_Success)
//                 {
//                     Log.Error(errorCode.ToString());
//                     return;
//                 }
//                 int count = self.DomainScene().GetComponent<RankComponent>().GetRankCount();
//                 list.numItems = count;
//             }
//             catch (Exception e)
//             {
//                 Log.Error(e.ToString());
//             }
//         }
//
//         public static void RefreshCell(this FUI_Rank_Component self, int index, GObject obj)
//         {
//             Cell_Rank cellRank = self.AddChild<Cell_Rank>();
//             FGUIHelper.BindRoot(typeof(Cell_Rank), cellRank, obj.asCom);
//
//             RankInfo rankInfo = self.DomainScene().GetComponent<RankComponent>().GetRankInfoByIndex(index);
//
//             cellRank.Text_Name.text = rankInfo.Name;
//             cellRank.Text_Num.text = (index + 1).ToString();
//             cellRank.Text_Star.text = rankInfo.Count.ToString();
//         }
//     }
//
//     [FGUIEvent(FGUIType.Rank)]
//     [FriendOf(typeof (FUI_Rank_Component))]
//     [ComponentOf(typeof (FGUIEntity))]
//     [FriendOf(typeof (Btn_Back))]
//     public class FUI_Rank_ComponentEvent: FGUIEvent<FUI_Rank_Component>
//     {
//         public override void OnCreate(FUI_Rank_Component component)
//         {
//             component.Btn_Back.self.AddListener(() => { FGUIComponent.Instance.Close(FGUIType.Rank); });
//
//             var list = component.List.asList;
//             list.itemRenderer = component.RefreshCell;
//             list.itemProvider = (index) => "ui://MMO/Cell_Rank";
//             component.Timer = TimerComponent.Instance.NewRepeatedTimer(5000, TimerType.RankUI, component);
//         }
//
//         public override void OnShow(FUI_Rank_Component component)
//         {
//             component.Refresh();
//         }
//
//         public override void OnRefresh(FUI_Rank_Component component)
//         {
//         }
//
//         public override void OnHide(FUI_Rank_Component component)
//         {
//             TimerComponent.Instance.Remove(ref component.Timer);
//         }
//
//         public override void OnDestroy(FUI_Rank_Component component)
//         {
//         }
//     }
// }