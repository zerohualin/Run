/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_PopupConfirm_ComponentSystem
    {
        public static void Init(this FUI_PopupConfirm_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.PopupConfirm)]
    [FriendOf(typeof(FUI_PopupConfirm_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    [FriendOf(typeof(Btn_Middle))]
    public class FUI_PopupConfirm_ComponentEvent: FGUIEvent<FUI_PopupConfirm_Component>
    {
        public override void OnCreate(FUI_PopupConfirm_Component component){}
        public override void OnShow(FUI_PopupConfirm_Component component){}
        public override void OnRefresh(FUI_PopupConfirm_Component component){}
        public override void OnHide(FUI_PopupConfirm_Component component){}
        public override void OnDestroy(FUI_PopupConfirm_Component component){}
    }
}