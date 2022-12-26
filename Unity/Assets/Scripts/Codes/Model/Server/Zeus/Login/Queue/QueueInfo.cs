namespace ET.Server
{
    [ChildOf(typeof(QueueMgrComponent))]
    public class QueueInfo: Entity, IAwake, IDestroy
    {
        public long UnitId;
        public long GateActorId;
        public string Account;
        public int Index;
    }

    public struct ProtectInfo
    {
        public long UnitId;
        public long Time;
    }
}