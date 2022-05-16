namespace ET
{
    [FriendClass(typeof(CardPlayer))]
    public static class CardPlayerComponentSystem
    {
        public static void AddUnit(this CardPlayer self, CardUnit unit)
        {
            self.CardUnits.Add(unit.Id, unit);
        }
    }
}