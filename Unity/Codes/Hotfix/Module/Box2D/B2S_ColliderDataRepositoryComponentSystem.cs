using MongoDB.Bson.Serialization;
using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class B2S_ColliderDataRepositoryComponentAwakeSystem: AwakeSystem<B2S_ColliderDataRepositoryComponent>
    {
        public override void Awake(B2S_ColliderDataRepositoryComponent self)
        {
            self.ReadcolliderData();
        }
    }

    [FriendClass(typeof (B2S_ColliderDataRepositoryComponent))]
    public static class B2S_ColliderDataRepositoryComponentSystem
    {
        /// <summary>
        /// 读取所有碰撞数据
        /// </summary>
        public static void ReadcolliderData(this B2S_ColliderDataRepositoryComponent self)
        {
#if SERVER
            if (File.Exists($"{this.colliderDataPath}/{this.colliderDataName[0]}.bytes"))
            {
                byte[] mfile0 = File.ReadAllBytes($"{this.colliderDataPath}/{this.colliderDataName[0]}.bytes");
                //这里不进行长度判断会报错，正在试图访问一个已经关闭的流，咱也不懂，咱也不敢问
                if (mfile0.Length > 0)
                    this.BoxColliderDatas =
                            BsonSerializer.Deserialize<ColliderDataSupporter>(mfile0);
                //Log.Info($"已经读取矩形数据，数据大小为{mfile0.Length}");
            }

            if (File.Exists($"{this.colliderDataPath}/{this.colliderDataName[1]}.bytes"))
            {
                byte[] mfile1 = File.ReadAllBytes($"{this.colliderDataPath}/{this.colliderDataName[1]}.bytes");
                if (mfile1.Length > 0)
                    this.CircleColliderDatas =
                            BsonSerializer.Deserialize<ColliderDataSupporter>(mfile1);
                //Log.Info($"已经读取圆形数据，数据大小为{mfile1.Length}");
            }

            if (File.Exists($"{this.colliderDataPath}/{this.colliderDataName[2]}.bytes"))
            {
                byte[] mfile2 = File.ReadAllBytes($"{this.colliderDataPath}/{this.colliderDataName[2]}.bytes");
                if (mfile2.Length > 0)
                {
                    this.PolygonColliderDatas =
                            BsonSerializer.Deserialize<ColliderDataSupporter>(mfile2);
                }

                //Log.Info($"已经读取多边形数据，数据大小为{mfile2.Length}");
            }
#else
            
            string boxPath = $"Assets/Bundles/Config/B2SColliderConfig/{self.colliderDataName[0]}.bytes";
            byte[] mboxFile = AddressableComponent.Instance.LoadAssetByPath<TextAsset>(boxPath)?.bytes;
            //这里不进行长度判断会报错，正在试图访问一个已经关闭的流，咱也不懂，咱也不敢问
            if (mboxFile != null && mboxFile.Length > 0)
            {
                self.BoxColliderDatas = BsonSerializer.Deserialize<ColliderDataSupporter>(mboxFile);
                Log.Info($"已经读取矩形数据，数据大小为{mboxFile.Length}");
            }
            
            string circlePath = $"Assets/Bundles/Config/B2SColliderConfig/{self.colliderDataName[1]}.bytes";
            byte[] mCircleFile = AddressableComponent.Instance.LoadAssetByPath<TextAsset>(circlePath)?.bytes;
            if (mCircleFile != null && mCircleFile.Length > 0)
            {
                self.CircleColliderDatas = BsonSerializer.Deserialize<ColliderDataSupporter>(mCircleFile);
                Log.Info($"已经读取圆形数据，数据大小为{mCircleFile.Length}");
            }
            
            string polygonPath = $"Assets/Bundles/Config/B2SColliderConfig/{self.colliderDataName[1]}.bytes";
            byte[] polygonFile = AddressableComponent.Instance.LoadAssetByPath<TextAsset>(polygonPath)?.bytes;
            if (polygonPath != null && polygonPath.Length > 0)
            {
                self.PolygonColliderDatas = BsonSerializer.Deserialize<ColliderDataSupporter>(polygonFile);
                Log.Info($"已经读取多边形数据，数据大小为{polygonFile.Length}");
            }
#endif
        }

        public static B2S_ColliderDataStructureBase GetDataByColliderId(this B2S_ColliderDataRepositoryComponent self, long id)
        {
            long flag = id / 10000;
            
            switch (flag)
            {
                case 1:
                    return self.BoxColliderDatas.colliderDataDic[id];
                case 2:
                    return self.CircleColliderDatas.colliderDataDic[id];
                case 3:
                    return self.PolygonColliderDatas.colliderDataDic[id];
            }

            Log.Error($"未找到碰撞体数据，所查找的ID：{id}");
            return null;
        }
    }
}