namespace ET
{
    public class GridNode : Entity, IAwake, IAwake<int, int>
    {
        public bool Builded = false;
        public bool CanView = false;

        public int x = 0;
        public int y = 0;
    }
}