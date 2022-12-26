/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_BattleResult_ComponentSystem
    {
        public static void Init(this FUI_BattleResult_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.BattleResult)]
    [FriendOf(typeof(FUI_BattleResult_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    public class FUI_BattleResult_ComponentEvent: FGUIEvent<FUI_BattleResult_Component>
    {
        public override void OnCreate(FUI_BattleResult_Component component){}
        public override void OnShow(FUI_BattleResult_Component component){}
        public override void OnRefresh(FUI_BattleResult_Component component){}
        public override void OnHide(FUI_BattleResult_Component component){}
        public override void OnDestroy(FUI_BattleResult_Component component){}
    }
}