using Bright.Serialization;
using UnityEngine;

namespace ET
{
    public class Hunter_Init: AEvent<EventType.HunterStart>
    {
        protected override void Run(EventType.HunterStart args)
        {
            RunAsync().Coroutine();
        }
        
        public async ETTask RunAsync()
        {
            MongoRegister.Init();
            
            Game.Scene.AddComponent<TimerComponent>();
            Game.Scene.AddComponent<CoroutineLockComponent>();

            Game.Scene.AddComponent<AddressableComponent>();
            Game.Scene.AddComponent<LubanComponent>();
            await LubanComponent.Instance.LoadAsync(ByteBufLoader);
            
            // 加载配置
            Game.Scene.AddComponent<ResourcesComponent>();
            await ResourcesComponent.Instance.LoadBundleAsync("config.unity3d");
            Game.Scene.AddComponent<ConfigComponent>();
            ConfigComponent.Instance.Load();
            ResourcesComponent.Instance.UnloadBundle("config.unity3d");
            
            Game.Scene.AddComponent<GlobalComponent>();

            Game.Scene.AddComponent<UserInputComponent>();
            
            Game.Scene.AddComponent<OpcodeTypeComponent>();
            Game.Scene.AddComponent<MessageDispatcherComponent>();
            
            Game.Scene.AddComponent<NetThreadComponent>();
            Game.Scene.AddComponent<SessionStreamDispatcher>();
            Game.Scene.AddComponent<ZoneSceneManagerComponent>();

            Game.Scene.AddComponent<NumericWatcherComponent>();
            Game.Scene.AddComponent<AIDispatcherComponent>();
            
            Scene zoneScene = await SceneFactory.CreateHunterZoneSceneAsync(0, "HunterBattle", Game.Scene);
            
            Game.EventSystem.PublishAsync(new EventType.HunterInitFinish() { ZoneScene = zoneScene }).Coroutine();
        }
        
        private static ByteBuf ByteBufLoader(string file)
        {
            TextAsset config = AddressableComponent.Instance.LoadAssetByPath<TextAsset>(file);
            return new ByteBuf(config.bytes);
        }
    }
}