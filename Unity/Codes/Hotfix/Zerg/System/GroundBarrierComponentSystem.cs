namespace ET
{
    public class GroundBarrierAwakeSystem: AwakeSystem<GroundBarrierComponent>
    {
        public override void Awake(GroundBarrierComponent self)
        {
            self.GetParent<GridNode>().IsBarrier = true;
        }
    }
}