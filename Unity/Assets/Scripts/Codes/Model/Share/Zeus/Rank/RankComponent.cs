using System.Collections.Generic;

namespace ET
{
    [ChildOf(typeof(RankInfo))]
    [ComponentOf(typeof(Scene))]
    public class RankComponent : Entity, IAwake
    {
        public List<RankInfo> RankInfos = new List<RankInfo>();
    }
}