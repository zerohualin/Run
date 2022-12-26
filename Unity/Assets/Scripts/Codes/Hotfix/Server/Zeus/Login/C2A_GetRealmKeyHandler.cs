// using System;
//
// namespace ET
// {
//     public class C2A_GetRealmKeyHandler : AMRpcHandler<C2A_GetRealmKey, A2C_GetRealmKey>
//     {
//         protected override async ETTask Run(Session session, C2A_GetRealmKey request, A2C_GetRealmKey response,
//             Action reply)
//         {
//             if (!session.CheckSceneType(SceneType.Account))
//             {
//                 return;
//             }
//
//             if (!session.CheckToken(request.AccountId, request.Token))
//             {
//                 response.Error = ErrorCode.ERR_TokenError;
//                 reply();
//                 session?.Disconnect().Coroutine();
//                 return;
//             }
//
//             if (session.GetComponent<SessionLockingComponent>() != null)
//             {
//                 response.Error = ErrorCode.ERR_RequestRepeatedly;
//                 reply();
//                 session?.Disconnect().Coroutine();
//                 return;
//             }
//
//             using (session.AddComponent<SessionLockingComponent>())
//             {
//                 //向realm网关服务器请求也是异步延迟的，所以可能成功的从realm请求成功之前，玩家被踢下线了
//                 using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, request.AccountId))
//                 {
//                     StartSceneConfig realmStartSceneConfig = RealmGateAddressHelper.GetRealm(request.ServerId);
//                     var r2A_GetRealmKey = (R2A_GetRealmKey)await MessageHelper.CallActor(
//                         realmStartSceneConfig.InstanceId,
//                         new A2R_GetRealmKey()
//                         {
//                             AccountId = request.AccountId,
//                         });
//                     if (r2A_GetRealmKey.Error != ErrorCode.ERR_Success)
//                     {
//                         response.Error = r2A_GetRealmKey.Error;
//                         reply();
//                         session?.Disconnect().Coroutine();
//                         return;
//                     }
//
//                     response.RealmKey = r2A_GetRealmKey.RealmKey;
//                     response.RealmAddress = realmStartSceneConfig.OuterIPPort.ToString();
//                     reply();
//                     session?.Disconnect().Coroutine();
//                 }
//             }
//         }
//     }
// }