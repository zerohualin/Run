// using System;
//
// namespace ET
// {
//     public class C2Room_GetRoomListHandler: AMActorRpcHandler<RoomUnit, C2Room_GetRoomList, Room2C_GetRoomList>
//     {
//         protected override async ETTask Run(RoomUnit roomUnit, C2Room_GetRoomList request, Room2C_GetRoomList response, Action reply)
//         {
//             RoomInfosComponent roomInfosComponent = roomUnit.DomainScene().GetComponent<RoomInfosComponent>();
//             response.RoomInfoProtoList = roomInfosComponent.GetRoomInfoProtoss();
//             reply();
//             await ETTask.CompletedTask;
//         }
//     }
// }