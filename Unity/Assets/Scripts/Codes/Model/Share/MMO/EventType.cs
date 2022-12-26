using System.Collections.Generic;

namespace ET
{
    namespace EventType
    {
        public struct CommonSelectListEvent
        {
            public Scene ZoneScene;
            public List<CommonSelectCellData> CellDataList;
        }
    }
}