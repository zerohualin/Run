namespace ET
{
    public static class LanHelper
    {
        public static string GetLan(string LanId)
        {
            var lan = LubanComponent.Instance.Tables.TbLanguage.GetById(LanId);
            return lan.ZhName;
        }
    }
}