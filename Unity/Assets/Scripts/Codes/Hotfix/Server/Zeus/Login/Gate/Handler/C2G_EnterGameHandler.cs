// using System;
//
// namespace ET
// {
//     [FriendClassAttribute(typeof(ET.SessionPlayerComponent))]
//     [FriendClassAttribute(typeof(ET.SessionStateComponent))]
//     [FriendClassAttribute(typeof(ET.GateMapComponent))]
//     [FriendClassAttribute(typeof(ET.RoleInfo))]
//     [FriendClassAttribute(typeof(ET.UnitGateComponent))]
//     public class C2G_EnterGameHandler : AMRpcHandler<C2G_EnterGame, G2C_EnterGame>
//     {
//         protected override async ETTask Run(Session session, C2G_EnterGame request, G2C_EnterGame response,
//             Action reply)
//         {
//             if (!session.CheckSceneType(SceneType.Gate))
//             {
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
//             SessionPlayerComponent sessionPlayerComponent = session.GetComponent<SessionPlayerComponent>();
//             if (null == sessionPlayerComponent)
//             {
//                 response.Error = ErrorCode.ERR_NoneSessionPlayer;
//                 reply();
//                 return;
//             }
//
//             Player player = Game.EventSystem.Get(sessionPlayerComponent.PlayerInstanceId) as Player;
//             if (player == null || player.IsDisposed)
//             {
//                 response.Error = ErrorCode.ERR_NonePlayer;
//                 reply();
//                 return;
//             }
//
//             long instanceId = session.InstanceId;
//             using (session.AddComponent<SessionLockingComponent>())
//             {
//                 using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate,
//                     player.AccountId.GetHashCode()))
//                 {
//                     //防止请求携程锁的二次执行导致的错误
//                     if (instanceId != session.InstanceId || player.IsDisposed)
//                     {
//                         response.Error = ErrorCode.ERR_NoneSessionPlayer;
//                         reply();
//                         return;
//                     }
//
//                     if (session.GetComponent<SessionStateComponent>() != null
//                         && session.GetComponent<SessionStateComponent>().State == SessionState.Game)
//                     {
//                         response.Error = ErrorCode.ERR_SessionStateError;
//                         reply();
//                         return;
//                     }
//
//                     //由于玩家可以不同设备 顶号，所以一个player可以在game状态！
//                     if (player.PlayerState == PlayerState.Game)
//                     {
//                         try
//                         {
//                             var reqEnter =
//                                 (M2G_RequestEnterGameState)await MessageHelper.CallLocationActor(player.Id,
//                                     new G2M_RequestEnterGameState());
//                             if (reqEnter.Error == 0)
//                             {
//                                 reply();
//                                 return;
//                             }
//
//                             Log.Error($"二次登陆失败   {reqEnter.Error} | {reqEnter.Message}");
//                             response.Error = ErrorCode.ERR_ReEnterGameError;
//                             await DisconnectHelper.KickPlayer(player, true);
//                             reply();
//                             session?.Disconnect().Coroutine();
//                         }
//                         catch (Exception e)
//                         {
//                             Log.Error(e);
//                             Log.Error($"二次登陆失败   {e.ToString()}");
//                             response.Error = ErrorCode.ERR_ReEnterGameError;
//                             await DisconnectHelper.KickPlayer(player, true);
//                             reply();
//                             session?.Disconnect().Coroutine();
//                             throw;
//                         }
//
//                         return;
//                     }
//
//                     try
//                     {
//                         //从数据库或者缓存中加载出Unit实体及相关组件
//                         (bool isNewPlayer, Unit unit) = await UnitHelper.LoadUnit(player);
//
//                         unit.AddComponent<UnitGateComponent, long>(player.InstanceId);
//
//                         player.ChatUnitInstanceId = await this.EnterWorldChatServer(unit);
//                         player.RoomLobbyInstanceId = GetRoomLobbyInstanceId(unit);
//
//                         await UnitHelper.InitUnit(unit, isNewPlayer);
//                         response.MyUnitId = unit.Id;
//                         reply();
//
//                         StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Game");
//
//                         await TransferHelper.Transfer(unit, startSceneConfig.InstanceId, startSceneConfig.Name);
//
//                         SessionStateComponent sessionStateComponent = session.GetComponent<SessionStateComponent>();
//                         if (sessionStateComponent == null)
//                         {
//                             session.AddComponent<SessionStateComponent>();
//                         }
//                         sessionStateComponent.State = SessionState.Game;
//                         player.PlayerState = PlayerState.Game;
//
//                     }
//                     catch (Exception e)
//                     {
//                         Log.Error($"角色进入游戏逻辑服出现问题 账号ID {player.Account} 角色ID {player.Id} 异常信息 {e.ToString()}");
//                         response.Error = ErrorCode.ERR_EnterGameError;
//                         reply();
//                         await DisconnectHelper.KickPlayer(player, true);
//                         session.Disconnect().Coroutine();
//                         throw;
//                     }
//                 }
//             }
//         }
//
//         private async ETTask<long> EnterWorldChatServer(Unit unit)
//         {
//             StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), "ChatInfo");
//             Chat2G_EnterChat chat2GEnterChat = (Chat2G_EnterChat)await MessageHelper.CallActor(startSceneConfig.InstanceId,
//                 new G2Chat_EnterChat()
//                 {
//                     UnitId = unit.Id,
//                     Name = unit.GetComponent<RoleInfo>().Name,
//                     GateSessionActorId = unit.GetComponent<UnitGateComponent>().GateSessionActorId
//                 });
//             return chat2GEnterChat.ChatInfoUnitInstanceId;
//         }
//
//         private long GetRoomLobbyInstanceId(Unit unit)
//         {
//             StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), "RoomInfo");
//             return startSceneConfig.InstanceId;
//         }
//     }
// }
