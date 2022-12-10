namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public static class IFGUIComponentSystem
    {
        public static string GetAddressablePath(this IFGUIComponent self)
        {
            return self.UIPackageName;
        }

        public static string GetPackageName(this IFGUIComponent self)
        {
            return self.UIPackageName;
        }

        public static string GetComponentName(this IFGUIComponent self)
        {
            return self.UIResName;
        }
    }
}