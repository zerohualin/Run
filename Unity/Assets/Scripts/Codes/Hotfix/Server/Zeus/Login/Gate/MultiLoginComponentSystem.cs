namespace ET.Server
{
    public class MultiLoginComponentAwakeSystem: AwakeSystem<MultiLoginComponent>
    {
        protected override void Awake(MultiLoginComponent self)
        {
            self.Timer_Over = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 20 * 1000, TimerType.MultiLogin, self);
        }
    }

    public class MultiLoginComponentDestroySystem: DestroySystem<MultiLoginComponent>
    {
        protected override void Destroy(MultiLoginComponent self)
        {
            TimerComponent.Instance.Remove(ref self.Timer_Over);
        }
    }

    [Invoke(TimerType.MultiLogin)]
    public class SessionAcceptTimeout: ATimer<MultiLoginComponent>
    {
        protected override void Run(MultiLoginComponent self)
        {
            self.GetParent<GateUser>()?.OfflineWithLock(false).Coroutine();
        }
    }

    public static class MultiLoginComponentSystem
    {
    }
}