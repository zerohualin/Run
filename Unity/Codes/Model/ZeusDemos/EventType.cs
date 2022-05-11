namespace ET
{
    namespace EventType
    {
        public struct AnimatorDemoStart
        {
            public Scene ZoneScene;
        }
        
        public struct LubanDemoStart
        {
            
        }
        
        public struct FSMStateChanged_PlayAnim
        {
            public Unit Unit;
        }
        
        public struct AfterUnitCreate_CreateGo
        {
            public int HeroConfigId;
            public Unit Unit;
            public bool IsLocalPlayer;
        }
    }
}