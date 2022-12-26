// using System;
//
// namespace ET
// {
//     public class G2Room_EnterRoomHandler: AMActorRpcHandler<Scene, G2Room_EnterRoom, Room2G_EnterRoom>
//     {
//         protected override async ETTask Run(Scene scene, G2Room_EnterRoom request, Room2G_EnterRoom response, Action reply)
//         {
//             RoomUnitsComponent unitsComponent = scene.GetComponent<RoomUnitsComponent>();
//             RoomUnit roomUnit = unitsComponent.Get(request.UnitId);
//             
//             if (roomUnit != null && !roomUnit.IsDisposed)
//             {
//                 roomUnit.Name = request.Name;
//                 roomUnit.GateSessionActorId = request.GateSessionActorId;
//                 response.RoomUnitInstanceId = roomUnit.InstanceId;
//                 reply();
//                 return;
//             }
//
//             roomUnit = unitsComponent.AddChildWithId<RoomUnit>(request.UnitId);
//             roomUnit.AddComponent<MailBoxComponent>();
//
//             roomUnit.Name = request.Name;
//             roomUnit.GateSessionActorId = request.GateSessionActorId;
//             response.RoomUnitInstanceId = roomUnit.InstanceId;
//             unitsComponent.Add(roomUnit);
//             
//             reply();
//             await ETTask.CompletedTask;
//         }
//     }
// }