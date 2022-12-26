using ET.Server;

namespace ET
{
    public class GateUserDisconnectComponentAwakeSystem : AwakeSystem<GateUserDisconnectComponent,long>
    {
        protected override void Awake(GateUserDisconnectComponent self, long time)
        {
            self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + time, TimerType.GateUserDisconnect, self);
        }
    }
    
    public class GateUserDisconnectComponentDestroySystem : DestroySystem<GateUserDisconnectComponent>
    {
        protected override void Destroy(GateUserDisconnectComponent self)
        {
            TimerComponent.Instance.Remove(ref self.Timer);
        }
    }

    
    [Invoke(TimerType.GateUserDisconnect)]
    public class GateUserDisconnect_TimerHandler : ATimer<GateUserDisconnectComponent>
    {
        protected override void Run(GateUserDisconnectComponent self)
        {
            self.GetParent<GateUser>().OfflineWithLock().Coroutine();
        }
    }

    public static class GateUserDisconnectComponentSystem
    {
    }
}
