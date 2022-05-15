using System.Collections.Generic;

namespace ET
{
    [ChildType(typeof(Room))]
    public partial class RoomManagerComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<long, Room> LobbyRooms = new Dictionary<long, Room>();
        /// <summary>
        /// 战斗房间
        /// </summary>
        public Room BattleRoom;
    }
}