﻿namespace ET
{
    [ChildOf(typeof(ChatComponent))]
    public class ChatInfo: Entity, IAwake, IDestroy
    {
        public long UnitId;
        public string Name;
        public string Message;
    }
}