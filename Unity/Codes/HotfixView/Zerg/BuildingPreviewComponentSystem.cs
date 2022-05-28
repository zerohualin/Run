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
            if (self.PreviewGridObjDic.Count > 0)
            {
                self.DestoryPreviewBuilding();
            }
            for (int x = 0; x < self.PreviewBuildingData.Width; x++)
            {
                for (int y = 0; y < self.PreviewBuildingData.Height; y++)
                {
                    self.PreviewGridObjDic.Add(x * 1000 + y, GameObject.Instantiate(self.PreviewGridObj, self.PreviewGridObjParent.transform));
                }
            }
        }

        public static AreaData UpdatePreviewBuilding(this BuildingPreviewComponent self, float posX, float posY)
        {
            if (self.PreviewGridObjDic.Count == 0)
            {
                self.CreatePreviewBuilding(self.PreviewBuildingData);
            }
            
            var ground = self.GetParent<GridGroundComponent>();
            self.CanBuild = true;

            AreaData area = AreaHelper.GetArea(posX, posY, self.PreviewBuildingData.Width, self.PreviewBuildingData.Height);

            for (int x = area.StartPosX; x < area.StartPosX + area.Width; x++)
            {
                for (int y = area.StartPosY; y < area.StartPosY + area.Height; y++)
                {
                    if (!self.CanBuild)
                        continue;
                    var node = ground.GetNode(x, y);
                    if (node == null || !node.CanBuild(self.PreviewBuildingData) || !node.CanView)
                    {
                        self.CanBuild = false;
                    }
                }
            }

            foreach (var VARIABLE in self.PreviewGridObjDic)
            {
                var x = VARIABLE.Key / 1000;
                var y = VARIABLE.Key % 1000;
                VARIABLE.Value.transform.position = new Vector3(area.StartPosX + x, 6, area.StartPosY + y);
                VARIABLE.Value.GetComponentInChildren<Renderer>().material.color = self.CanBuild? Color.cyan : Color.yellow;
            }

            return area;
        }

        public static void DestoryPreviewBuilding(this BuildingPreviewComponent self)
        {
            foreach (var VARIABLE in self.PreviewGridObjDic)
            {
                GameObject.Destroy(VARIABLE.Value);
            }
            self.PreviewGridObjDic.Clear();
        }

        public static void ClosePreviewBuilding(this BuildingPreviewComponent self)
        {
            self.PreviewBuildingData = null;
            self.DestoryPreviewBuilding();
        }
    }
}