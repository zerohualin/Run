using System.Collections.Generic;
using Cfg.zerg;

namespace ET
{
    public static class BulePrintComponentSystem
    {
        public static bool CheckAlreadyHave(this BulePrintComponent self, int bluePrintId)
        {
            if (self.BluePrintIdList.Contains(bluePrintId))
            {
                Log.Error("已经拥有改蓝图了！");
                return true;
            }
            return false;
        }
        public static void AddBluePrint(this BulePrintComponent self, int bluePrintId)
        {
            if (!self.CheckAlreadyHave(bluePrintId))
            {
                self.BluePrintIdList.Add(bluePrintId);
            }
        }

        public static List<BluePrintConfig> GetAllBluePrint;

    }
}