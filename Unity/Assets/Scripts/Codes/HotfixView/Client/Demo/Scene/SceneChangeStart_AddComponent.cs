using Cfg;
using UnityEngine.SceneManagement;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class SceneChangeStart_AddComponent: AEvent<EventType.SceneChangeStart>
    {
        protected override async ETTask Run(Scene scene, EventType.SceneChangeStart args)
        {
            Scene currentScene = scene.CurrentScene();
            
            await SceneManager.LoadSceneAsync(currentScene.Name);
            
            currentScene.AddComponent<OperaComponent>();
            currentScene.AddComponent<CameraManagerComponent>();
        }
    }
}