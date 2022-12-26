/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_SlgPlay_ComponentSystem
    {
        public static void Init(this FUI_SlgPlay_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.SlgPlay)]
    [FriendOf(typeof(FUI_SlgPlay_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    public class FUI_SlgPlay_ComponentEvent: FGUIEvent<FUI_SlgPlay_Component>
    {
        public override void OnCreate(FUI_SlgPlay_Component component){}
        public override void OnShow(FUI_SlgPlay_Component component){}
        public override void OnRefresh(FUI_SlgPlay_Component component){}
        public override void OnHide(FUI_SlgPlay_Component component){}
        public override void OnDestroy(FUI_SlgPlay_Component component){}
    }
}