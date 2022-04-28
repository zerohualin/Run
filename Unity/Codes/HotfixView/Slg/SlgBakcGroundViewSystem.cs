using UnityEngine;
using UnityEngine.EventSystems;

namespace ET
{
    [ObjectSystem]
    public class SlgBakcGroundViewAwakeSystem: AwakeSystem<SlgBakcGroundView>
    {
        public override async void Awake(SlgBakcGroundView self)
        {
            var ResourcesComponent = Game.Scene.GetComponent<ResourcesComponentX>();
            GameObject bundleGameObject = ResourcesComponent.LoadAsset<GameObject>("Assets/Bundles/com_wavegamer_slg/Prefab/BakcGround.prefab");
            self.Obj = GameObject.Instantiate(bundleGameObject);
            
            ColiderHelper.OnPointerClick(self.Obj,
                Vector3.zero,
                new Vector3(1,1, 1),
                (BaseEventData bed) =>
                {
                    Game.Scene.GetComponent<SlgView>().UnSelect();
                });
        }
    }
    
    [ObjectSystem]
    public class SlgBakcGroundViewDestroySystem : DestroySystem<SlgBakcGroundView>
    {
        public override async void Destroy(SlgBakcGroundView self)
        {
            GameObject.Destroy(self.Obj);
        }
    }
}