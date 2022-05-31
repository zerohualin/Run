using Cfg.zerg;

namespace ET
{
    public static class BuildingConfigExtend
    {
        public static int GetFiledX(this BuildingConfig self)
        {
            return self.Size.X + self.Field.X * 2;
        }

        public static int GetFiledY(this BuildingConfig self)
        {
            return self.Size.Y + self.Field.Y * 2;
        }
    }
}