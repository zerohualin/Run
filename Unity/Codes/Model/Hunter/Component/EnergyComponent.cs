namespace ET
{
    public class EnergyComponent: Entity, IAwake
    {
        public int Current; //当前值
        public int Max; //当前最大
        public int Limit; //最大上限
    }
}