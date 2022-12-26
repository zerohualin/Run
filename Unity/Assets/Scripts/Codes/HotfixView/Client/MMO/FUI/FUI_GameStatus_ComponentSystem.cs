/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_GameStatus_ComponentSystem
    {
        public static void Init(this FUI_GameStatus_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.GameStatus)]
    [FriendOf(typeof(FUI_GameStatus_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    public class FUI_GameStatus_ComponentEvent: FGUIEvent<FUI_GameStatus_Component>
    {
        public override void OnCreate(FUI_GameStatus_Component component){}
        public override void OnShow(FUI_GameStatus_Component component){}
        public override void OnRefresh(FUI_GameStatus_Component component){}
        public override void OnHide(FUI_GameStatus_Component component){}
        public override void OnDestroy(FUI_GameStatus_Component component){}
    }
}