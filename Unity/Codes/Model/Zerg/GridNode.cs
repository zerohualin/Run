namespace ET
{
    public class GridNode : Entity, IAwake, IAwake<int, int>
    {
        public bool CanBuild = true;
        public bool CanView = false;

        public int x = 0;
        public int y = 0;
    }
}