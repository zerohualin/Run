// /** This is an automatically generated class by FairyGUI. Please do not modify it. **/
//
// using System;
// using Cfg;
// using FairyGUI;
//
// namespace ET.Client
// {
//     [FriendOf(typeof(FUI_Chat_Component))]
//     [FriendOf(typeof(ChatInfo))]
//     [FriendOf(typeof(Cell_Chat_Self))]
//     [FriendOf(typeof(Cell_Chat_Other))]
//     public static class FUI_Chat_ComponentSystem
//     {
//         public static void Init(this FUI_Chat_Component self)
//         {
//         }
//
//         public static void Refresh(this FUI_Chat_Component self)
//         {
//             self.List.numItems = self.DomainScene().GetComponent<ChatComponent>().GetChatMessageCount();
//         }
//
//         public static string GetProvider(this FUI_Chat_Component self, int index)
//         {
//             ChatInfo chatInfo = self.DomainScene().GetComponent<ChatComponent>().GetChatMessageByIndex(index);
//             if (chatInfo.UnitId == self.DomainScene().GetComponent<PlayerComponent>().MyId)
//             {
//                 return "ui://MMO/Cell_Chat_Self";
//             }
//             else
//             {
//                 return "ui://MMO/Cell_Chat_Other";
//             }
//         }
//
//         public static void RefreshCell(this FUI_Chat_Component self, int index, GObject obj)
//         {
//             ChatInfo chatInfo = self.DomainScene().GetComponent<ChatComponent>().GetChatMessageByIndex(index);
//             if (chatInfo.UnitId == self.DomainScene().GetComponent<PlayerComponent>().MyId)
//             {
//                 Cell_Chat_Self cellChatSelf = self.AddChild<Cell_Chat_Self>();
//                 FGUIHelper.BindRoot(typeof(Cell_Chat_Self), cellChatSelf, obj.asCom);
//                 cellChatSelf.Text_Name.text = chatInfo.Name;
//                 cellChatSelf.Text_Content.text = chatInfo.Message;
//                 cellChatSelf.self.height = cellChatSelf.Text_Content.height + 110;
//             }
//             else
//             {
//                 Cell_Chat_Other cellChatSelf = self.AddChild<Cell_Chat_Other>();
//                 FGUIHelper.BindRoot(typeof(Cell_Chat_Other), cellChatSelf, obj.asCom);
//
//                 cellChatSelf.Text_Name.text = chatInfo.Name;
//                 cellChatSelf.Text_Content.text = chatInfo.Message;
//             }
//         }
//
//         public static async ETTask SendMessage(this FUI_Chat_Component self)
//         {
//             try
//             {
//                 int errorCode = await ChatHelper.SendMessage(self.ZoneScene(), self.Input_Chat.text);
//                 self.Input_Chat.text = "";
//                 if (errorCode != ErrorCode.ERR_Success)
//                 {
//                     Log.Error(errorCode.ToString());
//                     return;
//                 }
//                 self.Refresh();
//             }
//             catch (Exception e)
//             {
//                 Log.Error(e.ToString());
//             }
//         }
//     }
//
//     [FGUIEvent(FGUIType.Chat)]
//     [FriendOf(typeof(FUI_Chat_Component))]
//     [ComponentOf(typeof(FGUIEntity))]
//     [FriendOf(typeof(Btn_Close2))]
//     [FriendOf(typeof(Btn_EmojiSend))]
//     public class FUI_Chat_ComponentEvent : FGUIEvent<FUI_Chat_Component>
//     {
//         public override void OnCreate(FUI_Chat_Component component)
//         {
//             component.Btn_Close2.self.AddListener(() => { FGUIComponent.Instance.Close(FGUIType.Chat); });
//
//             component.Btn_EmojiSend.self.AddListener(() =>
//             {
//                 component.SendMessage().Coroutine();
//             });
//
//             var list = component.List.asList;
//             list.itemRenderer = component.RefreshCell;
//             list.itemProvider = component.GetProvider;
//
//             component.Refresh();
//         }
//
//         public override void OnShow(FUI_Chat_Component component)
//         {
//         }
//
//         public override void OnRefresh(FUI_Chat_Component component)
//         {
//         }
//
//         public override void OnHide(FUI_Chat_Component component)
//         {
//         }
//
//         public override void OnDestroy(FUI_Chat_Component component)
//         {
//         }
//     }
// }