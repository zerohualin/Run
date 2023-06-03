using Cfg;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class SceneChangeStart_StartLoadMapScene : AEvent<Scene, EventType.SceneChangeStart>
    {
        protected override async ETTask Run(Scene scene, EventType.SceneChangeStart args)
        {
            await scene.GetComponent<ProcedureComponent>().StartLoadMapScene(args.TargetSceneName);
        }
    }
}