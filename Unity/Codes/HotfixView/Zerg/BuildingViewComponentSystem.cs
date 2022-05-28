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

            CardConfig Config = null;
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
                Config = AreaPreview.PreviewData;
                PosY = 3;
            }

            FrameObj.transform.localScale = new Vector3(Config.Width, Config.Height, 0.1f);

            float x = PosX + Config.Width * 0.5f - 0.5f;
            float z = PosZ + Config.Height * 0.5f - 0.5f;

            self.BuildingObj.transform.position = new Vector3(x, PosY, z);
            TitleObj.transform.localScale = Vector3.one * Config.Height * 0.5f;
            TitleObj.GetComponent<TextMeshPro>().text = Config.Name;
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
            float x = AreaPreview.AreaData.StartPosX + AreaPreview.PreviewData.Width * 0.5f - 0.5f;
            float z = AreaPreview.AreaData.StartPosY + AreaPreview.PreviewData.Height * 0.5f - 0.5f;
            self.BuildingObj.transform.position = new Vector3(x, 3, z);
        }
    }
}