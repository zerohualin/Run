namespace ET
{
    [ObjectSystem]
    [FriendClass(typeof (CardPlayerComponent))]
    public class CardTurnComponentAwakeSystem: AwakeSystem<CardTurnComponent>
    {
        public override void Awake(CardTurnComponent self)
        {
            self.Num = 1;
            var PlayerComponent = self.Parent.GetComponent<CardPlayerComponent>();
            self.CardPlayers.AddLast(PlayerComponent.CardPlayerA);
            self.CardPlayers.AddLast(PlayerComponent.CardPlayerB);
            self.Current = self.CardPlayers.First;
            self.Current.Value.NewTurn();
        }
    }

    [FriendClass(typeof (CardTurnComponent))]
    public static class CardTurnComponentSystem
    {
        public static void EndTurn(this CardTurnComponent self)
        {
            self.Num += 1;
            self.Current = self.Current.Next;
            if (self.Current == null)
            {
                self.Current = self.CardPlayers.First;
            }

            self.Current.Value.NewTurn();
            Game.EventSystem.Publish(new EventType.ChangeTrun() { ZoneScene = self.DomainScene() });
        }
    }
}