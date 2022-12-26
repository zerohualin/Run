using System.Collections.Generic;

namespace ET.Server
{
    [ChildOf(typeof (ChatInfoUnit))]
    [ComponentOf(typeof (Scene))]
    public class ChatInfoUnitsComponent: Entity, IAwake, IDestroy
    {
        public Dictionary<long, ChatInfoUnit> ChatInfoUnitDict = new Dictionary<long, ChatInfoUnit>();
    }
}