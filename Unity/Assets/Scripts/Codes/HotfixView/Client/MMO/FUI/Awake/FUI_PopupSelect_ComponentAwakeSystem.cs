/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_PopupSelect_ComponentAwakeSystem : AwakeSystem<FUI_PopupSelect_Component>
    {
        protected override void Awake(FUI_PopupSelect_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_PopupSelect_Component";
            IFGUIComponent.URL = "ui://8c55kxclr2rtb5";
        }
    }
}