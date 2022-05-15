using System.Collections.Generic;

namespace ET
{
    public class CardPlayerComponent : Entity, IAwake
    {
        public Dictionary<long, CardUnit> CardUnits = new Dictionary<long, CardUnit>();
    }
}