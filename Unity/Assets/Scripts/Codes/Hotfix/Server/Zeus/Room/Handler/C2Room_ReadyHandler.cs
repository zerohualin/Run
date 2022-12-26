// using System;
//
// namespace ET
// {
//     [FriendClassAttribute(typeof (ET.RoomInfo))]
//     [FriendClassAttribute(typeof (ET.RoomUnit))]
//     public class C2Room_ReadyHandler: AMActorRpcHandler<RoomUnit, C2Room_Ready, Room2C_Ready>
//     {
//         protected override async ETTask Run(RoomUnit unit, C2Room_Ready request, Room2C_Ready response, Action reply)
//         {
//             RoomInfo roomInfo = unit.DomainScene().GetComponent<RoomInfosComponent>().Get(unit.MyRoomId);
//             roomInfo.ChangeUnitReadyState(unit.Id);
//             roomInfo.BoardcastRoomInfo();
//             reply();
//             await ETTask.CompletedTask;
//         }
//     }
// }