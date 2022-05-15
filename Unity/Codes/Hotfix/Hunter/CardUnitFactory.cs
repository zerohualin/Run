namespace ET
{
    [FriendClass(typeof (Unit))]
    [FriendClass(typeof (CardUnitManagerComponent))]
    public static class CardUnitFactory
    {
        public static CardUnit CreateUnit(Room room, long id, int configId)
        {
            CardUnitManagerComponent unitComponent = room.GetComponent<CardUnitManagerComponent>();
            CardUnit unit = unitComponent.AddChildWithId<CardUnit, int>(id, configId);
            return unit;
        }
    }
}