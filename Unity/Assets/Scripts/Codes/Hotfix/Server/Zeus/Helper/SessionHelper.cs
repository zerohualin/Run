using System;

namespace ET.Server
{
    // [FriendOf(typeof(ET.SessionPlayerComponent))]
    public static class SessionHelper
    {
        public static bool CheckSceneType(this Session self, SceneType sceneType)
        {
            var isRight = self.DomainScene().SceneType == sceneType;
            if (!isRight)
            {
                Log.Error($"请求的Scene错误，当前Scene为：{self.DomainScene().SceneType}");
                self.Dispose();
            }

            return isRight;
        }

        public static (int, AccountZoneDB) CheckAccountZoneDB(this Session self)
        {
            GateUser gateUser = self.GetComponent<SessionUserComponent>()?.User;
            if (gateUser == null)
            {
                return (ErrorCode.ERR_Login_NoGateUser, null);
            }

            GateUser user = self.GetComponent<SessionUserComponent>().User;
            AccountZoneDB accountZoneDB = user.GetComponent<AccountZoneDB>();
            if (accountZoneDB == null)
            {
                return (ErrorCode.ERR_Login_NoneAccountZone, null);
            }

            return (ErrorCode.ERR_Success, accountZoneDB);
        }

        public static async ETTask Disconnect(this Session self)
        {
            if (self == null || self.IsDisposed)
            {
                return;
            }

            long instanceId = self.InstanceId;
            await TimerComponent.Instance.WaitAsync(1000);
            if (self.InstanceId != instanceId)
            {
                return;
            }

            self.Dispose();
        }

        // public static bool CheckToken(this Session self, long accountId, string token)
        // {
        //     var getToken = self.DomainScene().GetComponent<TokenComponent>().Get(accountId);
        //     return getToken == token;
        // }
        //
        // public static void DispatercherActorMessageBySceneName(this Session session, string SceneName, IActorMessage message)
        // {
        //     long rankInstanceId = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), SceneName).InstanceId;
        //     ActorMessageSenderComponent.Instance.Send(rankInstanceId, message);
        // }
        //
        // public static async ETTask DispatercherActorRequestBySceneName(this Session session, string SceneName, IActorRequest request)
        // {
        //     long rankInstanceId = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), SceneName).InstanceId;
        //     int rpcId = request.RpcId;
        //     long instanceId = session.InstanceId;
        //     IResponse response = await ActorMessageSenderComponent.Instance.Call(rankInstanceId, request);
        //     request.RpcId = rpcId;
        //     if (session.InstanceId == instanceId)
        //         session.Reply(response);
        // }
        //
        // public static async ETTask DispatercherActorRequestByInstanceId(this Session session, long TargetInstanceId, IActorRequest request)
        // {
        //     int rpcId = request.RpcId;
        //     long instanceId = session.InstanceId;
        //     IResponse response = await ActorMessageSenderComponent.Instance.Call(TargetInstanceId, request);
        //     request.RpcId = rpcId;
        //     if (session.InstanceId == instanceId)
        //         session.Reply(response);
        // }
        //
        // public static Player GetPlayer(this Session self)
        // {
        //     Player player = Game.EventSystem.Get(self.GetComponent<SessionPlayerComponent>().PlayerInstanceId) as Player;
        //     if (player == null || player.IsDisposed || player.ChatUnitInstanceId == 0)
        //     {
        //         return null;
        //     }
        //     return player;
        // }
    }
}