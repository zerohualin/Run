using System.Collections.Generic;

namespace ET
{
    [ObjectSystem]
    public class SlgUnitComponentAwakeSystem : AwakeSystem<SlgUnitComponent>
    {
        public override void Awake(SlgUnitComponent self)
        {
            self.Units = new Dictionary<SlgVector, SlgUnit>();
        }
    }
    
    public static class SlgUnitComponentSystem
    {
        public static void Add(this SlgUnitComponent self, SlgUnit unit)
        {
            self.Units[new SlgVector() { Y = unit.Data.Y, X = unit.Data.X }] = unit;
        }

        public static void Add(this SlgUnitComponent self, int x, int y, UnitTeam unitTeam)
        {
            
        }
        
        public static List<SlgUnit> GetAll(this SlgUnitComponent self)
        {
            List<SlgUnit> unitList = new List<SlgUnit>();
            foreach (var VARIABLE in self.Units)
            {
                unitList.Add(VARIABLE.Value);
            }
            return unitList;
        }

        public static SlgUnit Get(this SlgUnitComponent self, int x, int y)
        {
            return self.Units[new SlgVector() { X = x, Y = y }];
        }

        public static void ResetAction(this SlgUnitComponent self, UnitTeam moveTeam)
        {
            foreach (var VARIABLE in self.Units)
            {
                VARIABLE.Value.ResetAction(moveTeam);
            }
        }

        public static SlgUnit RandomSelectUnit(this SlgUnitComponent self, UnitTeam team)
        {
            foreach (var VARIABLE in self.Units)
            {
                if (VARIABLE.Value.Team == team && VARIABLE.Value.ActionNum > 0)
                    return VARIABLE.Value;
            }

            return null;
        }
        
        public static SlgUnit GetCanMoveUnit(this SlgUnitComponent self)
        {
            foreach (var VARIABLE in self.Units)
            {
                if (VARIABLE.Value.ActionNum > 0)
                    return VARIABLE.Value;
            }
            return null;
        }
    }
}