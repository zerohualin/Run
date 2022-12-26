namespace ET.Server
{
    //定时销毁GateUser
    [ComponentOf(typeof(GateUser))]
    public class GateUserDisconnectComponent: Entity, IAwake<long>, IDestroy
    {
        public long Timer;
    }
}