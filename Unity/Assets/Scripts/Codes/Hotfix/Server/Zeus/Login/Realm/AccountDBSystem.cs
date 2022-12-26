namespace ET.Server
{
    [ObjectSystem]
    public class AccountDBSystem : DestroySystem<AccountDB>
    {
        protected override void Destroy(AccountDB self)
        {
            self.Account = null;
            self.Password = null;
        }
    }
}
