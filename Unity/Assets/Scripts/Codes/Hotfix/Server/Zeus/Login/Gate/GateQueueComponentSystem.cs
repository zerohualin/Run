namespace ET.Server
{
    public class GateQueueComponentAwakeSystem : AwakeSystem<GateQueueComponent>
    {
        protected override void Awake(GateQueueComponent self)
        {
        }
    }
    
    public class GateQueueComponentDestroySystem : DestroySystem<GateQueueComponent>
    {
        protected override void Destroy(GateQueueComponent self)
        {
            self.UnitId = default;
            self.Index = default;
            self.Count = default;
        }
    }

    public static class GateQueueComponentSystem
    {
    
    }
}
