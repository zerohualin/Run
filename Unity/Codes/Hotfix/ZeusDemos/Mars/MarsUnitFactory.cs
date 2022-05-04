using ET.EventType;

namespace ET
{
    [FriendClass(typeof (Unit))]
    public static class MarsUnitFactory
    {
        public static Unit CreateUnit(Room room, long id, int configId)
        {
            UnitComponent unitComponent = room.GetComponent<UnitComponent>();

            Unit unit = unitComponent.AddChildWithId<Unit, int>(id, configId);
            unit.BelongToRoom = room;

            unitComponent.Add(unit);
            
            AfterUnitCreate_CreateGo createGo = new AfterUnitCreate_CreateGo()
            {
                Unit = unit, HeroConfigId = configId,
            };
            Game.EventSystem.Publish(createGo);
            
            return unit;
        }
    }
}