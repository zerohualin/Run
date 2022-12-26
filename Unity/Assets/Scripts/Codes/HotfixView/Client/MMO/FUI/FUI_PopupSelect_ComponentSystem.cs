/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_PopupSelect_ComponentSystem
    {
        public static void Init(this FUI_PopupSelect_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.PopupSelect)]
    [FriendOf(typeof(FUI_PopupSelect_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    [FriendOf(typeof(Btn_Middle))]
    public class FUI_PopupSelect_ComponentEvent: FGUIEvent<FUI_PopupSelect_Component>
    {
        public override void OnCreate(FUI_PopupSelect_Component component){}
        public override void OnShow(FUI_PopupSelect_Component component){}
        public override void OnRefresh(FUI_PopupSelect_Component component){}
        public override void OnHide(FUI_PopupSelect_Component component){}
        public override void OnDestroy(FUI_PopupSelect_Component component){}
    }
}