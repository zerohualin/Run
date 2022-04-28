using System.Collections.Generic;

namespace ET
{
    public class SlgUnitComponent : Entity, IAwake
    {
        public Dictionary<SlgVector, SlgUnit> Units = new Dictionary<SlgVector, SlgUnit>();
    }
}
