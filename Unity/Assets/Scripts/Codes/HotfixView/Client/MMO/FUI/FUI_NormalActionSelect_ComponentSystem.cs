/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_NormalActionSelect_ComponentSystem
    {
        public static void Init(this FUI_NormalActionSelect_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.NormalActionSelect)]
    [FriendOf(typeof(FUI_NormalActionSelect_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    public class FUI_NormalActionSelect_ComponentEvent: FGUIEvent<FUI_NormalActionSelect_Component>
    {
        public override void OnCreate(FUI_NormalActionSelect_Component component){}
        public override void OnShow(FUI_NormalActionSelect_Component component){}
        public override void OnRefresh(FUI_NormalActionSelect_Component component){}
        public override void OnHide(FUI_NormalActionSelect_Component component){}
        public override void OnDestroy(FUI_NormalActionSelect_Component component){}
    }
}