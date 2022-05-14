namespace ET
{
    public static class UnitHelper
    {
        public static Unit GetMyUnitFromZoneScene(Scene zoneScene)
        {
            PlayerComponent playerComponent = zoneScene.GetComponent<PlayerComponent>();
            Scene currentScene = zoneScene.GetComponent<CurrentScenesComponent>().Scene;
            return currentScene.GetComponent<UnitComponent>().Get(playerComponent.MyId);
        }
        
        public static Unit GetMyUnitFromCurrentScene(Scene currentScene)
        {
            PlayerComponent playerComponent = currentScene.Parent.Parent.GetComponent<PlayerComponent>();
            return currentScene.GetComponent<UnitComponent>().Get(playerComponent.MyId);
        }

        public static Unit GetMyUnitFromBattleRoom(Scene currentScene)
        {
            var room = currentScene.GetComponent<RoomManagerComponent>().GetOrCreateBattleRoom();
            PlayerComponent playerComponent = currentScene.GetComponent<PlayerComponent>();
            return room.GetComponent<UnitComponent>().Get(playerComponent.MyId);
        }
    }
}