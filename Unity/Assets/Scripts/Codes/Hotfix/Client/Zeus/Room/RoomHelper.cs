// namespace ET
// {
//     public static class RoomHelper
//     {
//         public static async ETTask EnterRoom(Scene ClientScene)
//         {
//             var resp = (G2C_EnterRoom)await ClientScene.GetComponent<SessionComponent>().Session.Call(new C2G_EnterRoom());
//             if (resp.Error != ErrorCode.ERR_Success)
//             {
//                 Log.Error(resp.Error.ToString());
//                 return;
//             }
//         }
//         
//         public static async ETTask Ready(Scene ClientScene)
//         {
//             var resp = (Room2C_Ready)await ClientScene.GetComponent<SessionComponent>().Session.Call(new C2Room_Ready());
//             if (resp.Error != ErrorCode.ERR_Success)
//             {
//                 Log.Error(resp.Error.ToString());
//                 return;
//             }
//         }
//
//         public static async ETTask GetRoomInfos(Scene ClientScene)
//         {
//             var resp = (Room2C_GetRoomList)await ClientScene.GetComponent<SessionComponent>().Session.Call(new C2Room_GetRoomList());
//             if (resp.Error != ErrorCode.ERR_Success)
//             {
//                 Log.Error(resp.Error.ToString());
//                 return;
//             }
//
//             ClientScene.GetComponent<RoomComponent>().SetRoomList(resp.RoomInfoProtoList);
//         }
//
//         public static async ETTask JoinRoomGame(Scene ClientScene, long RoomId)
//         {
//             var resp = (Room2C_JoinRoomGame)await ClientScene.GetComponent<SessionComponent>().Session
//                     .Call(new C2Room_JoinRoomGame() { RoomId = RoomId });
//             if (resp.Error != ErrorCode.ERR_Success)
//             {
//                 Log.Error(resp.Error.ToString());
//                 return;
//             }
//
//             ClientScene.GetComponent<RoomComponent>().SetMyRoom(RoomId);
//
//             Log.Info($"我进入房间了 {RoomId}");
//             Game.EventSystem.Publish(new EventType.EnterRoom() { ZoneScene = ClientScene });
//         }
//
//         public static async ETTask LeaveRoomGame(Scene ClientScene)
//         {
//             var resp = (Room2C_LeaveRoomGame)await ClientScene.GetComponent<SessionComponent>().Session.Call(new C2Room_LeaveRoomGame() { });
//             if (resp.Error != ErrorCode.ERR_Success)
//             {
//                 Log.Error(resp.Error.ToString());
//             }
//         }
//     }
// }