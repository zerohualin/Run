/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_BottomCheck_ComponentSystem
    {
        public static void Init(this FUI_BottomCheck_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.BottomCheck)]
    [FriendOf(typeof(FUI_BottomCheck_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    [FriendOf(typeof(Btn_Middle))]
    public class FUI_BottomCheck_ComponentEvent: FGUIEvent<FUI_BottomCheck_Component>
    {
        public override void OnCreate(FUI_BottomCheck_Component component){}
        public override void OnShow(FUI_BottomCheck_Component component){}
        public override void OnRefresh(FUI_BottomCheck_Component component){}
        public override void OnHide(FUI_BottomCheck_Component component){}
        public override void OnDestroy(FUI_BottomCheck_Component component){}
    }
}