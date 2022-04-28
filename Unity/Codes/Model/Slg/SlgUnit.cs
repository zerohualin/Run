namespace ET
{
    public enum UnitTeam
    {
        A = 0,
        B = 1
    }

    public class SlgUnitData
    {
        public int ConfigId;
        public int MoveRange = 5;
        public UnitTeam Team = UnitTeam.A;
        public int X;
        public int Y;
        public int Hp;
        public int Atk;
        public int ActionNum = 0;
    }

    public class SlgUnit : Entity, ISerializeToEntity, IAwake, IAwake<SlgData>, IAwake<SlgUnitData>, IAwake<int, int, UnitTeam>, IDeserialize, IAwake<int, int, int>
    {
        public SlgUnitData Data;

        public SlgUnitConfig SlgUnitConfig;

        public int MoveRange
        {
            get { return Data.MoveRange; }
        }

        public UnitTeam Team
        {
            get { return Data.Team; }
        }

        public int ActionNum
        {
            get { return Data.ActionNum; }
            set { Data.ActionNum = value; }
        }
    }
}
