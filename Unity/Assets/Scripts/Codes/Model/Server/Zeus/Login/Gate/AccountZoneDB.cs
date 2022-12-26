namespace ET.Server
{
    [ComponentOf(typeof (GateUser))]
    public class AccountZoneDB: Entity, IAwake, IDestroy
    {
        public string Account; //账户名
        public int LoginZoneId;

        public long LastRoleId;
    }
}