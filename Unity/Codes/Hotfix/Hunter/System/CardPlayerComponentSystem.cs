namespace ET
{
    [ObjectSystem]
    public class CardPlayerComponentAwakeSystem: AwakeSystem<CardPlayerComponent>
    {
        public override void Awake(CardPlayerComponent self)
        {
        }
    }
    
    [FriendClass(typeof(CardPlayerComponent))]
    public static class CardPlayerComponentSystem
    {
        public static void AddUnit(this CardPlayerComponent self, CardUnit unit)
        {
            self.CardUnits.Add(unit.Id, unit);
        }
    }
}