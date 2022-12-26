namespace ET.Client
{
    [FriendOf(typeof(ServerInfosComponent))]
    [FriendOf(typeof(Scene))]
    [FriendOf(typeof(AccountInfoComponent))]
    public static class SessionHelper
    {
        public static async ETTask<IResponse> SeesionCall(this Scene self, IRequest request)
        {
            return await self.GetComponent<SessionComponent>().Session.Call(request);
        }

        public static string GetToken(this Scene self)
        {
            return self.GetComponent<AccountInfoComponent>().Token;
        }
        
        public static long GetAccountId(this Scene self)
        {
            return self.GetComponent<AccountInfoComponent>().AccountId;
        }
        
        public static int GetServerId(this Scene self)
        {
            return self.GetComponent<ServerInfosComponent>().CureentServerId;
        }
    }
}