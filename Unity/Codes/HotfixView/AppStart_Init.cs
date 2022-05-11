using Bright.Serialization;
using UnityEngine;

namespace ET
{
    public class AppStart_Init: AEvent<EventType.AppStart>
    {
        protected override void Run(EventType.AppStart args)
        {
            RunAsync(args).Coroutine();
        }
        
        private async ETTask RunAsync(EventType.AppStart args)
        {
            MongoRegister.Init();
            
            Game.Scene.AddComponent<TimerComponent>();
            Game.Scene.AddComponent<CoroutineLockComponent>();

            // Game.Scene.AddComponent<AddressableComponent>();
            Game.Scene.AddComponent<LubanComponent>();
            await LubanComponent.Instance.LoadAsync(ByteBufLoader);
            
            // 加载配置
            Game.Scene.AddComponent<ResourcesComponent>();
            await ResourcesComponent.Instance.LoadBundleAsync("config.unity3d");
            Game.Scene.AddComponent<ConfigComponent>();
            ConfigComponent.Instance.Load();
            ResourcesComponent.Instance.UnloadBundle("config.unity3d");
            
            Game.Scene.AddComponent<OpcodeTypeComponent>();
            Game.Scene.AddComponent<MessageDispatcherComponent>();
            
            Game.Scene.AddComponent<NetThreadComponent>();
            Game.Scene.AddComponent<SessionStreamDispatcher>();
            Game.Scene.AddComponent<ZoneSceneManagerComponent>();
            
            Game.Scene.AddComponent<GlobalComponent>();
            Game.Scene.AddComponent<NumericWatcherComponent>();
            Game.Scene.AddComponent<AIDispatcherComponent>();

            // Scene zoneScene = SceneFactory.CreateZoneScene(1, "Game", Game.Scene);
            Scene zoneScene = await SceneFactory.CreateMarsZoneSceneAsync(0, "MarsDemo", Game.Scene);

            Game.EventSystem.PublishAsync(new EventType.AppStartInitFinish() { ZoneScene = zoneScene }).Coroutine();
        }
        
        private ByteBuf ByteBufLoader(string file)
        {
            TextAsset config = AddressableComponent.Instance.LoadAssetByPath<TextAsset>(file);
            return new ByteBuf(config.bytes);
        }
    }
}
