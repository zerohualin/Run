namespace ET.Server
{
    [ObjectSystem]
    [FriendOf(typeof (ET.Server.NpcMgrComponent))]
    public class NpcMgrComponentAwakeSystem: AwakeSystem<NpcMgrComponent>
    {
        protected override void Awake(NpcMgrComponent self)
        {
            UnitComponent unitComponent = self.DomainScene().GetComponent<UnitComponent>();
            int unitConfigId = 1002;
            string mapName = self.DomainScene().Name;
            if (mapName == "Map2")
                unitConfigId = 1003;
            Unit unit = UnitFactory.Create(self.DomainScene(), IdGenerater.Instance.GenerateInstanceId(), UnitType.NPC, 0, unitConfigId);
            unitComponent.Add(unit);
        }
    }
    
    public static class NpcMgrComponentSystem
    {
    
    }
}
