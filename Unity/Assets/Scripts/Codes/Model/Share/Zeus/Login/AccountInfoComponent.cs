namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class AccountInfoComponent : Entity, IDestroy, IAwake
    {
        public string Token;
        public long AccountId;
        public string RealmKey;
        public string RealmAddress;
        
        public string GateAddress;
        public long GateKey;
    }
}
