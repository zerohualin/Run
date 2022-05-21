namespace ET
{
    [ObjectSystem]
    [FriendClass(typeof (CardPlayerComponent))]
    [ChildType(typeof (CardPlayer))]
    public class CardPlayerComponentAwakeSystem: AwakeSystem<CardPlayerComponent>
    {
        public override void Awake(CardPlayerComponent self)
        {
            self.CardPlayerA = self.AddChild<CardPlayer, int>(1);
            self.CardPlayerB = self.AddChild<CardPlayer, int>(2);
            self.CardPlayerB.AddComponent<AIComponent, int>(3);
        }
    }
}