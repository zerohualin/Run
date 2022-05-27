using Cfg.zerg;

namespace ET
{
    public class BuildingAwakeSystem: AwakeSystem<Building, int, int, CardConfig>
    {
        public override void Awake(Building self, int centerPosX, int centerPosZ, CardConfig a)
        {
            self.PosX = centerPosX;
            self.PosZ = centerPosZ;
            self.Config = a;
            Game.EventSystem.Publish(new EventType.InitBuilding() { Building = self });
        }
    }
}