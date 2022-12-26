// using System;
//
// namespace ET
// {
//     [Timer(TimerType.PlayerOfflineOutTime)]
//     public class PlayerOfflineOutTime : ATimer<PlayerOfflineOutTimeComponent>
//     {
//         public override void Run(PlayerOfflineOutTimeComponent self)
//         {
//             try
//             {
//                 self.KickPlayer();
//             }
//             catch (Exception e)
//             {
//                 Log.Error($"playeroffline timer error {self.Id}; {e}");
//             }
//         }
//     }
//
//     [ObjectSystem]
//     public class PlayerOfflineOutTimeComponentAwakeSystem : AwakeSystem<PlayerOfflineOutTimeComponent, long>
//     {
//         public override void Awake(PlayerOfflineOutTimeComponent self, long accountId)
//         {
//             self.Timer =
//                 TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 10000, TimerType.PlayerOfflineOutTime,
//                     self);
//         }
//     }
//
//     [ObjectSystem]
//     public class PlayerOfflineOutTimeComponentDestroySystem : DestroySystem<PlayerOfflineOutTimeComponent>
//     {
//         public override void Destroy(PlayerOfflineOutTimeComponent self)
//         {
//             TimerComponent.Instance.Remove(ref self.Timer);
//         }
//     }
//
//     public static class PlayerOfflineOutTimeComponentSystem
//     {
//         public static void KickPlayer(this PlayerOfflineOutTimeComponent self)
//         {
//             DisconnectHelper.KickPlayer(self.GetParent<Player>()).Coroutine();
//         }
//     }
// }