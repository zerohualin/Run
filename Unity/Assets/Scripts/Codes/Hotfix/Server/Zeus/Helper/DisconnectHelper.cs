namespace ET.Server
{
    public static class DisconnectHelper
    {
        // public static async ETTask KickPlayer(Player player, bool IsException = false)
        // {
        //     if (player == null || player.IsDisposed)
        //     {
        //         return;
        //     }
        //
        //     long instanceId = player.InstanceId;
        //     using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, player.AccountId.GetHashCode()))
        //     {
        //         if (player.IsDisposed || instanceId != player.InstanceId)
        //         {
        //             return;
        //         }
        //
        //         //如果是正常的踢下线，需要通知游戏逻辑服把玩家踢出
        //         if (!IsException)
        //         {
        //             switch (player.PlayerState)
        //             {
        //                 case PlayerState.Disconnect:
        //                     break;
        //                 case PlayerState.Gate:
        //                     break;
        //                 case PlayerState.Game:
        //                     //通知游戏逻辑服下线Unit逻辑，并将数据存入数据库
        //                     var m2GRequestExitGame = (M2G_RequestExitGame) await MessageHelper.CallLocationActor(player.Id, new G2M_RequestExitGame());
        //                     
        //                     //通知聊天服下线聊天Unit
        //                     var chat2GRequestExitChat =
        //                             (Chat2G_ResponseExitChat)await MessageHelper.CallActor(player.ChatUnitInstanceId, new G2Chat_RequestExitChat());
        //                     
        //                     //通知移除账号角色登录信息
        //                     long LoginCenterConfigSceneId = StartSceneConfigCategory.Instance.LoginCenterConfig.InstanceId;
        //                     var l2G_RemoveLoginRecord =
        //                             (L2G_RemoveLoginRecord)await MessageHelper.CallActor(LoginCenterConfigSceneId, 
        //                                 new G2L_RemoveLoginRecord() { AccountId = player.AccountId,ServerId = player.DomainZone()});
        //                     break;
        //             }
        //         }
        //
        //         player.PlayerState = PlayerState.Disconnect;
        //         player.DomainScene().GetComponent<PlayerComponent>()?.Remove(player.AccountId);
        //         player?.Dispose();
        //         //防止player身上的组件会有异步的情况？？？
        //         await TimerComponent.Instance.WaitAsync(300);
        //     }
        // }
    }
}