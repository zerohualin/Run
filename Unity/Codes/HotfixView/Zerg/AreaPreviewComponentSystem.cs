using Cfg.zerg;
using UnityEngine;

namespace ET
{
    public class AreaPreviewComponentAwakeSystem: AwakeSystem<AreaPreviewComponent>
    {
        public override void Awake(AreaPreviewComponent self)
        {
            self.PreviewGridObjParent = new GameObject("BuildingPreview");

            string path = "Assets/Bundles/Zerg/Prefabs/PreViewNode.prefab";
            self.PreviewGridObj = AddressableComponent.Instance.LoadAssetByPath<GameObject>(path);
        }
    }

    public static class AreaPreviewComponentSystem
    {
        public static void CreatePreviewBuilding(this AreaPreviewComponent self, CardConfig cardConfig)
        {
            self.PreviewData = cardConfig;
            if (self.PreviewGridObjDic.Count > 0)
            {
                self.DestoryPreviewBuilding();
            }

            for (int x = 0; x < self.PreviewData.Width; x++)
            {
                for (int y = 0; y < self.PreviewData.Height; y++)
                {
                    self.PreviewGridObjDic.Add(x * 1000 + y, GameObject.Instantiate(self.PreviewGridObj, self.PreviewGridObjParent.transform));
                }
            }
            self.AddComponent<BuildingViewComponent>();
        }

        public static AreaData UpdatePreviewBuilding(this AreaPreviewComponent self, float posX, float posY)
        {
            if (self.PreviewGridObjDic.Count == 0)
            {
                self.CreatePreviewBuilding(self.PreviewData);
            }

            var ground = self.GetParent<GridGroundComponent>();
            self.CanBuild = true;

            var area = AreaHelper.GetArea(posX, posY, self.PreviewData.Width, self.PreviewData.Height);

            self.AreaData = area;

            for (int x = area.StartPosX; x < area.StartPosX + area.Width; x++)
            {
                for (int y = area.StartPosY; y < area.StartPosY + area.Height; y++)
                {
                    if (!self.CanBuild)
                        continue;
                    var node = ground.GetNode(x, y);
                    if (node == null || !node.CanBuild(self.PreviewData) || !node.CanView)
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
                VARIABLE.Value.GetComponentInChildren<Renderer>().material.color = self.CanBuild? Color.blue : Color.red ;
                var color = VARIABLE.Value.GetComponentInChildren<Renderer>().material.color;
                color.a = 0.4f;
                VARIABLE.Value.GetComponentInChildren<Renderer>().material.color = color;
            }

            var CardView = self.GetComponent<BuildingViewComponent>();
            CardView.UpdatePos();

            return area;
        }

        public static void DestoryPreviewBuilding(this AreaPreviewComponent self)
        {
            foreach (var VARIABLE in self.PreviewGridObjDic)
            {
                GameObject.Destroy(VARIABLE.Value);
            }
            self.PreviewGridObjDic.Clear();
            self.GetComponent<BuildingViewComponent>()?.Dispose();
        }

        public static void ClosePreviewBuilding(this AreaPreviewComponent self)
        {
            self.PreviewData = null;
            self.DestoryPreviewBuilding();
        }
    }
}