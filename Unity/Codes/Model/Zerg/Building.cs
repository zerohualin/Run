using Cfg.zerg;

namespace ET
{
    public class Building : Entity, IAwake, IAwake<CardConfig>, IAwake<int, int, CardConfig>
    {
        public CardConfig Config;

        public int PosX;
        public int PosY;
    }
}