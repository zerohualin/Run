// /** This is an automatically generated class by FairyGUI. Please do not modify it. **/
//
// using Cfg;
// namespace ET.Client
// {
//     [FriendOf(typeof(FUI_Lobby_Component))]
//     public static class FUI_Lobby_ComponentSystem
//     {
//         public static void Init(this FUI_Lobby_Component self)
//         {
//         }
//
//         public static void Refresh(this FUI_Lobby_Component self)
//         {
//             Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ClientScene().CurrentScene());
//             NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
//             self.username.text = numericComponent.GetAsInt(NumericType.Glod).ToString();
//         }
//     }
//
//     [FGUIEvent(FGUIType.Lobby)]
//     [FriendOf(typeof(FUI_Lobby_Component))]
//     [ComponentOf(typeof(FGUIEntity))]
//     [FriendOf(typeof(Btn_LobbyRight))]
//     [FriendOf(typeof(Btn_Back))]
//     [FriendOf(typeof(Btn_Setting))]
//     [FriendOf(typeof(Btn_Blanck))]
//     [FriendOf(typeof(Btn_Rank))]
//     [FriendOf(typeof(Btn_Chat))]
//     [FriendOf(typeof(Btn_Battle))]
//     [FriendOf(typeof(Btn_Map))]
//     public class FUI_Lobby_ComponentEvent : FGUIEvent<FUI_Lobby_Component>
//     {
//         public override void OnCreate(FUI_Lobby_Component component)
//         {
//             component.ButtonChangeName.self.AddListener(async () =>
//             {
//                 int error = await NumericHelper.TestUpdateNemeric(component.DomainScene());
//                 Log.Info(error.ToString());
//             });
//
//             component.Btn_Rank.self.AddListener(() =>
//             {
//                 FGUIComponent.Instance.OpenAysnc(FGUIType.Rank).Coroutine();
//             });
//
//             component.Btn_Chat.self.AddListener(() =>
//             {
//                 FGUIComponent.Instance.OpenAysnc(FGUIType.Chat).Coroutine();
//             });
//
//             component.Btn_Setting.self.AddListener(() =>
//             {
//                 FGUIComponent.Instance.OpenAysnc(FGUIType.Setting).Coroutine();
//             });
//
//             component.Btn_Battle.self.AddListener(() =>
//             {
//                 FGUIComponent.Instance.OpenAysnc(FGUIType.Clan).Coroutine();
//             });
//
//             component.Btn_Map.self.AddListener(() =>
//             {
//
//             });
//
//             component.Refresh();
//         }
//         public override void OnShow(FUI_Lobby_Component component) { }
//         public override void OnRefresh(FUI_Lobby_Component component) { }
//         public override void OnHide(FUI_Lobby_Component component) { }
//         public override void OnDestroy(FUI_Lobby_Component component) { }
//     }
// }