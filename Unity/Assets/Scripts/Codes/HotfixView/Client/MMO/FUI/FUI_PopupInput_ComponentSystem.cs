/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_PopupInput_ComponentSystem
    {
        public static void Init(this FUI_PopupInput_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.PopupInput)]
    [FriendOf(typeof(FUI_PopupInput_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    public class FUI_PopupInput_ComponentEvent: FGUIEvent<FUI_PopupInput_Component>
    {
        public override void OnCreate(FUI_PopupInput_Component component){}
        public override void OnShow(FUI_PopupInput_Component component){}
        public override void OnRefresh(FUI_PopupInput_Component component){}
        public override void OnHide(FUI_PopupInput_Component component){}
        public override void OnDestroy(FUI_PopupInput_Component component){}
    }
}