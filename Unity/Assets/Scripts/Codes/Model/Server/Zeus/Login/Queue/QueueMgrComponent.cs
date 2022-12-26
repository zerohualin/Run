using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof (Scene))]
    public class QueueMgrComponent: Entity, IAwake, IDestroy
    {
        public HashSet<long> Online = new HashSet<long>();

        //排队队列
        public HashLinkedList<long, QueueInfo> Queue = new HashLinkedList<long, QueueInfo>();

        //掉线保护玩家
        public HashLinkedList<long, ProtectInfo> Protects = new HashLinkedList<long, ProtectInfo>();

        public long Timer_Trick;
        public long Timer_ClearProtect;
        public long Timer_Update;
    }
}