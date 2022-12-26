/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_SetUsername_ComponentSystem
    {
        public static void Init(this FUI_SetUsername_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.SetUsername)]
    [FriendOf(typeof(FUI_SetUsername_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    [FriendOf(typeof(Btn_Gray))]
    public class FUI_SetUsername_ComponentEvent: FGUIEvent<FUI_SetUsername_Component>
    {
        public override void OnCreate(FUI_SetUsername_Component component){}
        public override void OnShow(FUI_SetUsername_Component component){}
        public override void OnRefresh(FUI_SetUsername_Component component){}
        public override void OnHide(FUI_SetUsername_Component component){}
        public override void OnDestroy(FUI_SetUsername_Component component){}
    }
}