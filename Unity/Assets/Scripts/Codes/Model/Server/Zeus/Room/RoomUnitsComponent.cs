using System.Collections.Generic;

namespace ET.Server
{
    [ChildOf(typeof (RoomUnit))]
    [ComponentOf(typeof (Scene))]
    public class RoomUnitsComponent: Entity, IAwake, IDestroy
    {
        public Dictionary<long, RoomUnit> RoomUnitDict = new Dictionary<long, RoomUnit>();
    }
}