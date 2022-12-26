// using Cfg;
//
// namespace ET.Client
// {
//     public class LoginFinish_EnterLobby: AEvent<EventType.LoginFinish>
//     {
//         protected override async ETTask Run(Scene scene, EventType.LoginFinish args)
//         {
//             FGUIComponent.Instance.Close(FGUIType.SelectServer);
//             await FGUIComponent.Instance.OpenAysnc(FGUIType.Lobby);
//         }
//     }
// }