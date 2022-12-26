// /** This is an automatically generated class by FairyGUI. Please do not modify it. **/
//
// using Cfg;
// using FairyGUI;
// using UnityEngine;
//
// namespace ET.Client
// {
//     [FriendOf(typeof(RoomComponent))]
//     [FriendOf(typeof(ET.RoomInfo))]
//     public static class FUI_MJRoom_ComponentSystem
//     {
//         public static void Init(this FUI_MJRoom_Component self)
//         {
//         }
//
//         public static async ETTask Refresh(this FUI_MJRoom_Component self)
//         {
//             self.List.numItems = 1;
//             self.List.numItems = self.DomainScene().GetComponent<RoomComponent>().MyRoomInfo.MaxNum;
//
//             bool IAmReady = self.DomainScene().GetComponent<RoomComponent>().GetMyUnitProto().ReadyState == 1;
//             self.Btn_Ready.Text_BtnName.text = IAmReady ? "取消准备" : "准备";
//         }
//
//         public static void RefreshCell(this FUI_MJRoom_Component self, int index, GObject obj)
//         {
//             RoomUnitProto unitProto = self.DomainScene().GetComponent<RoomComponent>().GetRoomUnitProto(index);
//
//             Cell_MJRoom cell = self.AddChild<Cell_MJRoom>();
//             FGUIHelper.BindRoot(typeof(Cell_MJRoom), cell, obj.asCom);
//             if (unitProto == null)
//             {
//                 cell.Icon.visible = false;
//                 cell.Text_Name.text = "";
//                 cell.Text_ReadyState.text = "空位";
//                 cell.Text_ReadyState.color = Color.white;
//             }
//             else
//             {
//                 cell.Icon.visible = true;
//                 cell.Text_Name.text = unitProto.Id.ToString();
//                 bool IsReady = unitProto.ReadyState == 1;
//                 cell.Text_ReadyState.text = IsReady ? "已准备" : "未准备";
//                 cell.Text_ReadyState.color = IsReady ? Color.green : Color.yellow;
//             }
//         }
//
//         public static async ETTask Leave(this FUI_MJRoom_Component self)
//         {
//             await RoomHelper.LeaveRoomGame(self.DomainScene());
//             FGUIComponent.Instance.Close(FGUIType.MJRoom);
//         }
//     }
//
//     [FGUIEvent(FGUIType.MJRoom)]
//     [FriendOf(typeof(FUI_MJRoom_Component))]
//     [ComponentOf(typeof(FGUIEntity))]
//     [ChildOf(typeof(Cell_Clan))]
//     [FriendOf(typeof(ET.RoomInfo))]
//     [FriendOf(typeof(ET.RoomComponent))]
//     public class FUI_MJRoom_ComponentEvent : FGUIEvent<FUI_MJRoom_Component>
//     {
//         public override void OnCreate(FUI_MJRoom_Component component)
//         {
//             component.Btn_Back.self.AddListener(() => { component.Leave().Coroutine(); });
//             component.Btn_Ready.self.AddListener(() => { RoomHelper.Ready(component.DomainScene()).Coroutine(); });
//
//             var list = component.List.asList;
//             list.itemRenderer = component.RefreshCell;
//             list.itemProvider = (index) => { return "ui://MMO/Cell_MJRoom"; };
//
//             component.Refresh().Coroutine();
//         }
//
//         public override void OnShow(FUI_MJRoom_Component component)
//         {
//             string name = component.DomainScene().GetComponent<RoomComponent>().MyRoomInfo.Name;
//             component.Text_Name.text = name;
//         }
//
//         public override void OnRefresh(FUI_MJRoom_Component component)
//         {
//         }
//
//         public override void OnHide(FUI_MJRoom_Component component)
//         {
//         }
//
//         public override void OnDestroy(FUI_MJRoom_Component component)
//         {
//         }
//     }
// }