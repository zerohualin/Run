using System.Collections.Generic;

namespace ET
{
    [ChildType(typeof (CardUnit))]
    public class CardUnitManagerComponent : Entity, IAwake
    {
        public Dictionary<long, CardUnit> CardUnits = new Dictionary<long, CardUnit>();
    }
}