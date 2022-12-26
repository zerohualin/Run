/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_ErrorNetwork_ComponentSystem
    {
        public static void Init(this FUI_ErrorNetwork_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.ErrorNetwork)]
    [FriendOf(typeof(FUI_ErrorNetwork_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    public class FUI_ErrorNetwork_ComponentEvent: FGUIEvent<FUI_ErrorNetwork_Component>
    {
        public override void OnCreate(FUI_ErrorNetwork_Component component){}
        public override void OnShow(FUI_ErrorNetwork_Component component){}
        public override void OnRefresh(FUI_ErrorNetwork_Component component){}
        public override void OnHide(FUI_ErrorNetwork_Component component){}
        public override void OnDestroy(FUI_ErrorNetwork_Component component){}
    }
}