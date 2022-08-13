namespace ET
{
    [FriendOf(typeof(LubanComponent))]
    public static class ConfigUtil
    {
        public static Cfg.Tables Tables => LubanComponent.Instance.Tables;
    }
}