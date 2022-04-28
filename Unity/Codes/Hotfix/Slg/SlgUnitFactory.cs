namespace ET
{
    public static class SlgUnitFactory
    {
        // public static Unit Create(SlgComponent slgCom, SlgUnitData data = null)
        // {
        //     UnitComponent unitComponent = slgCom.GetComponent<UnitComponent>();
        //     
        //
        //     unit.AddComponent<MoveComponent>();
        //     NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
        //     for (int i = 0; i < unitInfo.Ks.Count; ++i)
        //     {
        //         numericComponent.Set((NumericType)unitInfo.Ks[i], unitInfo.Vs[i]);
        //     }
        //
        //     return unit;
        // }

        public static void Create(SlgComponent slgCom, int x, int y)
        {
            var slgUnit = slgCom.Nodes[x][y].AddComponent<SlgUnit>();
            slgCom.GetComponent<SlgUnitComponent>().Add(slgUnit);
        }
    }
}