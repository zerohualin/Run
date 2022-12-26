namespace ET
{
    public enum ServerStatus
    {
        Active = 0,
        Close = 1
    }
    
    [ChildOf(typeof(ServerInfosComponent))]
    public class ServerInfo : Entity, IAwake
    {
        public int Zone;
        public int Status;
        public string Name;
    }
}