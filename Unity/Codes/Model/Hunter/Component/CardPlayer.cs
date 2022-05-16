using System.Collections.Generic;

namespace ET
{
    public class CardPlayer : Entity
    {
        public Dictionary<long, CardUnit> CardUnits = new Dictionary<long, CardUnit>();
    }
}