using Cfg.zerg;
using TMPro;
using UnityEngine;

namespace ET
{
    public class BuildViewComponentAwakeSystem: AwakeSystem<BuildingViewComponent>
    {
        public override void Awake(BuildingViewComponent self)
        {
            string path = "Assets/Bundles/Zerg/Prefabs/Buildings/Simple2DBuilding.prefab";
            var Obj = AddressableComponent.Instance.LoadAssetByPath<GameObject>(path);

            self.BuildingObj = GameObject.Instantiate(Obj);

            var ReferenceCollector = self.BuildingObj.GetComponent<ReferenceCollector>();
            var FrameObj = ReferenceCollector.Get<GameObject>("Frame");
            var TitleObj = ReferenceCollector.Get<GameObject>("Title");

            BuildingConfig Config = null;
            int PosX = 0;
            int PosY = 0;
            int PosZ = 0;

            var Building = self.GetParent<Building>();
            if (Building != null)
            {
                Config = Building.Config;
                PosX = Building.PosX;
                PosZ = Building.PosY;
                PosY = 1;
            }
            else
            {
                var AreaPreview = self.GetParent<AreaPreviewComponent>();
                Config = AreaPreview.BuildingData.Config;
                PosY = 3;
            }

            FrameObj.transform.localScale = new Vector3(Config.Size.X, Config.Size.Y, 0.1f);

            float x = PosX + Config.Size.X * 0.5f - 0.5f;
            float z = PosZ + Config.Size.Y * 0.5f - 0.5f;

            self.BuildingObj.transform.position = new Vector3(x, PosY, z);

            bool isWidthLong = Config.Size.X >= Config.Size.Y;

            TitleObj.transform.localScale = Vector3.one * 0.5f * (isWidthLong? Config.Size.X : Config.Size.Y);
            var textMeshPro = TitleObj.GetComponent<TextMeshPro>();
            textMeshPro.text = Config.Name;
            textMeshPro.outlineWidth = 0.2f;
            textMeshPro.outlineColor = new Color32(0, 0, 0, 255);

            var rect = textMeshPro.GetComponent<RectTransform>();
            rect.sizeDelta = isWidthLong? new Vector2(20, 5) : new Vector2(0, 5);
        }
    }

    public class BuildViewComponentDesotrySystem: DestroySystem<BuildingViewComponent>
    {
        public override void Destroy(BuildingViewComponent self)
        {
            GameObject.Destroy(self.BuildingObj);
        }
    }

    public static class BuildingViewComponentSystem
    {
        public static void UpdatePos(this BuildingViewComponent self)
        {
            var AreaPreview = self.GetParent<AreaPreviewComponent>();
            float x = AreaPreview.AreaData.StartPosX + AreaPreview.BuildingData.Config.Size.X * 0.5f - 0.5f;
            float z = AreaPreview.AreaData.StartPosY + AreaPreview.BuildingData.Config.Size.Y * 0.5f - 0.5f;
            self.BuildingObj.transform.position = new Vector3(x, 7, z);
        }
    }
}