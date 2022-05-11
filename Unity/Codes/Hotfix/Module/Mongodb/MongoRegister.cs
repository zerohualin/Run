using System;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using UnityEngine;
using System.Collections.Generic;

namespace ET
{
    public static class MongoRegister
    {
        static MongoRegister()
        {
            // 自动注册IgnoreExtraElements

            ConventionPack conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };

            ConventionRegistry.Register("IgnoreExtraElements", conventionPack, type => true);

#if SERVER
            BsonSerializer.RegisterSerializer(typeof(Vector3), new StructBsonSerialize<Vector3>());
            BsonSerializer.RegisterSerializer(typeof(Vector4), new StructBsonSerialize<Vector4>());
            BsonSerializer.RegisterSerializer(typeof(Quaternion), new StructBsonSerialize<Quaternion>());
#elif ROBOT
			BsonSerializer.RegisterSerializer(typeof(Quaternion), new StructBsonSerialize<Quaternion>());
            BsonSerializer.RegisterSerializer(typeof(Vector3), new StructBsonSerialize<Vector3>());
            BsonSerializer.RegisterSerializer(typeof(Vector4), new StructBsonSerialize<Vector4>());
#else
            BsonSerializer.RegisterSerializer(new StructBsonSerialize<System.Numerics.Vector2>());
            BsonSerializer.RegisterSerializer(typeof (Vector4), new StructBsonSerialize<Vector4>());
            BsonSerializer.RegisterSerializer(typeof (Vector3), new StructBsonSerialize<Vector3>());
#endif

            var types = Game.EventSystem.GetTypes();

            foreach (Type type in types.Values)
            {
                if (!type.IsSubclassOf(typeof (Object)))
                {
                    continue;
                }

                if (type.IsGenericType)
                {
                    continue;
                }

                BsonClassMap.LookupClassMap(type);
            }
            RegisterAllSubClassForDeserialize(types);
        }

                /// <summary>
        /// 注册所有供反序列化的子类
        /// </summary>
        public static void RegisterAllSubClassForDeserialize(Dictionary<string, Type> allTypes)
        {
            List<Type> parenTypes = new List<Type>();
            List<Type> childrenTypes = new List<Type>();
            // registe by BsonDeserializerRegisterAttribute Automatically
            foreach (Type type in allTypes.Values)
            {
                BsonDeserializerRegisterAttribute[] bsonDeserializerRegisterAttributes =
                    type.GetCustomAttributes(typeof(BsonDeserializerRegisterAttribute), false) as
                        BsonDeserializerRegisterAttribute[];
                if (bsonDeserializerRegisterAttributes.Length > 0)
                {
                    parenTypes.Add(type);
                }

                BsonDeserializerRegisterAttribute[] bsonDeserializerRegisterAttributes1 =
                    type.GetCustomAttributes(typeof(BsonDeserializerRegisterAttribute), true) as
                        BsonDeserializerRegisterAttribute[];
                if (bsonDeserializerRegisterAttributes1.Length > 0)
                {
                    childrenTypes.Add(type);
                }
            }

            foreach (Type type in childrenTypes)
            {
                foreach (var parentType in parenTypes)
                {
                    if (parentType.IsAssignableFrom(type) && parentType != type)
                    {
                        BsonClassMap.LookupClassMap(type);
                    }
                }
            }
        }

        public static void Init()
        {
            
        }
    }
}