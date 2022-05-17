namespace ET
{
    [ObjectSystem]
    [FriendClass(typeof (LubanComponent))]
    public class CardAwakeSystem: AwakeSystem<Card, int>
    {
        public override void Awake(Card self, int configId)
        {
            self.Config = Game.Scene.GetComponent<LubanComponent>().Tables.TbCardConfig.Get(configId);
        }
    }

    [FriendClass(typeof (Card))]
    public static class CardSystem
    {
        public static bool CanUse(this Card self)
        {
            EnergyComponent EnergyComponent = self.GetParent<HandComponent>().Parent.GetComponent<EnergyComponent>();
            var haveEnergy = EnergyComponent.CheckCast(self.Config.Cost);
            if (!haveEnergy)
            {
                self.canUse = false;
            }
            else
            {
                self.canUse = true;
            }

            return self.canUse;
        }
    }
}