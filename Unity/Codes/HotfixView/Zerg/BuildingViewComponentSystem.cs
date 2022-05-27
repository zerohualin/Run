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

            var Building = self.GetParent<Building>();
            FrameObj.transform.localScale = new Vector3(Building.Config.Width, Building.Config.Height, 0.1f);

            float x = Building.PosX + Building.Config.Width * 0.5f - 0.5f;
            float z = Building.PosZ + Building.Config.Height * 0.5f - 0.5f;

            self.BuildingObj.transform.position = new Vector3(x, 1, z);
            TitleObj.transform.localScale = Vector3.one * Building.Config.Height * 0.5f;
            TitleObj.GetComponent<TextMeshPro>().text = Building.Config.Name;
        }
    }
}