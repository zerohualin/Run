using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildOf(typeof(RoomInfo))]
    public class RoomComponent : Entity, IAwake
    {
        public List<RoomInfo> RoomInfos = new List<RoomInfo>();

        public long myRoomInfoId;

        public RoomInfo MyRoomInfo
        {
            get
            {
                return GetChild<RoomInfo>(this.myRoomInfoId);
            }
            set
            {
                this.myRoomInfoId = value.Id;
            }
        }
        // public List<RoomUnitProto> RoomUnitList = new List<RoomUnitProto>();
    }
}