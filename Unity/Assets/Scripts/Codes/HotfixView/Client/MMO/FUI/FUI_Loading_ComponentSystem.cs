/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_Loading_ComponentSystem
    {
        public static void Init(this FUI_Loading_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.Loading)]
    [FriendOf(typeof(FUI_Loading_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    public class FUI_Loading_ComponentEvent: FGUIEvent<FUI_Loading_Component>
    {
        public override void OnCreate(FUI_Loading_Component component){}
        public override void OnShow(FUI_Loading_Component component){}
        public override void OnRefresh(FUI_Loading_Component component){}
        public override void OnHide(FUI_Loading_Component component){}
        public override void OnDestroy(FUI_Loading_Component component){}
    }
}