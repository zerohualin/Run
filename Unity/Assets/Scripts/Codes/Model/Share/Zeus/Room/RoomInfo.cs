using System.Collections.Generic;

namespace ET
{
    public class RoomInfo: Entity, IAwake
    {
        public string Name;
        public RoomType RoomType;
        public int CurrentNum;
        public int MaxNum;

        public Dictionary<long, int> RoomUnitStateDict = new Dictionary<long, int>();
    }
}