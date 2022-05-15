using Cfg;

namespace ET
{
    public class HunterInitFinishHandler : AEventAsync<EventType.HunterInitFinish>
    {
        protected override async ETTask Run(EventType.HunterInitFinish args)
        {
            args.ZoneScene.AddComponent<FGUIComponent>();
            args.ZoneScene.AddComponent<FGUIEventComponent>();
            
            await FGUIComponent.Instance.OpenAysnc(FGUIType.HunterBattle);
            
            args.ZoneScene.AddComponent<CameraManagerComponent>();
        }
    }
}