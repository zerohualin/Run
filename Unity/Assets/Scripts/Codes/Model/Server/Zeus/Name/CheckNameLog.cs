namespace ET
{
    [ChildOf(typeof(TempComponent))]
    public class CheckNameLog : Entity, IAwake, IDestroy
    {
        public string Name;
        public long UnitId;
        public long CreateTime;
    }
}