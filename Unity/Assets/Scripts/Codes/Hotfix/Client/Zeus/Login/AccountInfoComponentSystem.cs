namespace ET.Client
{
    public class AccountInfoComponentDestorySystem : DestroySystem<AccountInfoComponent>
    { 
        protected override void Destroy(AccountInfoComponent self)
        {
            self.Token = string.Empty;
            self.AccountId = 0;
        }
    }

    public static class AccountInfoComponentSystem
    {
    }
}