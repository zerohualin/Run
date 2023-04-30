namespace ET.Client
{
    [Event(SceneType.Client)]
    public class SceneChangeStart_AddComponent: AEvent<Scene, EventType.SceneChangeStart>
    {
        protected override async ETTask Run(Scene scene, EventType.SceneChangeStart args)
        {
            Scene currentScene = scene.CurrentScene();
            currentScene.AddComponent<CameraManagerComponent>();

            string path = $"Assets/Scenes/{currentScene.Name}.unity";
            await YooAssetProxy.LoadSceneAsync(path);
            
            currentScene.AddComponent<OperaComponent>();

            await ETTask.CompletedTask;
        }
    }
}