namespace ET.Server
{
    [ObjectSystem]
    public class ServerInfoManagerComponentAwakeSystem : AwakeSystem<ServerInfosComponent>
    {
        protected override void Awake(ServerInfosComponent self)
        {
            
        }
    }

    [ObjectSystem]
    public class ServerInfoManagerComponentDestroySystem : DestroySystem<ServerInfosComponent>
    {
        protected override void Destroy(ServerInfosComponent self)
        {
        }
    }

    [ObjectSystem]
    public class ServerInfoManagerComponentLoadSystem : LoadSystem<ServerInfosComponent>
    {
        protected override void Load(ServerInfosComponent self)
        {
            
        }
    }
    [FriendOf(typeof(ET.ServerInfosComponent))]
    [FriendOf(typeof(ET.ServerInfo))]
    public static class ServerInfoManagerComponentSystem
    {
        public static async ETTask Awake(this ServerInfosComponent self)
        {
            var DBComponent = self.GetDirectDB();

            var serverInfoList = await DBComponent.Query<ServerInfo>(d => true);

            // if (serverInfoList == null || serverInfoList.Count <= 0)
            // {
            //     Log.Error("serverinfo count is zero");
            //     self.ServerInfos.Clear();
            //     var serverInfoConfigs = ServerInfoConfigCategory.Instance.GetAll();
            //     foreach (var info in serverInfoConfigs.Values)
            //     {
            //         ServerInfo newServerInfo = self.AddChildWithId<ServerInfo>(info.Id);
            //         newServerInfo.ServerName = info.ServerName;
            //         newServerInfo.Status = (int)ServerStatus.Normal;
            //         self.ServerInfos.Add(newServerInfo);
            //         await DBComponent.Save(newServerInfo);
            //     }
            //     return;
            // }
            // self.ServerInfos.Clear();
            // foreach (var serverInfo in serverInfoList)
            // {
            //     self.AddChild(serverInfo);
            //     self.ServerInfos.Add(serverInfo);
            // }
        }
    }
}