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

        public static bool IsMyTurn(this CardPlayer self)
        {
            return self.DomainScene().GetCardRoom().GetComponent<CardTurnComponent>().Current.Value.Id == self.Id;
        }

        public static bool TryEndMyTurn(this CardPlayer self)
        {
            bool t = false;
            if (self.IsMyTurn())
            {
                self.DomainScene().GetCardRoom().GetComponent<CardTurnComponent>().EndTurn();
                t = true;
            }
            return t;
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