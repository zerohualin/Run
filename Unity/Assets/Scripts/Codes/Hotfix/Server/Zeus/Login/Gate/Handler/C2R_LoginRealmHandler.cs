// using System;
//
// namespace ET
// {
//     public class C2R_LoginRealmHandler : AMRpcHandler<C2R_LoginRealm, R2C_LoginRealm>
//     {
//         protected override async ETTask Run(Session session, C2R_LoginRealm request, R2C_LoginRealm response,
//             Action reply)
//         {
//             if (!session.CheckSceneType(SceneType.Realm))
//             {
//                 return;
//             }
//
//             Scene domainScene = session.DomainScene();
//             if (session.GetComponent<SessionLockingComponent>() != null)
//             {
//                 response.Error = ErrorCode.ERR_RequestRepeatedly;
//                 reply();
//                 session?.Disconnect().Coroutine();
//                 return;
//             }
//
//             string token = domainScene.GetComponent<TokenComponent>().Get(request.AccountId);
//             if (token == null || token != request.RealmTokenKey)
//             {
//                 response.Error = ErrorCode.ERR_TokenError;
//                 reply();
//                 session?.Disconnect().Coroutine();
//                 return;
//             }
//
//             //验证过后就不会再连这边了所以移除这个token
//             domainScene.GetComponent<TokenComponent>().Remove(request.AccountId);
//             using (session.AddComponent<SessionLockingComponent>())
//             {
//                 using (await CoroutineLockComponent.Instance.Wait((int)CoroutineLockType.LoginRealm, request.AccountId))
//                 {
//                     StartSceneConfig config = RealmGateAddressHelper.GetGate(domainScene.Zone, request.AccountId);
//                     G2R_GetLoginGateKey g2RGetLoginGateKey = (G2R_GetLoginGateKey)await MessageHelper.CallActor(
//                         config.InstanceId, new R2G_GetLoginGateKey()
//                         {
//                             AccountId = request.AccountId
//                         });
//                     
//                     if (g2RGetLoginGateKey.Error != ErrorCode.ERR_Success)
//                     {
//                         response.Error = g2RGetLoginGateKey.Error;
//                         reply();
//                         return;
//                     }
//
//                     response.GateSessionKey = g2RGetLoginGateKey.GateSessionKey;
//                     response.GateAddress = config.OuterIPPort.ToString();
//                     reply();
//                     session?.Disconnect().Coroutine();
//                 }
//             }
//         }
//     }
// }