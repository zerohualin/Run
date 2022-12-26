namespace ET.Server
{
    public enum GateUserState
    {
        InGate = 1,
        InQueue = 2,
        InMap = 3
    }

    [ChildOf(typeof (GateUserMgrComponent))]
    public class GateUser: Entity, IAwake, IDestroy
    {
        public long SessionInstanceId;
        public Session Session => Root.Instance.Get(this.SessionInstanceId) as Session;
        public GateUserState State = GateUserState.InGate; // 记录GateUser的状态
    }
}