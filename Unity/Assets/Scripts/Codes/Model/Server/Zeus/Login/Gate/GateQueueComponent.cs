namespace ET.Server
{
    [ComponentOf(typeof(GateUser))]
    public class GateQueueComponent: Entity, IAwake, IDestroy
    {
        public long UnitId;
        public int Index;
        public int Count;
    }
}