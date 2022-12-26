// /** This is an automatically generated class by FairyGUI. Please do not modify it. **/
//
// using Cfg;
// using FairyGUI;
// using UnityEngine;
//
// namespace ET.Client
// {
//     [FriendOf(typeof (FUI_Othello_Component))]
//     [FriendOf(typeof (OthelloComponent))]
//     [FriendOf(typeof (Cell_Othello))]
//     public static class FUI_Othello_ComponentSystem
//     {
//         public static void Init(this FUI_Othello_Component self)
//         {
//         }
//
//         public static async ETTask RefreshList(this FUI_Othello_Component self)
//         {
//             self.List.numItems = 1;
//             self.List.numItems = 64;
//             self.Text_Next.text = self.NowPlayerId == 1 ? "白棋回合" : "黑棋回合";
//             
//         }
//         
//         public static void RefreshCell(this FUI_Othello_Component self, int index, GObject obj)
//         {
//             int x = index % 8;
//             int y = (index / 8);
//
//             OthelloCellState cellState = self.DomainScene().GetComponent<OthelloComponent>().CellDatas[x][y].State;
//             Cell_Othello cell = self.AddChild<Cell_Othello>();
//             FGUIHelper.BindRoot(typeof (Cell_Othello), cell, obj.asCom);
//
//             switch (cellState)
//             {
//                 case OthelloCellState.None:
//                     cell.Icon.visible = false;
//                     break;
//                 case OthelloCellState.White:
//                     cell.Icon.visible = true;
//                     cell.Icon.color = Color.white;
//                     break;
//                 case OthelloCellState.Black:
//                     cell.Icon.visible = true;
//                     cell.Icon.color = Color.black;
//                     break;
//             }
//
//             cell.self.AddListener(() =>
//             {
//                 bool t = OthelloHelper.TryMove(self.DomainScene(), self.NowPlayerId, x, y);
//                 if (t)
//                 {
//                     if (self.NowPlayerId == 1)
//                     {
//                         self.NowPlayerId = 2;
//                     }
//                     else
//                     {
//                         self.NowPlayerId = 1;
//                     }
//                 }
//
//                 self.RefreshList().Coroutine();
//             });
//         }
//     }
//
//     [FGUIEvent(FGUIType.Othello)]
//     [FriendOf(typeof (FUI_Othello_Component))]
//     [ComponentOf(typeof (FGUIEntity))]
//     public class FUI_Othello_ComponentEvent: FGUIEvent<FUI_Othello_Component>
//     {
//         public override void OnCreate(FUI_Othello_Component component)
//         {
//             component.DomainScene().AddComponent<OthelloComponent>();
//
//             var list = component.List.asList;
//             list.itemRenderer = component.RefreshCell;
//             list.itemProvider = (index) => { return "ui://MMO/Cell_Othello"; };
//             component.RefreshList().Coroutine();
//         }
//
//         public override void OnShow(FUI_Othello_Component component)
//         {
//         }
//
//         public override void OnRefresh(FUI_Othello_Component component)
//         {
//         }
//
//         public override void OnHide(FUI_Othello_Component component)
//         {
//         }
//
//         public override void OnDestroy(FUI_Othello_Component component)
//         {
//             component.DomainScene().GetComponent<OthelloComponent>().Dispose();
//         }
//     }
// }