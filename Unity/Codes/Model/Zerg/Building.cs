using Cfg.zerg;

namespace ET
{
    public class Building : Entity, IAwake, IAwake<BuildingConfig>, IAwake<int, int, BuildingConfig>
    {
        public BuildingConfig Config;

        public int PosX;
        public int PosY;
    }
}