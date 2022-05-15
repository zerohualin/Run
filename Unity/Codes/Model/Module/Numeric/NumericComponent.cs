using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET
{
	namespace EventType
	{
		public class NumbericChange: DisposeObject
		{
			public static readonly NumbericChange Instance = new NumbericChange();
			
			public Entity Parent;
			public int NumericType;
			public long Old;
			public long New;
		}
	}
	
	public class NumericComponent: Entity, IAwake, ITransfer, IDestroy
	{
		[BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
		public Dictionary<int, long> NumericDic = new Dictionary<int, long>();
		
		public Dictionary<int, long> OriNumericDic = new Dictionary<int, long>();
	}
}