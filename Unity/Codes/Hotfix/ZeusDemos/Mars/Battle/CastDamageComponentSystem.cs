namespace ET
{
    [ObjectSystem]
    public class CastDamageComponentAwakeSystem: AwakeSystem<CastDamageComponent>
    {
        public override void Awake(CastDamageComponent self)
        {
        }
    }

    [ObjectSystem]
    public class CastDamageComponentUpdateSystem: UpdateSystem<CastDamageComponent>
    {
        public override void Update(CastDamageComponent self)
        {
        }
    }

    [ObjectSystem]
    public class CastDamageComponentFixedUpdateSystem: LateUpdateSystem<CastDamageComponent>
    {
        public override void LateUpdate(CastDamageComponent self)
        {
        }
    }

    [ObjectSystem]
    public class CastDamageComponentDestroySystem: DestroySystem<CastDamageComponent>
    {
        public override void Destroy(CastDamageComponent self)
        {
        }
    }
    
    [FriendClass(typeof(CastDamageComponent))]
    public static class CastDamageComponentSystem
    {
        /// <summary>
        /// 洗礼这个伤害值
        /// </summary>
        /// <param name="damageData">伤害数据</param>
        /// <returns></returns>
        public static float BaptismDamageData(this CastDamageComponent self, DamageData damageData)
        {
            DataModifierComponent dataModifierComponent = self.GetParent<Unit>().GetComponent<DataModifierComponent>();

            if ((damageData.BuffDamageTypes & BuffDamageTypes.Physical) == BuffDamageTypes.Physical)
            {
                damageData.DamageValue = dataModifierComponent.BaptismData(self.CastPhysicalType, damageData.DamageValue);
            }

            if ((damageData.BuffDamageTypes & BuffDamageTypes.Magic) == BuffDamageTypes.Magic)
            {
                damageData.DamageValue = dataModifierComponent.BaptismData(self.CastMagicType, damageData.DamageValue);
            }

            if ((damageData.BuffDamageTypes & BuffDamageTypes.Single) == BuffDamageTypes.Single)
            {
                damageData.DamageValue = dataModifierComponent.BaptismData(self.CastSingleType, damageData.DamageValue);
            }

            if ((damageData.BuffDamageTypes & BuffDamageTypes.Range) == BuffDamageTypes.Range)
            {
                damageData.DamageValue = dataModifierComponent.BaptismData(self.CastRangeType, damageData.DamageValue);
            }

            damageData.OperateCaster = self.GetParent<Unit>();
            damageData.DamageValue = dataModifierComponent.BaptismData(self.CastAllType, damageData.DamageValue);
            return damageData.DamageValue < 0? 0 : damageData.DamageValue;
        }

    }
}