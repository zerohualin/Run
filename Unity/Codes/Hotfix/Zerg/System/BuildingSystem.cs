using Cfg.zerg;

namespace ET
{
    public class BuildingAwakeSystem: AwakeSystem<Building, int, int, BuildingConfig>
    {
        public override void Awake(Building self, int centerPosX, int centerPosY, BuildingConfig a)
        {
            self.PosX = centerPosX;
            self.PosY = centerPosY;
            self.Config = a;
            Game.EventSystem.Publish(new EventType.InitBuilding() { Building = self });
        }
    }
}