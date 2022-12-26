/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_BattleGround_ComponentAwakeSystem : AwakeSystem<FUI_BattleGround_Component>
    {
        protected override void Awake(FUI_BattleGround_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_BattleGround_Component";
            IFGUIComponent.URL = "ui://8c55kxclfprihx";
        }
    }
}