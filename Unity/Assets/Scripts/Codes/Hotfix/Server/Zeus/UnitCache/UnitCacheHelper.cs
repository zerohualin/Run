// using System;
//
// namespace ET
// {
//     public static class UnitCacheHelper
//     {
//         //增加或更新玩家缓存
//         public static async ETTask AddOrUpdateUnitCache<T>(this T self) where T : Entity, IUnitCache
//         {
//             Other2UnitCache_AddOrUpdateUnit request = new Other2UnitCache_AddOrUpdateUnit() { UnitId = self.Id };
//             request.EntityTypes.Add(typeof (T).FullName);
//             request.EntityBytes.Add(MongoHelper.ToBson(self));
//             await MessageHelper.CallActor(StartSceneConfigCategory.Instance.GetUnitCacheConfig(self.Id).InstanceId, request);
//         }
//
//         //获取
//         public static async ETTask<T> GetUnitComponentCache<T>(long unitId) where T : Entity, IUnitCache
//         {
//             Other2UnitCache_GetUnit request = new Other2UnitCache_GetUnit() { UnitId = unitId };
//             request.ComponentNameList.Add(typeof (T).FullName);
//             long instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unitId).InstanceId;
//             UnitCache2Other_GetUnit response = (UnitCache2Other_GetUnit)await MessageHelper.CallActor(instanceId, request);
//             if (response.Error == ErrorCode.ERR_Success && response.EntityList.Count > 0)
//             {
//                 return response.EntityList[0] as T;
//             }
//
//             return null;
//         }
//
//         //删除玩家缓存
//         public static async ETTask DeleteUnitCache(long unitId)
//         {
//             Other2UnitCache_DeleteUnit request = new Other2UnitCache_DeleteUnit() { UnitId = unitId };
//             long instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unitId).InstanceId;
//             await MessageHelper.CallActor(instanceId, request);
//         }
//
//         public static async ETTask<Unit> GetUnitCache(Scene scene, long unitId)
//         {
//             long instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unitId).InstanceId;
//             Other2UnitCache_GetUnit request = new Other2UnitCache_GetUnit() { UnitId = unitId };
//             UnitCache2Other_GetUnit queryUnit = (UnitCache2Other_GetUnit)await MessageHelper.CallActor(instanceId, request);
//             if (queryUnit.Error != ErrorCode.ERR_Success || queryUnit.EntityList.Count <= 0)
//             {
//                 return null;
//             }
//
//             int indexOf = queryUnit.ComponentNameList.IndexOf(nameof (Unit));
//             Unit unit = queryUnit.EntityList[indexOf] as Unit;
//             if (unit == null)
//                 return null;
//
//             scene.AddChild(unit);
//
//             foreach (Entity entity in queryUnit.EntityList)
//             {
//                 if (entity == null || entity is Unit)
//                 {
//                     continue;
//                 }
//
//                 unit.AddComponent(entity);
//             }
//
//             return unit;
//         }
//
//         //增加或更新玩家缓存
//         public static void AddOrUpdateAllUnitCache(Unit unit)
//         {
//             Other2UnitCache_AddOrUpdateUnit request = new Other2UnitCache_AddOrUpdateUnit() { UnitId = unit.Id };
//             request.EntityTypes.Add(unit.GetType().FullName);
//             request.EntityBytes.Add(MongoHelper.ToBson(unit));
//
//             foreach ((Type key, Entity entity) in unit.Components)
//             {
//                 if (!typeof (IUnitCache).IsAssignableFrom(key))
//                     continue;
//                 request.EntityTypes.Add(key.FullName);
//                 request.EntityBytes.Add(MongoHelper.ToBson(entity));
//             }
//
//             MessageHelper.CallActor(StartSceneConfigCategory.Instance.GetUnitCacheConfig(unit.Id).InstanceId, request).Coroutine();
//         }
//     }
// }