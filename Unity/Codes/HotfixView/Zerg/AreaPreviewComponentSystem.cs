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
            string path2 = "Assets/Bundles/Zerg/Prefabs/FieldNode.prefab";
            self.FieldObj = AddressableComponent.Instance.LoadAssetByPath<GameObject>(path2);
        }
    }

    public static class AreaPreviewComponentSystem
    {
        public static void CreatePreviewBuilding(this AreaPreviewComponent self, BuildingData buildingData)
        {
            self.BuildingData = buildingData;
            if (self.PreviewGridObjDic.Count > 0)
            {
                self.DestoryPreviewBuilding();
            }

            for (int x = 0; x < self.BuildingData.Config.Size.X; x++)
            {
                for (int y = 0; y < self.BuildingData.Config.Size.Y; y++)
                {
                    self.PreviewGridObjDic.Add(x * 1000 + y, GameObject.Instantiate(self.PreviewGridObj, self.PreviewGridObjParent.transform));
                }
            }

            for (int x = 0; x < self.BuildingData.Config.GetFiledX(); x++)
            {
                for (int y = 0; y < self.BuildingData.Config.GetFiledY(); y++)
                {
                    self.FieldObjDic.Add(x * 1000 + y, GameObject.Instantiate(self.FieldObj, self.PreviewGridObjParent.transform));
                }
            }

            if (self.GetComponent<BuildingViewComponent>() == null)
                self.AddComponent<BuildingViewComponent>();
        }

        public static AreaData UpdatePreviewBuilding(this AreaPreviewComponent self, float posX, float posY)
        {
            if (self.PreviewGridObjDic.Count == 0)
            {
                self.CreatePreviewBuilding(self.BuildingData);
            }

            var ground = self.GetParent<GridGroundComponent>();
            self.CanBuild = true;

            var area = AreaHelper.GetArea(posX, posY, self.BuildingData.Config.Size.X, self.BuildingData.Config.Size.Y);

            self.AreaData = area;

            for (int x = area.StartPosX; x < area.StartPosX + area.Width; x++)
            {
                for (int y = area.StartPosY; y < area.StartPosY + area.Height; y++)
                {
                    if (!self.CanBuild)
                        continue;
                    var node = ground.GetNode(x, y);
                    if (node == null || !node.CanBuild(self.BuildingData.Config) || !node.CanView)
                    {
                        self.CanBuild = false;
                    }
                }
            }

            foreach (var VARIABLE in self.PreviewGridObjDic)
            {
                var x = VARIABLE.Key / 1000;
                var y = VARIABLE.Key % 1000;
                VARIABLE.Value.transform.position = new Vector3(area.StartPosX + x, 7.7f, area.StartPosY + y);
                VARIABLE.Value.GetComponentInChildren<Renderer>().material.color = self.CanBuild? Color.blue : Color.red;
                var color = VARIABLE.Value.GetComponentInChildren<Renderer>().material.color;
                color.a = 0.4f;
                VARIABLE.Value.GetComponentInChildren<Renderer>().material.color = color;
            }

            var fieldArea = AreaHelper.GetArea(posX, posY, self.BuildingData.Config.GetFiledX(), self.BuildingData.Config.GetFiledY());
            foreach (var VARIABLE in self.FieldObjDic)
            {
                var x = VARIABLE.Key / 1000;
                var y = VARIABLE.Key % 1000;
                VARIABLE.Value.transform.position = new Vector3(fieldArea.StartPosX + x, 6, fieldArea.StartPosY + y);
            }

            self.GetComponent<BuildingViewComponent>()?.UpdatePos();

            return area;
        }

        public static void DestoryPreviewBuilding(this AreaPreviewComponent self)
        {
            foreach (var VARIABLE in self.PreviewGridObjDic)
            {
                GameObject.Destroy(VARIABLE.Value);
            }

            foreach (var VARIABLE in self.FieldObjDic)
            {
                GameObject.Destroy(VARIABLE.Value);
            }

            self.PreviewGridObjDic.Clear();
            self.FieldObjDic.Clear();
            self.GetComponent<BuildingViewComponent>()?.Dispose();
        }

        public static void ClosePreviewBuilding(this AreaPreviewComponent self)
        {
            self.BuildingData = null;
            self.DestoryPreviewBuilding();
        }

        public static void TryUseCard(this AreaPreviewComponent self)
        {
            bool CanUse = false;
            BuildingData buildingData = self.BuildingData;
            switch (self.BuildingData.Config.Type)
            {
                case BuildingType.Building:
                    if (self.CanBuild)
                    {
                        self.DomainScene().GetComponent<GridGroundComponent>().AddBuild(self.AreaData, self.BuildingData.Config);
                        self.DomainScene().GetComponent<GridGroundComponent>().GetComponent<AreaPreviewComponent>().ClosePreviewBuilding();
                        CanUse = true;
                    }
                    else
                    {
                        // Log.Error("不行啦,有东西挡住啦");
                    }

                    break;
                // case BuildingType.Skill:
                //     self.DomainScene().GetComponent<GridGroundComponent>().GetComponent<AreaPreviewComponent>().ClosePreviewBuilding();
                //     CanUse = true;
                //     break;
            }

            if (CanUse)
            {
                var HandComponent = self.DomainScene().GetMyPlayer().GetComponent<HandComponent>();
                HandComponent.TryUseCard(buildingData);
            }
        }

        public static void CancelUse(this AreaPreviewComponent self)
        {
            self.DomainScene().GetComponent<GridGroundComponent>().GetComponent<AreaPreviewComponent>().ClosePreviewBuilding();
        }
    }
}