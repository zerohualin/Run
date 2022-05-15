namespace ET
{
    [ObjectSystem]
    public class HandComponentAwakeSystem: AwakeSystem<HandComponent>
    {
        public override void Awake(HandComponent self)
        {
            self.AddCard(1);
            self.AddCard(2);
            self.AddCard(3);
        }
    }

    [FriendClass(typeof(HandComponent))]
    public static class HandComponentSystem
    {
        public static void AddCard(this HandComponent self, int cardConfigId)
        {
            var card = self.AddChild<Card, int>(cardConfigId);
            self.AddCard(card);
        }
        
        public static void AddCard(this HandComponent self, Card card)
        {
            self.Cards.Add(card);
        }

        public static void RemoveCard(this HandComponent self, Card card)
        {
            self.Cards.Remove(card);
        }
    }
}