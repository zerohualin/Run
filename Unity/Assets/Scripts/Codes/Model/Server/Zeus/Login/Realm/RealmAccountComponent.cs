namespace ET.Server
{
    [ComponentOf(typeof(Session))]
    public class RealmAccountComponent : Entity,IAwake,IDestroy
    {
        public long accountDbId;
        public AccountDB AccountDB
        {
            get
            {
                return GetChild<AccountDB>(accountDbId);
            }
            set
            {
                if(value == null)
                    return;
                this.accountDbId = value.Id;
            }
        }
    }
}
