// using Cfg;
//
// namespace ET.Client
// {
//     public class UpdateRoomInfoEventHandler: AEvent<EventType.UpdateMyRoomInfo>
//     {
//         protected override async ETTask Run(Scene scene, EventType.UpdateMyRoomInfo args)
//         {
//             FGUIComponent.Instance.Get<FUI_MJRoom_Component>(FGUIType.MJRoom)?.Refresh().Coroutine();
//         }
//     }
// }