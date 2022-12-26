/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_BattleResult_ComponentAwakeSystem : AwakeSystem<FUI_BattleResult_Component>
    {
        protected override void Awake(FUI_BattleResult_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_BattleResult_Component";
            IFGUIComponent.URL = "ui://8c55kxclgqzmi0";
        }
    }
}