// namespace ET
// {
//     [ObjectSystem]
//     public class LoginInfoRecordComponentAwakeSystem : AwakeSystem<LoginInfoRecordComponent, long>
//     {
//         public override void Awake(LoginInfoRecordComponent self, long accountId)
//         {
//         }
//     }
//
//     [ObjectSystem]
//     public class LoginInfoRecordComponentDestroySystem : DestroySystem<LoginInfoRecordComponent>
//     {
//         public override void Destroy(LoginInfoRecordComponent self)
//         {
//             self.AccountLoginINfoDict.Clear();
//         }
//     }
//     [FriendClassAttribute(typeof(ET.LoginInfoRecordComponent))]
//     public static class LoginInfoRecordComponentSystem
//     {
//         public static void Add(this LoginInfoRecordComponent self, long key, int value)
//         {
//             if (self.AccountLoginINfoDict.ContainsKey(key))
//             {
//                 self.AccountLoginINfoDict[key] = value;
//                 return;
//             }
//
//             self.AccountLoginINfoDict.Add(key, value);
//         }
//
//         public static int Get(this LoginInfoRecordComponent self, long key)
//         {
//             if (!self.AccountLoginINfoDict.TryGetValue(key, out int value))
//             {
//                 return -1;
//             }
//             return value;
//         }
//
//         public static bool IsExit(this LoginInfoRecordComponent self, long key)
//         {
//             return self.AccountLoginINfoDict.ContainsKey(key);
//         }
//
//         public static void Remove(this LoginInfoRecordComponent self, long key)
//         {
//             if (self.AccountLoginINfoDict.ContainsKey(key))
//             {
//                 self.AccountLoginINfoDict.Remove(key);
//                 return;
//             }
//         }
//     }
// }