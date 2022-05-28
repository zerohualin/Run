namespace ET
{
    namespace EventType
    {
        public struct HunterStart
        {
        }

        public struct HunterInitFinish
        {
            public Scene ZoneScene;
        }
        
        public struct NewTrun
        {
            public Scene ZoneScene;
        }
        
        public struct ChangeTrun
        {
            public Scene ZoneScene;
        }
        
        public struct ChangeEnergy
        {
            public Scene ZoneScene;
        }

        public struct ChangeCard
        {
            public Scene ZoneScene;
        }
    }
}