// using System;
//
// namespace ET
// {
//     [FriendClassAttribute(typeof (ET.RoomInfo))]
//     [FriendClassAttribute(typeof (ET.RoomUnit))]
//     public class C2Room_LeaveRoomGameHandler: AMActorRpcHandler<RoomUnit, C2Room_LeaveRoomGame, Room2C_LeaveRoomGame>
//     {
//         protected override async ETTask Run(RoomUnit unit, C2Room_LeaveRoomGame request, Room2C_LeaveRoomGame response, Action reply)
//         {
//             RoomInfo roomInfo = unit.DomainScene().GetComponent<RoomInfosComponent>().Get(unit.MyRoomId);
//             if (roomInfo == null)
//             {
//                 response.Error = ErrorCode.ERR_RoomNotExit;
//             }
//             else
//             {
//                 roomInfo.Level(unit.Id);
//                 
//                 roomInfo.BoardcastRoomInfo();
//                 
//                 unit.MyRoomId = 0;
//             }
//             reply();
//             await ETTask.CompletedTask;
//         }
//     }
// }