/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_EmojiSelect_ComponentAwakeSystem : AwakeSystem<FUI_EmojiSelect_Component>
    {
        protected override void Awake(FUI_EmojiSelect_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_EmojiSelect_Component";
            IFGUIComponent.URL = "ui://8c55kxclx224e7";
        }
    }
}