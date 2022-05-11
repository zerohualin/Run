namespace ET
{
    [ObjectSystem]
    public class StackFsmComponentAwakeSystem: AwakeSystem<StackFsmComponent>
    {
        public override void Awake(StackFsmComponent self)
        {
            self.ChangeState<IdleState>(StateTypes.Idle, "Idle", 1);
        }
    }
}