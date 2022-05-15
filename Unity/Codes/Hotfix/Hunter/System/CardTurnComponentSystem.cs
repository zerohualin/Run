namespace ET
{
    [ObjectSystem]
    public class CardTurnComponentAwakeSystem: AwakeSystem<CardTurnComponent>
    {
        public override void Awake(CardTurnComponent self)
        {
            self.Num = 1;
        }
    }

    [FriendClass(typeof (CardTurnComponent))]
    public static class CardTurnComponentSystem
    {
        public static void EndTurn(this CardTurnComponent self)
        {
            self.Num += 1;
            Game.EventSystem.Publish(new EventType.ChangeTrun() { ZoneScene = self.DomainScene() });
        }
    }
}