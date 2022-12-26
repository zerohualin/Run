/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_BattleGround_ComponentSystem
    {
        public static void Init(this FUI_BattleGround_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.BattleGround)]
    [FriendOf(typeof(FUI_BattleGround_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    public class FUI_BattleGround_ComponentEvent: FGUIEvent<FUI_BattleGround_Component>
    {
        public override void OnCreate(FUI_BattleGround_Component component){}
        public override void OnShow(FUI_BattleGround_Component component){}
        public override void OnRefresh(FUI_BattleGround_Component component){}
        public override void OnHide(FUI_BattleGround_Component component){}
        public override void OnDestroy(FUI_BattleGround_Component component){}
    }
}