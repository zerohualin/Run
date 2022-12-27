using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class AnimaResourceComponentAwakeSystem : AwakeSystem<AnimaResourceComponent>
    {
        protected override void Awake(AnimaResourceComponent self)
        {
            self.LoadAnima().Coroutine();
        }
    }
    
    [FriendOfAttribute(typeof(ET.Client.AnimaResourceComponent))]
    public static class AnimaResourceComponentSystem
    {
        public static async ETTask LoadAnima(this AnimaResourceComponent self)
        {
            string path = "Assets/BundleYoo/Zeus/Common/Anima.prefab";
            var bundleGameObject = await YooAssetProxy.LoadAssetAsync<GameObject>(path);
            var obj = GameObject.Instantiate(bundleGameObject.GetAssetObject<GameObject>());
            self.AnimaReferenceCollector = obj.GetComponent<ReferenceCollector>();
            GameObject.DontDestroyOnLoad(obj);
        }
        
        public static void SetAnimaReferenceCollector(this AnimaResourceComponent self, GameObject obj)
        {
            obj.AddComponent<ReferenceCollector>().data = self.AnimaReferenceCollector.data;
        }
    }

    
}
