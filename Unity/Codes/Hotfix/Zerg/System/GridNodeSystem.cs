using Cfg.zerg;

namespace ET
{
    public class GridNodeAwakeSystem: AwakeSystem<GridNode, int, int>
    {
        public override void Awake(GridNode self, int x, int y)
        {
            self.x = x;
            self.y = y;
        }
    }

    public static class GridNodeSystem
    {
        public static bool IsEmpty(this GridNode self)
        {
            return self.IsBuilded;
        }
        public static bool CanBuild(this GridNode self, CardConfig config)
        {
            switch (config.RequireGroundType)
            {
                case GroundType.Empty:
                    if (self.IsBuilded || self.IsMineral || self.IsBarrier)
                        return false;
                    return true;
                    break;
                case GroundType.Mineral:
                    if (self.IsMineral && !self.IsBuilded)
                        return true;
                    return false;
                    break;
            }
            return false;
        }

    }
}