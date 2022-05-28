namespace ET
{
    public class GridNode : Entity, IAwake, IAwake<int, int>
    {
        public bool CanBuild
        {
            get
            {
                if (IsBarrier || IsBuilded)
                    return false;
                return true;
            }
        }
        public bool CanView = false;

        public bool IsBuilded = false;
        public bool IsBarrier = false;

        public int x = 0;
        public int y = 0;
    }
}