using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class B2SCollisionRelationConfigCategory : ProtoObject, IMerge
    {
        public static B2SCollisionRelationConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, B2SCollisionRelationConfig> dict = new Dictionary<int, B2SCollisionRelationConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<B2SCollisionRelationConfig> list = new List<B2SCollisionRelationConfig>();
		
        public B2SCollisionRelationConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            B2SCollisionRelationConfigCategory s = o as B2SCollisionRelationConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (B2SCollisionRelationConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public B2SCollisionRelationConfig Get(int id)
        {
            this.dict.TryGetValue(id, out B2SCollisionRelationConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (B2SCollisionRelationConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, B2SCollisionRelationConfig> GetAll()
        {
            return this.dict;
        }

        public B2SCollisionRelationConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class B2SCollisionRelationConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>对应碰撞数据配置Id</summary>
		[ProtoMember(2)]
		public int B2S_ColliderConfigId { get; set; }
		/// <summary>对应碰撞处理者名称</summary>
		[ProtoMember(3)]
		public string B2S_ColliderHandlerName { get; set; }
		/// <summary>友方英雄碰撞</summary>
		[ProtoMember(4)]
		public bool FriendlyHero { get; set; }
		/// <summary>敌方英雄碰撞</summary>
		[ProtoMember(5)]
		public bool EnemyHero { get; set; }
		/// <summary>友方小兵碰撞</summary>
		[ProtoMember(6)]
		public bool FriendlySoldier { get; set; }
		/// <summary>敌方小兵碰撞</summary>
		[ProtoMember(7)]
		public bool EnemySoldier { get; set; }
		/// <summary>友方建筑物碰撞</summary>
		[ProtoMember(8)]
		public bool FriendlyBuilds { get; set; }
		/// <summary>敌方建筑物碰撞</summary>
		[ProtoMember(9)]
		public bool EnemyBuilds { get; set; }
		/// <summary>中立生物碰撞</summary>
		[ProtoMember(10)]
		public bool Creeps { get; set; }

	}
}
