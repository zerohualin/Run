using Cfg.hunter;

namespace ET
{
    public partial class Card : Entity, IAwake, IAwake<int>
    {
        public CardConfig Config;
        public bool CanUse = false;
    }
}