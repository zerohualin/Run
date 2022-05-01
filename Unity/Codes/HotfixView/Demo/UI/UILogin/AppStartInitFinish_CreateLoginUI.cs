namespace ET
{
    public class AppStartInitFinish_CreateLoginUI: AEvent<EventType.AppStartInitFinish>
    {
        protected override void Run(EventType.AppStartInitFinish args)
        {
            args.ZoneScene.AddComponent<FGUIComponent>();
            args.ZoneScene.AddComponent<FGUIEventComponent>();
            
            // UIHelper.Create(args.ZoneScene, UIType.UILogin, UILayer.Mid).Coroutine();
            Game.EventSystem.Publish(new EventType.AnimatorDemoStart() { ZoneScene = args.ZoneScene });
            Game.EventSystem.PublishAsync(new EventType.FUIDemoStart() { });
            Game.EventSystem.Publish(new EventType.LubanDemoStart());
        }
    }
}