using Cfg;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class SceneChangeFinishEvent_CreateUIHelp: AEvent<Scene, EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, EventType.SceneChangeFinish args)
        {
            await TimerComponent.Instance.WaitAsync(2000);
            await scene.GetComponent<FGUIComponent>().OpenAysnc(FGUIType.Play);
            scene.GetComponent<FGUIComponent>().Close(FGUIType.Loading);
        }
    }
}