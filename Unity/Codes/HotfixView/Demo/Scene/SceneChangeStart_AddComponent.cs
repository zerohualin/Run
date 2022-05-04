namespace ET
{
    public class SceneChangeStart_AddComponent: AEventAsync<EventType.SceneChangeStart>
    {
        protected override async ETTask Run(EventType.SceneChangeStart args)
        {
            await RunAsync(args);
        }
        
        private async ETTask RunAsync(EventType.SceneChangeStart args)
        {
            Scene currentScene = args.ZoneScene.CurrentScene();
            
            // 加载场景资源
            // await ResourcesComponent.Instance.LoadBundleAsync($"{currentScene.Name}.unity3d");
            // 切换到map场景

            SceneChangeComponent sceneChangeComponent = null;
            try
            {
                sceneChangeComponent = Game.Scene.AddComponent<SceneChangeComponent>();
                {
                    await sceneChangeComponent.ChangeSceneAsync(currentScene.Name);
                }
            }
            finally
            {
                sceneChangeComponent?.Dispose();
            }
            
            currentScene.AddComponent<OperaComponent>();
        }
    }
}