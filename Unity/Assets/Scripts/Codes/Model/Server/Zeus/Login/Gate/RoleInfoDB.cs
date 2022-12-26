namespace ET.Server
{
    [ChildOf(typeof(AccountZoneDB))]
    public class RoleInfoDB: Entity, IAwake, IDestroy
    {
        //角色可以转账号 和 区服Id
        public string Account;
        public long AccountZoneId;
        public bool IsDeleted;
        public string Name;
        public int Level;
        public int LogicZoneId;
    }
}