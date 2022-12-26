/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_BattleVs_ComponentAwakeSystem : AwakeSystem<FUI_BattleVs_Component>
    {
        protected override void Awake(FUI_BattleVs_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_BattleVs_Component";
            IFGUIComponent.URL = "ui://8c55kxclhnd6hn";
        }
    }
}