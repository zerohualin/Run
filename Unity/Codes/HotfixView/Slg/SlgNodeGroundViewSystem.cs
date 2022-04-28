using System.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET
{
    [ObjectSystem]
    public class SlgNodeGroundViewAwakeSystem : AwakeSystem<SlgNodeGroundView>
    {
        public override async void Awake(SlgNodeGroundView self)
        {
            self.Data = self.Parent as SlgNode;
            var ResourcesComponent = Game.Scene.GetComponent<ResourcesComponentX>();

            GameObject bundleGameObject =
                (GameObject)ResourcesComponent.LoadAsset<GameObject>(
                    "Assets/Bundles/com_wavegamer_slg/Prefab/GroundNode.prefab");
            self.Obj = GameObject.Instantiate(bundleGameObject);

            self.UpdatePos();

            self.Renderer = self.Obj.GetComponentInChildren<Renderer>();
            
            switch (self.Data.SlgGroundType)
            {
                case SlgGroundType.Normal:
                    self.Renderer.material.color = Color.gray;
                    break;
                case SlgGroundType.Hole:
                    self.Renderer.material.color = Color.black;
                    break;
            }

            ColiderHelper.OnPointerClick(self.Obj,
                Vector3.zero,
                new Vector3(1, 0.1f, 1),
                (BaseEventData bed) => { Game.Scene.GetComponent<SlgView>().TrySelectNode(self.Data); });
        }
    }
    
    [ObjectSystem]
    public class SlgNodeGroundViewDestroySystem : DestroySystem<SlgNodeGroundView>
    {
        public override async void Destroy(SlgNodeGroundView self)
        {
            GameObject.Destroy(self.Obj);
        }
    }

    public static class SlgNodeGroundViewSystem
    {
        public static void UpdatePos(this SlgNodeGroundView self)
        {
            self.Obj.transform.position = new Vector3(self.Data.X, 0, self.Data.Y);
        }
    }
}