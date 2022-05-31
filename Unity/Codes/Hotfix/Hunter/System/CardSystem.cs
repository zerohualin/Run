namespace ET
{
    [ObjectSystem]
    [FriendClass(typeof (LubanComponent))]
    public class CardAwakeSystem: AwakeSystem<BuildingData, string>
    {
        public override void Awake(BuildingData self, string configId)
        {
            self.Config = Game.Scene.GetComponent<LubanComponent>().Tables.TbBuilding.Get(configId);
        }
    }

    [FriendClass(typeof (BuildingData))]
    public static class CardSystem
    {
        public static bool CanUse(this BuildingData self)
        {
            EnergyComponent EnergyComponent = self.GetParent<HandComponent>().Parent.GetComponent<EnergyComponent>();
            var haveEnergy = EnergyComponent.CheckCast(1);
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