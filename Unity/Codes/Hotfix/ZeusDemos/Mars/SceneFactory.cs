namespace ET
{
    public static partial class SceneFactory
    {
        public static async ETTask<Scene> CreateMarsZoneSceneAsync(int zone, string name, Entity parent)
        {
            Scene zoneScene = EntitySceneFactory.CreateScene(Game.IdGenerater.GenerateInstanceId(), zone, SceneType.Zone, name, parent);
            zoneScene.AddComponent<CurrentScenesComponent>();
            zoneScene.GetComponent<CurrentScenesComponent>().Scene = zoneScene;
            
            zoneScene.AddComponent<ZoneSceneFlagComponent>();
            zoneScene.AddComponent<ObjectWait>();
            zoneScene.AddComponent<PlayerComponent>();
            zoneScene.AddComponent<B2S_ColliderDataRepositoryComponent>();
            zoneScene.AddComponent<RoomManagerComponent>();
            
            var room = zoneScene.GetComponent<RoomManagerComponent>().GetOrCreateBattleRoom();
            
            await Game.EventSystem.PublishAsync(new EventType.AfterCreateZoneScene() { ZoneScene = zoneScene });
            
            var unit = MarsUnitFactory.CreateUnit(room, IdGenerater.Instance.GenerateUnitId(zoneScene.Zone), 1001);
            
            return zoneScene;
        }
    }
}