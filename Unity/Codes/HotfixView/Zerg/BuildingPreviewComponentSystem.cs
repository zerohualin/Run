using Cfg.zerg;
using UnityEngine;

namespace ET
{
    public class BuildingPreviewComponentAwakeSystem: AwakeSystem<BuildingPreviewComponent>
    {
        public override void Awake(BuildingPreviewComponent self)
        {
            self.PreviewGridObjParent = new GameObject("BuildingPreview");

            string path = "Assets/Bundles/Zerg/Prefabs/PreViewNode.prefab";
            self.PreviewGridObj = AddressableComponent.Instance.LoadAssetByPath<GameObject>(path);
        }
    }

    public static class BuildingPreviewComponentSystem
    {
        public static void CreatePreviewBuilding(this BuildingPreviewComponent self, CardConfig cardConfig)
        {
            self.PreviewBuildingData = cardConfig;

            for (int x = 0; x < self.PreviewBuildingData.Width; x++)
            {
                for (int y = 0; y < self.PreviewBuildingData.Height; y++)
                {
                    self.PreviewGridObjDic.Add(x * 1000 + y, GameObject.Instantiate(self.PreviewGridObj, self.PreviewGridObjParent.transform));
                }
            }
        }

        public static void UpdatePreviewBuilding(this BuildingPreviewComponent self, int centerPosX, int centerPosZ)
        {
            var ground = self.GetParent<GridGroundComponent>();
            self.CanBuild = true;
            for (int x = centerPosX; x < centerPosX + self.PreviewBuildingData.Width; x++)
            {
                for (int y = centerPosZ; y < centerPosZ + self.PreviewBuildingData.Height; y++)
                {
                    if (!self.CanBuild)
                        continue;
                    var node = ground.GetNode(x, y);
                    if (node == null || !node.CanBuild || !node.CanView)
                    {
                        self.CanBuild = false;
                    }
                }
            }

            foreach (var VARIABLE in self.PreviewGridObjDic)
            {
                var x = VARIABLE.Key / 1000;
                var y = VARIABLE.Key % 1000;
                VARIABLE.Value.transform.position = new Vector3(centerPosX + x, 6, centerPosZ + y);
                VARIABLE.Value.GetComponentInChildren<Renderer>().material.color = self.CanBuild? Color.cyan : Color.yellow;
            }
        }

        public static void ClosePreviewBuilding(this BuildingPreviewComponent self)
        {
            self.PreviewBuildingData = null;
            foreach (var VARIABLE in self.PreviewGridObjDic)
            {
                GameObject.Destroy(VARIABLE.Value);
            }

            self.PreviewGridObjDic.Clear();
        }
    }
}