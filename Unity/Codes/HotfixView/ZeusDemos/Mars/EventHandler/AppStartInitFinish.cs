using Cfg;

namespace ET
{
    public class AppStartInitFinish : AEventAsync<EventType.AppStartInitFinish>
    {
        protected override async ETTask Run(EventType.AppStartInitFinish args)
        {
            args.ZoneScene.AddComponent<FGUIComponent>();
            args.ZoneScene.AddComponent<FGUIEventComponent>();
            
            await FGUIComponent.Instance.OpenAysnc(FGUIType.ZesuDemoSelect);
            
            args.ZoneScene.AddComponent<CameraManagerComponent>();
        }
    }
}