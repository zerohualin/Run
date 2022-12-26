using ET.Server;

namespace ET.Server
{
    [ComponentOf(typeof (Session))]
    public class SessionUserComponent: Entity, IAwake<long>, IDestroy
    {
        public long GateUserInstanceId;
        public GateUser User => Root.Instance.Get(this.GateUserInstanceId) as GateUser;
    }
}