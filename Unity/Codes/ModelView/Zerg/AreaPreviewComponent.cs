using System.Collections.Generic;
using Cfg.zerg;
using UnityEngine;

namespace ET
{
    public class AreaPreviewComponent: Entity, IAwake
    {
        public bool CanBuild = false;
        public BuildingData BuildingData = null;

        public GameObject PreviewGridObjParent;
        public GameObject PreviewGridObj;
        public Dictionary<int, GameObject> PreviewGridObjDic = new Dictionary<int, GameObject>();
        public GameObject FieldObj;
        public Dictionary<int, GameObject> FieldObjDic = new Dictionary<int, GameObject>();
        
        public AreaData AreaData = new AreaData();
    }
}