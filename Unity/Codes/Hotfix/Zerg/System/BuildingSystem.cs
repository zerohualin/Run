using Cfg.zerg;

namespace ET
{
    public class BuildingAwakeSystem: AwakeSystem<Building, int, int, CardConfig>
    {
        public override void Awake(Building self, int centerPosX, int centerPosY, CardConfig a)
        {
            self.PosX = centerPosX;
            self.PosY = centerPosY;
            self.Config = a;
            Game.EventSystem.Publish(new EventType.InitBuilding() { Building = self });
        }
    }
}