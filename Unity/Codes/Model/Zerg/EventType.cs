namespace ET
{
    namespace EventType
    {
        public struct ZergStart
        {
        }

        public struct ChangeGridGround
        {
            public int X;
            public int Y;
        }

        public struct UpdateGridNode
        {
            public GridNode Node;
        }

        public struct InitBuilding
        {
            public Building Building;
        }

        public struct InitEnemy
        {
            public Enemy Enemy;  
        }
    }
}