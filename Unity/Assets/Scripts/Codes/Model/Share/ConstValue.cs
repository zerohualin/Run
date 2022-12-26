namespace ET
{
    public static partial class ConstValue
    {
        [StaticField]
        public static string RouterHttpHost = "127.0.0.1";
        [StaticField]
        public static int RouterHttpPort = 30300;
        public const int SessionTimeoutTime = 30 * 1000;
    }
}