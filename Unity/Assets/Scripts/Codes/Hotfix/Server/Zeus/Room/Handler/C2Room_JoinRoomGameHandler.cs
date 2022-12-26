// using System;
//
// namespace ET
// {
//     [FriendClassAttribute(typeof (ET.RoomInfo))]
//     [FriendClassAttribute(typeof (ET.RoomUnit))]
//     public class C2Room_JoinRoomGameHandler: AMActorRpcHandler<RoomUnit, C2Room_JoinRoomGame, Room2C_JoinRoomGame>
//     {
//         protected override async ETTask Run(RoomUnit unit, C2Room_JoinRoomGame request, Room2C_JoinRoomGame response, Action reply)
//         {
//             RoomInfo roomInfo = unit.DomainScene().GetComponent<RoomInfosComponent>().Get(request.RoomId);
//             if (roomInfo == null)
//             {
//                 response.Error = ErrorCode.ERR_RoomNotExit;
//             }
//             else
//             {
//                 roomInfo.Join(unit.Id);
//                 
//                 roomInfo.BoardcastRoomInfo();
//                 
//                 unit.MyRoomId = roomInfo.Id;
//             }
//             reply();
//             await ETTask.CompletedTask;
//         }
//     }
// }