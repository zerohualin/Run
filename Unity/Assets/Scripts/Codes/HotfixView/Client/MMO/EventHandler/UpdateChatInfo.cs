using Cfg;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class UpdateChatInfo: AEvent<Scene, EventType.UpdateChatInfo>
    {
        protected override async ETTask Run(Scene scene,EventType.UpdateChatInfo args)
        {
            FUI_Chat_Component component = FGUIComponent.Instance.Get<FUI_Chat_Component>(FGUIType.Chat);
            
            component?.Refresh();
            
            await ETTask.CompletedTask;
        }
    }
}