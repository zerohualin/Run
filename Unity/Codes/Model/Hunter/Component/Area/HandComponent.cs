using System.Collections.Generic;
using Cfg.zerg;

namespace ET
{
    [ChildType(typeof(BuildingData))]
    public class HandComponent: Entity, IAwake
    {
        public List<BuildingData> Cards = new List<BuildingData>();
    }
}