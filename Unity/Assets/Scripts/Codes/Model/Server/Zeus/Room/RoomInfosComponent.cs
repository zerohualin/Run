using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    [ChildOf(typeof(RoomInfo))]
    public class RoomInfosComponent : Entity, IAwake
    {
        public Dictionary<long, RoomInfo> RoomInfos = new Dictionary<long, RoomInfo>();
    }
}