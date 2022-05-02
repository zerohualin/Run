/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET
{
    public static class FUI_BattleDemo_ComponentSystem
    {
        public static void Awake(this FUI_BattleDemo_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.BattleDemo)]
    [FriendClass(typeof(FUI_BattleDemo_Component))]
    [FriendClass(typeof(Btn_SelectDemo))]
    public class FUI_BattleDemo_ComponentEvent: FGUIEvent<FUI_BattleDemo_Component>
    {
        public override void OnCreate(FUI_BattleDemo_Component component){}
        public override void OnShow(FUI_BattleDemo_Component component){}
        public override void OnRefresh(FUI_BattleDemo_Component component){}
        public override void OnHide(FUI_BattleDemo_Component component){}
        public override void OnDestroy(FUI_BattleDemo_Component component){}
    }
}