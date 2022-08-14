using UnityEngine;

namespace ET.Client
{
    public class Goto_Animancer_Demo
    {
        [Event(SceneType.Client)]
        public class Goto_Animancer_Demo_: AEvent<EventType.Goto_MiniGame>
        {
            protected override async ETTask Run(Scene scene, EventType.Goto_MiniGame args)
            {
                await Game.Scene.GetComponent<TimerComponent>().WaitAsync(100);

                await YooAssetProxy.LoadSceneAsync("Assets/BundleYoo/MiniGame/Scene/MiniGame.unity");
                
                string ModelPath = string.Format($"Assets/BundleYoo/MiniGame/Prefabs/Cube.prefab");
                var handle = await YooAssetProxy.LoadAssetAsync<GameObject>(ModelPath);
                var Obj = GameObject.Instantiate(handle.GetAsset<GameObject>());
                
                Log.Debug(args.ToString());
            }
        }
    }
}