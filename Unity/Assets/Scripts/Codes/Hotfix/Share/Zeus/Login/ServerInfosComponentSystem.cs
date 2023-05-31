namespace ET
{
    [ObjectSystem]
    public class ServerInfosComponentDestroySystem: DestroySystem<ServerInfosComponent>
    {
        protected override void Destroy(ServerInfosComponent self)
        {
            foreach (var serverInfo in self.ServerInfos)
            {
                serverInfo?.Dispose();
            }
            self.ServerInfos.Clear();
        }
    }
    
    [FriendOf(typeof(ET.ServerInfosComponent))]
    public static class ServerInfosComponentSystem
    {
        public static void Add(this ServerInfosComponent self, ServerInfoProto serverInfoProto)
        {
            ServerInfo serverInfo = self.AddChild<ServerInfo>();
            serverInfo.FromMessage(serverInfoProto);
            self.ServerInfos.Add(serverInfo);
        }
        
        public static void Clear(this ServerInfosComponent self)
        {
            foreach (var serverInfo in self.ServerInfos)
            {
                serverInfo?.Dispose();
            }
            self.ServerInfos.Clear();
        }
    }
}