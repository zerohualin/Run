namespace ET
{
    [FriendClass(typeof (Unit))]
    [FriendClass(typeof (CardUnitManagerComponent))]
    public static class CardUnitFactory
    {
        public static CardUnit CreateUnit(Scene ZoneScene ,int configId)
        {
            var unitComponent = ZoneScene.GetCardRoom().GetComponent<CardUnitManagerComponent>();
            CardUnit unit = unitComponent.AddChildWithId<CardUnit, int>(IdGenerater.Instance.GenerateUnitId(0), configId);
            return unit;
        }
    }
}