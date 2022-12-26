// using System;
//
// namespace ET
// {
//     [FriendClassAttribute(typeof(ET.SessionPlayerComponent))]
//     public class C2G_EnterRoomHandler : AMRpcHandler<C2G_EnterRoom, G2C_EnterRoom>
//     {
//         protected override async ETTask Run(Session session, C2G_EnterRoom request, G2C_EnterRoom response, Action reply)
//         {
//             var sessionPlayerComponent = session.GetComponent<SessionPlayerComponent>();
//             Player player = Game.EventSystem.Get(sessionPlayerComponent.PlayerInstanceId) as Player;
//             
//             Room2G_EnterRoom chat2GEnterRoom = (Room2G_EnterRoom)await MessageHelper.CallActor(player.RoomLobbyInstanceId,
//                 new G2Room_EnterRoom()
//                 {
//                     UnitId = sessionPlayerComponent.PlayerId,
//                     Name = $"成员 {player.InstanceId}",
//                     GateSessionActorId = session.InstanceId
//                 });
//
//             player.RoomUnitInstanceId = chat2GEnterRoom.RoomUnitInstanceId;
//             
//             reply();
//             await ETTask.CompletedTask;
//         }
//     }
// }