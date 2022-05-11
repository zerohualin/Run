using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class B2SColliderConfigCategory : ProtoObject, IMerge
    {
        public static B2SColliderConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, B2SColliderConfig> dict = new Dictionary<int, B2SColliderConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<B2SColliderConfig> list = new List<B2SColliderConfig>();
		
        public B2SColliderConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            B2SColliderConfigCategory s = o as B2SColliderConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (B2SColliderConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public B2SColliderConfig Get(int id)
        {
            this.dict.TryGetValue(id, out B2SColliderConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (B2SColliderConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, B2SColliderConfig> GetAll()
        {
            return this.dict;
        }

        public B2SColliderConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class B2SColliderConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>对应碰撞数据Id</summary>
		[ProtoMember(2)]
		public long B2S_ColliderId { get; set; }
		/// <summary>是否默认跟随Unit</summary>
		[ProtoMember(3)]
		public bool SyncToUnit { get; set; }

	}
}
