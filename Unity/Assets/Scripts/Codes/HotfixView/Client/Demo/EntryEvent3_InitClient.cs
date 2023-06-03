using Bright.Serialization;
using Cfg;
using UnityEngine;
using YooAsset;

namespace ET.Client
{
    [Event(SceneType.Process)]
    public class EntryEvent3_InitClient: AEvent<Scene, ET.EventType.EntryEvent3>
    {
        protected override async ETTask Run(Scene scene, ET.EventType.EntryEvent3 args)
        {
            // 加载配置
            Root.Instance.Scene.AddComponent<ResourcesComponent>();
            
            Root.Instance.Scene.AddComponent<GlobalComponent>();

            Root.Instance.Scene.AddComponent<AnimaResourceComponent>();

            
            // await ResourcesComponent.Instance.LoadBundleAsync("unit.unity3d");
            
            Scene clientScene = await SceneFactory.CreateClientScene(1, "Game");
            
#if UNITY_EDITOR
            clientScene.AddComponent<UnityDebugComponent>();   
#endif

            await LubanComponent.Instance.LoadAsync(ByteBufLoader);
            
            var FGUIComponent = clientScene.AddComponent<FGUIComponent>();
            FGUIComponent.AddComponent<FGUIEventComponent>();

            await clientScene.GetComponent<FGUIComponent>().OpenAysnc(FGUIType.SelectServer);

            // await Game.EventSystem.PublishAsync(clientScene, new EventType.Goto_MiniGame());
            // await Game.EventSystem.PublishAsync(clientScene, new EventType.AppStartInitFinish());
        }
        
        private ByteBuf ByteBufLoader(string filename)
        {
            string path = $"Assets/BundleYoo/LubanBin/{filename}.bytes";
            var handle = YooAssets.LoadRawFileSync(path);
            var bytes = handle.GetRawFileData();
            return new ByteBuf(bytes);
        }
    }
}