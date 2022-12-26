namespace ET
{
    public enum RoleState
    {
        Normal = 1,
        Freeze
    }
    
    [ChildOf(typeof(RoleInfosComponent))]
    public class RoleInfo: Entity, IAwake
    {
        public string Name;
        public int Level;
        public int ServerId;
        public int State;
        public long AccountId;
        public long LastLoginTime;
        public long CreateTime;
    }
}