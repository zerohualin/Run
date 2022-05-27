using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class BuildingPreviewComponent: Entity, IAwake
    {
        public bool CanBuild = false;
        public BuildingData PreviewBuildingData = null;

        public GameObject PreviewGridObjParent;
        public GameObject PreviewGridObj;
        public Dictionary<int, GameObject> PreviewGridObjDic = new Dictionary<int, GameObject>();
    }
}