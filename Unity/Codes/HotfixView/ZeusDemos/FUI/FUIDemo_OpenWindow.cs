using Cfg;

namespace ET
{
    public class FUIDemo_OpenWindow: AEventAsync<EventType.FUIDemoStart>
    {
        protected override async ETTask Run(EventType.FUIDemoStart args)
        {
            await FGUIComponent.Instance.OpenAysnc(FGUIType.ZesuDemoSelect);
            // FGUIComponent.Instance.Close(FGUIType.Background);
        }
    }
}