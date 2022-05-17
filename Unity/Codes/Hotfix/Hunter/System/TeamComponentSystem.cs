namespace ET
{
    [FriendClass(typeof (TeamComponent))]
    public static class TeamComponentSystem
    {
        public static void AddUnit(this TeamComponent self, CardUnit unit)
        {
            self.CardUnitIds.Add(unit.Id);
        }
    }
}