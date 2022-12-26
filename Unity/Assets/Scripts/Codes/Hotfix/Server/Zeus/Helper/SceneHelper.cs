using System.Linq;

namespace ET
{
    // [FriendOf(typeof(ET.SessionPlayerComponent))]
    public static partial class SceneHelper2
    {
        public static StartSceneConfig GetGateConfig(int zone, string account)
        {
            var zoneStartSceneConfigs = StartSceneConfigCategory.Instance.Gates[zone];
            int mode = account.Mode(zoneStartSceneConfigs.Count);
            return zoneStartSceneConfigs[mode];
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