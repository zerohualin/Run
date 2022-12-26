namespace ET.Server
{
    [ObjectSystem]
    public class GateUserMgrComponentDestroySystem: DestroySystem<GateUserMgrComponent>
    {
        protected override void Destroy(GateUserMgrComponent self)
        {
            self.Users.Clear();
        }
    }

    [ObjectSystem]
    public class GateUserMgrComponentAwakeSystem: AwakeSystem<GateUserMgrComponent>
    {
        protected override void Awake(GateUserMgrComponent self)
        {
        }
    }

    [FriendOfAttribute(typeof (ET.Server.GateUserMgrComponent))]
    [FriendOfAttribute(typeof (ET.Server.AccountZoneDB))]
    public static class GateUserMgrComponentSystem
    {
        public static GateUser Get(this GateUserMgrComponent self, string account)
        {
            self.Users.TryGetValue(account, out GateUser gateUser);
            return gateUser;
        }

        public static GateUser Create(this GateUserMgrComponent self, string account, int zone)
        {
            GateUser gateUser = self.AddChild<GateUser>();

            AccountZoneDB accountZoneDB = gateUser.AddComponent<AccountZoneDB>();
            accountZoneDB.Account = account;
            accountZoneDB.LoginZoneId = zone;
            gateUser.AddComponent<MailBoxComponent, MailboxType>(MailboxType.GateSession);

            self.GetDirectDB().Save(accountZoneDB).Coroutine();

            self.Users.Add(account, gateUser);

            return gateUser;
        }

        public static GateUser Create(this GateUserMgrComponent self, AccountZoneDB accountZoneDB)
        {
            GateUser gateUser = self.AddChild<GateUser>();

            gateUser.AddComponent(accountZoneDB);

            gateUser.AddComponent<MailBoxComponent, MailboxType>(MailboxType.GateSession);

            self.Users.Add(accountZoneDB.Account, gateUser);

            return gateUser;
        }

        public static void Remove(this GateUserMgrComponent self, string account)
        {
            GateUser gateUser = self.Get(account);
            if (gateUser == null)
                return;
            self.Users.Remove(account);
            gateUser.Dispose();
        }
    }
}