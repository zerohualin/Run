using Cfg;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class SceneChangeFinishEvent_CreateUIHelp: AEvent<Scene, EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, EventType.SceneChangeFinish args)
        {
            scene.GetComponent<ProcedureComponent>().FinishCreateUnits();
        }
    }
}