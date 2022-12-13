namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class LubanComponent: Entity, IAwake, IDestroy
    {
        [StaticField]
        public static LubanComponent Instance;
        public Cfg.Tables Tables;
    }
}