//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2019年7月20日 21:22:16
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using MongoDB.Bson.Serialization;
using UnityEngine;

namespace ET
{
    /// <summary>
    /// 碰撞体数据仓库，从二进制文件读取数据
    /// </summary>
    public class B2S_ColliderDataRepositoryComponent : Entity, IAwake
    {
#if SERVER
                private string colliderDataPath = "../Config/ColliderDatas/";
#endif
        private List<string> colliderDataName = new List<string>() {"BoxColliderData", "CircleColliderData", "PolygonColliderData"};

        public ColliderDataSupporter BoxColliderDatas = new ColliderDataSupporter();
        public ColliderDataSupporter CircleColliderDatas = new ColliderDataSupporter();
        public ColliderDataSupporter PolygonColliderDatas = new ColliderDataSupporter();
    }
}