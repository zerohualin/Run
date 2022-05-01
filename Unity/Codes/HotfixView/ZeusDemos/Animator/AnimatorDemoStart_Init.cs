using UnityEngine;

namespace ET
{
    public class AnimatorDemoStart_Init: AEvent<EventType.AnimatorDemoStart>
    {
        protected override void Run(EventType.AnimatorDemoStart args)
        {
            RunAsync(args).Coroutine();
        }

        private async ETTask RunAsync(EventType.AnimatorDemoStart args)
        {
            await SceneChangeHelper.PureSceneChangeTo(args.ZoneScene, "AnimatorDemo", 0);
            var  bundleGameObject = await Game.Scene.GetComponent<AddressableComponent>().LoadAssetByPathAsync<GameObject>("Assets/Bundles/ZeusDemos/AnimatorDemo/Rick.prefab");
            GameObject go = UnityEngine.Object.Instantiate(bundleGameObject, GlobalComponent.Instance.Unit, true);
        }
    }
}