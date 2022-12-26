namespace ET.Server
{
    [ComponentOf(typeof(Session))]
    public class RealmAccountComponent : Entity,IAwake,IDestroy
    {
        public AccountDB AccountDB;
    }
}
