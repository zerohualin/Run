/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_CharacterDialog_ComponentAwakeSystem : AwakeSystem<FUI_CharacterDialog_Component>
    {
        protected override void Awake(FUI_CharacterDialog_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_CharacterDialog_Component";
            IFGUIComponent.URL = "ui://8c55kxclwpll2ml";
        }
    }
}