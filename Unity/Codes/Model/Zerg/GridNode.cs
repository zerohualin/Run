namespace ET
{
    public class GridNode: Entity, IAwake, IAwake<int, int>
    {
        public bool CanView = false;

        public long BuildingId = 0;
        public bool IsBuilded
        {
            get
            {
                if (this.BuildingId == 0)
                    return false;
                var building = Game.EventSystem.Get(this.BuildingId);
                if (building != null && !building.IsDisposed)
                    return true;
                return false;
            }
        }

        public bool IsBarrier
        {
            get
            {
                var Barrier = GetComponent<GroundBarrierComponent>();
                return Barrier != null;
            }
        }

        public bool IsMineral
        {
            get
            {
                var Mineral = GetComponent<GroundMineralComponent>();
                return Mineral != null;
            }
        }

        public int x = 0;
        public int y = 0;
    }
}