namespace ET
{
    public class AfterCreateZoneScene_AddComponent: AEventAsync<EventType.AfterCreateZoneScene>
    {
        protected override async ETTask Run(EventType.AfterCreateZoneScene args)
        {
            Scene zoneScene = args.ZoneScene;
            await Game.EventSystem.PublishAsync(new EventType.SceneChangeStart() {ZoneScene = zoneScene});
            
        }
    }
}