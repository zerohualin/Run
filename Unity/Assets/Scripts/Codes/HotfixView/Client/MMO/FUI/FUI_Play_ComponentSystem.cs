/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_Play_ComponentSystem
    {
        public static void Init(this FUI_Play_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.Play)]
    [FriendOf(typeof(FUI_Play_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    public class FUI_Play_ComponentEvent: FGUIEvent<FUI_Play_Component>
    {
        public override void OnCreate(FUI_Play_Component component){}
        public override void OnShow(FUI_Play_Component component){}
        public override void OnRefresh(FUI_Play_Component component){}
        public override void OnHide(FUI_Play_Component component){}
        public override void OnDestroy(FUI_Play_Component component){}
    }
}