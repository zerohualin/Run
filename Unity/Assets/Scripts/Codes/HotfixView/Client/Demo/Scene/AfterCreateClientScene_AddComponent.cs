namespace ET.Client
{
    [Event(SceneType.Client)]
    public class AfterCreateClientScene_AddComponent: AEvent<EventType.AfterCreateClientScene>
    {
        protected override async ETTask Run(Scene scene, EventType.AfterCreateClientScene args)
        {
            var FGUIComponent = scene.AddComponent<FGUIComponent>();
            FGUIComponent.AddComponent<FGUIEventComponent>();
            await ETTask.CompletedTask;
        }
    }
}