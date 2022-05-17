using System;

namespace ET
{
    [ObjectSystem]
    public class EnergyComponentAwakeSystem: AwakeSystem<EnergyComponent>
    {
        public override void Awake(EnergyComponent self)
        {
            self.Max = 10;
            self.Current = self.Max;
            self.Limit = self.Max;
        }
    }

    [FriendClass(typeof (EnergyComponent))]
    public static class EnergyComponentSystem
    {
        public static void AddEnergy(this EnergyComponent self, int add)
        {
            self.Current = self.Current + add;
            self.Current = Math.Min(self.Current, self.Max);
            Game.EventSystem.Publish(new EventType.ChangeEnergy());
        }

        public static bool CheckCast(this EnergyComponent self, int cost)
        {
            return self.Current >= cost;
        }

        public static void Cast(this EnergyComponent self, int cost)
        {
            self.Current = self.Current - cost;
            self.Current = Math.Max(0, self.Current);
            Game.EventSystem.Publish(new EventType.ChangeEnergy() { ZoneScene = self.DomainScene() });
        }
    }
}