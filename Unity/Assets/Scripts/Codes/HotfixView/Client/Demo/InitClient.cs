using System;
using System.IO;
using Animancer;
using Bright.Serialization;
using Cfg;
using UnityEngine;
using YooAsset;

namespace ET.Client
{
    [Callback(CallbackType.InitClient)]
    public class InitClient: IFunc<ETTask>
    {
        public async ETTask Handle()
        {
            // 加载配置
            Game.Scene.AddComponent<ResourcesComponent>();
            
            Game.Scene.AddComponent<GlobalComponent>();

            await ResourcesComponent.Instance.LoadBundleAsync("unit.unity3d");
            
            Scene clientScene = await SceneFactory.CreateClientScene(1, "Game", Game.Scene);

            await HotfixProcedureHelper.OnEnter();
            
            await LubanComponent.Instance.LoadAsync(ByteBufLoader);

            Game.Scene.AddComponent<FGUIEventComponent>();
            Game.Scene.AddComponent<FGUIComponent>();

            await Game.Scene.GetComponent<FGUIComponent>().OpenAysnc(FGUIType.AFKBattle);

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