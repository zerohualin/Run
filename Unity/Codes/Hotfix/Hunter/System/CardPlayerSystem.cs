namespace ET
{
    [FriendClass(typeof (CardPlayer))]
    public static class CardPlayerComponentSystem
    {
        public static void NewTurn(this CardPlayer self)
        {
            self.GetComponent<EnergyComponent>().Full();

            Game.EventSystem.Publish(new EventType.NewTrun() { ZoneScene = self.DomainScene() });
        }
    }

    [ObjectSystem]
    [FriendClass(typeof (LubanComponent))]
    public class CardPlayerAwakeSystem: AwakeSystem<CardPlayer, int>
    {
        public override void Awake(CardPlayer self, int configId)
        {
            self.AddComponent<HandComponent>();
            self.AddComponent<EnergyComponent>();
        }
    }
}