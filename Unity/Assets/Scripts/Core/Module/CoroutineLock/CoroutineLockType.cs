namespace ET
{
    public static class CoroutineLockType
    {
        public const int None = 0;
        public const int Location = 1;                  // location进程上使用
        public const int ActorLocationSender = 2;       // ActorLocationSender中队列消息 
        public const int Mailbox = 3;                   // Mailbox中队列
        public const int UnitId = 4;                    // Map服务器上线下线时使用
        public const int DB = 5;
        public const int Resources = 6;
        public const int ResourcesLoader = 7;
        
        //Zeus
        public const int LoginAccount = 30;
        public const int LoginCenterLock = 31;
        public const int GateLoginLock = 32;
        public const int CreateRole = 33;
        public const int LoginRealm = 34;
        public const int LoginGate = 35;
        public const int LoginZone = 36;
        public const int GateUserLock = 37;
        public const int CheckName = 38;
        
        public const int Max = 100; // 这个必须最大
    }
}