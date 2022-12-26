namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class LubanComponent: Singleton<LubanComponent>, IAwake, IDestroy
    {
        public Cfg.Tables Tables;
    }
}