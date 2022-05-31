using Cfg.zerg;

namespace ET
{
    public partial class BuildingData : Entity, IAwake, IAwake<int>, IAwake<string>
    {
        public BuildingConfig Config;
        public bool canUse = false;
    }
}