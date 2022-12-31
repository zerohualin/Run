namespace ET.Server
{
    [ObjectSystem]
    [FriendOf(typeof (ET.Server.NpcMgrComponent))]
    public class NpcMgrComponentAwakeSystem: AwakeSystem<NpcMgrComponent>
    {
        protected override void Awake(NpcMgrComponent self)
        {
            UnitComponent unitComponent = self.DomainScene().GetComponent<UnitComponent>();
            Unit unit = UnitFactory.Create(self.DomainScene(), IdGenerater.Instance.GenerateInstanceId(), UnitType.NPC);
            unitComponent.Add(unit);
        }
    }
    
    public static class NpcMgrComponentSystem
    {
    
    }
}
