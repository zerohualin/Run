using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class ServerInfosComponent : Entity, IDestroy, IAwake, ILoad
    {
        public List<ServerInfo> ServerInfos = new List<ServerInfo>();
        public int CureentServerId = 1;
    }
}