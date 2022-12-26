// namespace ET
// {
//     [ObjectSystem]
//     public class AccountSeesionsComponentDestroySystem : DestroySystem<AccountSessionsComponent>
//     {
//         public override void Destroy(AccountSessionsComponent self)
//         {
//             self.AccountSessionDictionary.Clear();
//         }
//     }
//     [FriendClassAttribute(typeof(ET.AccountSessionsComponent))]
//     public static class AccountSeesionsComponentSystem
//     {
//         public static long Get(this AccountSessionsComponent self, long accountId)
//         {
//             if (!self.AccountSessionDictionary.TryGetValue(accountId, out long instanceId))
//             {
//                 return 0;
//             }
//             return instanceId;
//         }
//
//         public static void Add(this AccountSessionsComponent self, long accountId, long sessionInstanceId)
//         {
//             if (self.AccountSessionDictionary.ContainsKey(accountId))
//             {
//                 self.AccountSessionDictionary[accountId] = sessionInstanceId;
//                 return;
//             }
//             self.AccountSessionDictionary.Add(accountId, sessionInstanceId);
//         }
//
//         public static void Remove(this AccountSessionsComponent self, long accountId)
//         {
//             if (self.AccountSessionDictionary.ContainsKey(accountId))
//             {
//                 self.AccountSessionDictionary.Remove(accountId);
//             }
//         }
//     }
// }