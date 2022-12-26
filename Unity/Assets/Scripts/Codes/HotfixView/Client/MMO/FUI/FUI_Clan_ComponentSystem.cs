// /** This is an automatically generated class by FairyGUI. Please do not modify it. **/
//
// using Cfg;
// using FairyGUI;
//
// namespace ET.Client
// {
//     [FriendOf(typeof (FUI_Clan_Component))]
//     [FriendOf(typeof (ET.RoomComponent))]
//     [FriendOf(typeof (ET.RoomInfo))]
//     [FriendOf(typeof (ET.Client.Cell_Clan))]
//     public static class FUI_Clan_ComponentSystem
//     {
//         public static void Init(this FUI_Clan_Component self)
//         {
//         }
//
//         public static async ETTask RefreshList(this FUI_Clan_Component self)
//         {
//             await RoomHelper.EnterRoom(self.DomainScene());
//             await RoomHelper.GetRoomInfos(self.DomainScene());
//             self.List.numItems = self.DomainScene().GetComponent<RoomComponent>().RoomInfos.Count;
//         }
//
//         public static void RefreshCell(this FUI_Clan_Component self, int index, GObject obj)
//         {
//             RoomInfo chatInfo = self.DomainScene().GetComponent<RoomComponent>().GetRoomInfoByIndex(index);
//             Cell_Clan cell_Clan = self.AddChild<Cell_Clan>();
//             FGUIHelper.BindRoot(typeof (Cell_Clan), cell_Clan, obj.asCom);
//
//             cell_Clan.Text_Title.text = chatInfo.Name;
//             cell_Clan.Text_Members.text = $"{chatInfo.CurrentNum} / {chatInfo.MaxNum}";
//             cell_Clan.self.AddListener(() => { RoomHelper.JoinRoomGame(self.DomainScene(), chatInfo.Id).Coroutine(); });
//         }
//     }
//
//     [FGUIEvent(FGUIType.Clan)]
//     [FriendOf(typeof (FUI_Clan_Component))]
//     [ComponentOf(typeof (FGUIEntity))]
//     [FriendOf(typeof (Btn_AddRoom))]
//     [FriendOf(typeof (Btn_Back))]
//     [FriendOf(typeof (Btn_Search))]
//     [FriendOf(typeof (RoomComponent))]
//     public class FUI_Clan_ComponentEvent: FGUIEvent<FUI_Clan_Component>
//     {
//         public override void OnCreate(FUI_Clan_Component component)
//         {
//             var list = component.List.asList;
//             list.itemRenderer = component.RefreshCell;
//             list.itemProvider = (index) => { return "ui://MMO/Cell_Clan"; };
//
//             component.Btn_Back.self.AddListener(() => { FGUIComponent.Instance.Close(FGUIType.Clan); });
//
//             component.Btn_Search.self.AddListener(() => { component.RefreshList().Coroutine(); });
//
//             component.RefreshList().Coroutine();
//         }
//
//         public override void OnShow(FUI_Clan_Component component)
//         {
//         }
//
//         public override void OnRefresh(FUI_Clan_Component component)
//         {
//         }
//
//         public override void OnHide(FUI_Clan_Component component)
//         {
//         }
//
//         public override void OnDestroy(FUI_Clan_Component component)
//         {
//         }
//     }
// }