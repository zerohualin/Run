/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET
{
    public static class FUI_AnimatorDemo_ComponentSystem
    {
        public static void Awake(this FUI_AnimatorDemo_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.AnimatorDemo)]
    [FriendClass(typeof(FUI_AnimatorDemo_Component))]
    [FriendClass(typeof(Btn_SelectDemo))]
    public class FUI_AnimatorDemo_ComponentEvent: FGUIEvent<FUI_AnimatorDemo_Component>
    {
        public override void OnCreate(FUI_AnimatorDemo_Component component){}
        public override void OnShow(FUI_AnimatorDemo_Component component){}
        public override void OnRefresh(FUI_AnimatorDemo_Component component){}
        public override void OnHide(FUI_AnimatorDemo_Component component){}
        public override void OnDestroy(FUI_AnimatorDemo_Component component){}
    }
}