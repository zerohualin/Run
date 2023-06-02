namespace ET
{
    namespace EventType
    {
        public struct NetDisconnect
        {
            public int Code;
        }
        
        public struct UpdateQueueInfo
        {
            public int Count;
            public int Index;
        }
    }
}