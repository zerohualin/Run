// using System;
//
// namespace ET
// {
//     [Timer(TimerType.AccountSessionCheckTime)]
//     public class AccountSeesionCheckOutTimer : ATimer<AccountCheckoutTimeComponent>
//     {
//         public override void Run(AccountCheckoutTimeComponent self)
//         {
//             try
//             {
//                 self.DeleteSession();
//             }
//             catch (Exception e)
//             {
//                 Log.Error(e);
//                 throw;
//             }
//         }
//     }
//     
//     [ObjectSystem]
//     public class AccountCheckoutTimeComponentAwakeSystem : AwakeSystem<AccountCheckoutTimeComponent, long>
//     {
//         public override void Awake(AccountCheckoutTimeComponent self, long accountId)
//         {
//             self.AccountId = accountId;
//             TimerComponent.Instance.Remove(ref self.Timer);
//             self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 600000, TimerType.AccountSessionCheckTime, self);
//         }
//     }
//
//     [ObjectSystem]
//     public class AccountCheckoutTimeComponentDestroySystem : DestroySystem<AccountCheckoutTimeComponent>
//     {
//         public override void Destroy(AccountCheckoutTimeComponent self)
//         {
//             self.AccountId = 0;
//             TimerComponent.Instance.Remove(ref self.Timer);
//         }
//     }
//
//     [ObjectSystem]
//     [FriendClassAttribute(typeof(ET.AccountCheckoutTimeComponent))]
//     public static class AccountCheckoutTimeComponentSystem
//     {
//         public static void DeleteSession(this AccountCheckoutTimeComponent self)
//         {
//             Session session = self.GetParent<Session>();
//             long sessionInstanceId = session.DomainScene().GetComponent<AccountSessionsComponent>().Get(self.AccountId);
//             if (session.InstanceId == sessionInstanceId)
//             {
//                 session.DomainScene().GetComponent<AccountSessionsComponent>().Remove(self.AccountId);
//             }
//             session?.Send(new A2C_Disconnect() { Error = 1 });
//             session?.Disconnect().Coroutine();
//         }
//     }
// }