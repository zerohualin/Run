using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildOf(typeof(RoomInfo))]
    public class RoomComponent : Entity, IAwake
    {
        public List<RoomInfo> RoomInfos = new List<RoomInfo>();

        public RoomInfo MyRoomInfo = new RoomInfo();
        // public List<RoomUnitProto> RoomUnitList = new List<RoomUnitProto>();
    }
}