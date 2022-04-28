namespace ET
{
    public class SlgNodeData
    {
        public int X;
        public int Y;
        public SlgGroundType SlgGroundType;
    }

    public class SlgNode : Entity, ISerializeToEntity, IAwake<int, int>, IDestroy, IAwake<SlgNodeData>, IDeserialize
    {
        public SlgNodeData SlgNodeData;
        public int X
        {
            get { return SlgNodeData.X; }
        }

        public int Y
        {
            get { return SlgNodeData.Y; }
        }

        public SlgGroundType SlgGroundType
        {
            get { return SlgNodeData.SlgGroundType; }
            set { SlgNodeData.SlgGroundType = value; }
        }
    }

    public enum SlgGroundType
    {
        Normal = 1,
        Hole = 2
    }

    public class SlgVector
    {
        public int X;
        public int Y;
    }
}
