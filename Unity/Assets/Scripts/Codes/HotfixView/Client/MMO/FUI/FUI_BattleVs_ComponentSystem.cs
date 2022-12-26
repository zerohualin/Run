/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_BattleVs_ComponentSystem
    {
        public static void Init(this FUI_BattleVs_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.BattleVs)]
    [FriendOf(typeof(FUI_BattleVs_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    public class FUI_BattleVs_ComponentEvent: FGUIEvent<FUI_BattleVs_Component>
    {
        public override void OnCreate(FUI_BattleVs_Component component){}
        public override void OnShow(FUI_BattleVs_Component component){}
        public override void OnRefresh(FUI_BattleVs_Component component){}
        public override void OnHide(FUI_BattleVs_Component component){}
        public override void OnDestroy(FUI_BattleVs_Component component){}
    }
}