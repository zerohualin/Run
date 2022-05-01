namespace ET
{
    public class LubanComponent: Entity, IAwake, IDestroy
    {
        public static LubanComponent Instance;
        public Cfg.Tables Tables;
    }
}