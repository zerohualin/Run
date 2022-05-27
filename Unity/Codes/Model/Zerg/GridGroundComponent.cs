namespace ET
{
    public class GridGroundComponent : Entity, IAwake<int, int>
    {
        public int Width;
        public int Height;
        
        public GridNode[][] GridData;
    }
}