using Bright.Serialization;
using Cfg;
using UnityEngine;
using YooAsset;

namespace ET.Client
{
    [Event(SceneType.Process)]
    public class EntryEvent3_InitClient: AEvent<ET.EventType.EntryEvent3>
    {
        protected override async ETTask Run(Scene scene, ET.EventType.EntryEvent3 args)
        {
            // 加载配置
            Root.Instance.Scene.AddComponent<ResourcesComponent>();
            
            Root.Instance.Scene.AddComponent<GlobalComponent>();

            await ResourcesComponent.Instance.LoadBundleAsync("unit.unity3d");
            
            Scene clientScene = await SceneFactory.CreateClientScene(1, "Game");

            await LubanComponent.Instance.LoadAsync(ByteBufLoader);
            
            var FGUIComponent = clientScene.AddComponent<FGUIComponent>();
            FGUIComponent.AddComponent<FGUIEventComponent>();

            await clientScene.GetComponent<FGUIComponent>().OpenAysnc(FGUIType.AFKBattle);

            // await Game.EventSystem.PublishAsync(clientScene, new EventType.Goto_MiniGame());
            // await Game.EventSystem.PublishAsync(clientScene, new EventType.AppStartInitFinish());
        }
        
        private ByteBuf ByteBufLoader(string filename)
        {
            string path = $"Assets/BundleYoo/LubanBin/{filename}.bytes";
            var handle = YooAssets.LoadAssetSync<TextAsset>(path);
            var bytes = handle.GetAssetObject<TextAsset>().bytes;
            return new ByteBuf(bytes);
        }
    }
}