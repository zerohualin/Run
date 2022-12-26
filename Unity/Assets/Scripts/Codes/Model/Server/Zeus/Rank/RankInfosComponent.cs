using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof (Scene))]
    [ChildOf(typeof(RankInfo))]
    public class RankInfosComponent: Entity, IAwake, IDestroy
    {
        [BsonIgnore]
        public SortedList<RankInfo, long> SortedRankInfoList = new SortedList<RankInfo, long>(new RankInfoCompare());

        [BsonIgnore]
        public Dictionary<long, RankInfo> RankInfosDisctionary = new Dictionary<long, RankInfo>();
    }

    [FriendOf(typeof (RankInfo))]
    public class RankInfoCompare: IComparer<RankInfo>
    {
        public int Compare(RankInfo a, RankInfo b)
        {
            int result = b.Count - a.Count;
            
            if (result != 0)
                return result;
            
            if (a.Id < b.Id)
                return 1;
            
            if (a.Id > b.Id)
                return -1;

            return 0;
        }
    }
}