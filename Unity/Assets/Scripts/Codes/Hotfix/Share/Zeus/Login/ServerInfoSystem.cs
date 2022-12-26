namespace ET
{
    [ObjectSystem]
    public class ServerInfoAwakeSystem : AwakeSystem<ServerInfo>
    {
        protected override void Awake(ServerInfo self)
        {
        }
    }
    
    [FriendOf(typeof(ET.ServerInfo))]
    public static class ServerInfoSystem
    {
        public static void FromMessage(this ServerInfo self, ServerInfoProto serverInfoProto)
        {
            self.Status = serverInfoProto.Status;
            self.Name = serverInfoProto.Name;
            self.Zone = serverInfoProto.Zone;
        }

        public static ServerInfoProto ToMessage(this ServerInfo self)
        {
            return new ServerInfoProto() { Status = self.Status, Name = self.Name, Zone = self.Zone};
        }
    }
}