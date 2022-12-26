// using System;
//
// namespace ET
// {
//     [FriendClassAttribute(typeof(ET.SessionPlayerComponent))]
//     [FriendClassAttribute(typeof(ET.SessionStateComponent))]
//     public class C2G_LoginGameGateHandler : AMRpcHandler<C2G_LoginGameGate, G2C_LoginGameGate>
//     {
//         protected override async ETTask Run(Session session, C2G_LoginGameGate request, G2C_LoginGameGate response,
//             Action reply)
//         {
//             if (!session.CheckSceneType(SceneType.Gate))
//             {
//                 return;
//             }
//
//             session.RemoveComponent<SessionAcceptTimeoutComponent>();
//             if (session.GetComponent<SessionLockingComponent>() != null)
//             {
//                 response.Error = ErrorCode.ERR_RequestRepeatedly;
//                 reply();
//                 session?.Disconnect().Coroutine();
//                 return;
//             }
//
//             Scene scene = session.DomainScene();
//             string tokenKey = scene.GetComponent<GateSessionKeyComponent>().Get(request.AccountId);
//             if (tokenKey == null || !tokenKey.Equals(request.Key))
//             {
//                 response.Error = ErrorCode.ERR_ConnectGateKeyError;
//                 response.Message = "Gate Key 验证失败了哦";
//                 Log.Error($"玩家{request.AccountId} GateKey验证失败！！！");
//                 reply();
//                 session?.Disconnect().Coroutine();
//                 return;
//             }
//
//             //通过验证后，把key从池子中拿掉
//             scene.GetComponent<GateSessionKeyComponent>().Remove(request.AccountId);
//             long sessionInstanceId = session.InstanceId;
//             using (session.AddComponent<SessionLockingComponent>())
//             {
//                 using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate,
//                            request.AccountId.GetHashCode()))
//                 {
//                     if (sessionInstanceId != session.InstanceId)
//                     {
//                         return;
//                     }
//
//                     SessionStateComponent sessionStateComponent = session.GetComponent<SessionStateComponent>();
//                     if (sessionStateComponent == null)
//                     {
//                         sessionStateComponent = session.AddComponent<SessionStateComponent>();
//                     }
//                     sessionStateComponent.State = SessionState.Normal;
//
//                     //通知登录中心服本次登录的服务器zone
//                     StartSceneConfig loginCenterConfig = StartSceneConfigCategory.Instance.LoginCenterConfig;
//                     L2G_AddLoginRecord l2GAddLoginRecord;
//
//                     l2GAddLoginRecord = (L2G_AddLoginRecord)await MessageHelper.CallActor(loginCenterConfig.InstanceId,
//                         new G2L_AddLoginRecord()
//                         {
//                             AccountId = request.AccountId,
//                             ServerId = scene.Zone
//                         });
//
//                     if (l2GAddLoginRecord.Error != ErrorCode.ERR_Success)
//                     {
//                         response.Error = l2GAddLoginRecord.Error;
//                         reply();
//                         session?.Disconnect().Coroutine();
//                         return;
//                     }
//                     
//                     Player player = scene.GetComponent<PlayerComponent>().Get(request.AccountId);
//                     if (player == null)
//                     {
//                         player = scene.GetComponent<PlayerComponent>()
//                             .AddChildWithId<Player, long, long>(request.AccountId, request.AccountId, request.RoleId);
//                         player.PlayerState = PlayerState.Gate;
//                         scene.GetComponent<PlayerComponent>().Add(player);
//                         session.AddComponent<MailBoxComponent, MailboxType>(MailboxType.GateSession);
//                     }
//                     else
//                     {
//                         //用来倒计时下线
//                         player.RemoveComponent<PlayerOfflineOutTimeComponent>();
//                     }
//
//                     //Player是玩家在gate上的映射，方便连接管理
//                     session.AddComponent<SessionPlayerComponent>().PlayerId = player.Id;
//                     session.GetComponent<SessionPlayerComponent>().PlayerInstanceId = player.InstanceId;
//                     player.ClientSession = session;
//                     
//                     response.PlayerId = player.Id;
//                 }
//                 reply();
//             }
//         }
//     }
// }