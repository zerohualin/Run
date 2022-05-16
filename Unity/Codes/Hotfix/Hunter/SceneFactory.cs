namespace ET
{
    public static partial class SceneFactory
    {
        public static async ETTask<Scene> CreateHunterZoneSceneAsync(int zone, string name, Entity parent)
        {
            Scene zoneScene = EntitySceneFactory.CreateScene(Game.IdGenerater.GenerateInstanceId(), zone, SceneType.Zone, name, parent);
            
            zoneScene.AddComponent<CurrentScenesComponent>();
            zoneScene.GetComponent<CurrentScenesComponent>().Scene = zoneScene;

            zoneScene.AddComponent<ZoneSceneFlagComponent>();
            zoneScene.AddComponent<ObjectWait>();

            zoneScene.AddComponent<RoomManagerComponent>();
            zoneScene.GetComponent<RoomManagerComponent>().CreatCardRoom(20220515);

            await Game.EventSystem.PublishAsync(new EventType.AfterCreateZoneScene() { ZoneScene = zoneScene });
            return zoneScene;
        }
    }
}