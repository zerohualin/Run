using System;
using Unity.Mathematics;

namespace ET.Server
{
    public static class UnitFactory
    {
        public static Unit Create(Scene scene, long id, UnitType unitType, long gateId = 0, int unitConfgiId = 1001)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    Unit unit = unitComponent.AddChildWithId<Unit, int>(id, unitConfgiId);
                    // unit.AddComponent<UnitGateComponent, long>(gateId);
                    unit.AddComponent<MoveComponent>();
                    unit.Position = new float3(-10, 0, -10);
                    
                    unit.AddComponent<MailBoxComponent>();
                    unit.AddLocation(LocationType.Unit).Coroutine();

                    NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
                    numericComponent.Set(NumericType.Speed, 6f); // 速度是6米每秒
                    numericComponent.Set(NumericType.AOI, 15000); // 视野15米

                    unitComponent.Add(unit);
                    // 加入aoi
                    // unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
                    return unit;
                }

                case UnitType.NPC:
                {
                    Unit unit = unitComponent.AddChildWithId<Unit, int>(id, unitConfgiId);
                    unit.AddComponent<MoveComponent>();
                    unit.Position = new float3(-10, 0, 0);
                    
                    unit.AddComponent<MailBoxComponent>();
                    unit.AddLocation(LocationType.Unit).Coroutine();

                    NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
                    numericComponent.Set(NumericType.Speed, 6f); // 速度是6米每秒
                    numericComponent.Set(NumericType.AOI, 15000); // 视野15米

                    unitComponent.Add(unit);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
                    return unit;
                }
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }
    }
}