using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using UnityEngine;

namespace ET
{
    public class SlgData
    {
        public int RoundNum;
        public SlgMapData SlgMapData;
        public List<SlgUnitData> SlgUnitDatas;
    }
    public class SlgMapData
    {
        public int MapWidth;
        public int MapHeight;
        public List<SlgNodeData> NodeDatas;
    }

    public class SlgComponent : Entity, ISerializeToEntity, IAwake<SlgData>, IAwake, IDeserialize
    {
        public int MapWidth
        {
            get
            {
                if (this.Data == null)
                    Log.Error("还没有初始化数据");
                return this.Data.SlgMapData.MapWidth;
            }
        }

        public int MapHeight
        {
            get
            {
                if (this.Data == null)
                    Log.Error("还没有初始化数据");
                return this.Data.SlgMapData.MapHeight;
            }
        }

        public SlgData Data;

        [BsonIgnore]
        public SlgNode[][] Nodes;

        [BsonIgnore]
        public SlgMovePath[][] MovePaths;

        [BsonIgnore]
        public List<SlgAttackResult> SlgAttackResults;

        public UnitTeam MoveTeam = UnitTeam.A;

        public int RoundNum
        {
            get { return Data.RoundNum; }
            set { Data.RoundNum = value; }
        }
    }
}
