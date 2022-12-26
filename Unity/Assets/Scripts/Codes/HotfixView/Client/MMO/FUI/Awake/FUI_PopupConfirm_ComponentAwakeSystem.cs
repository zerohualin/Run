/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_PopupConfirm_ComponentAwakeSystem : AwakeSystem<FUI_PopupConfirm_Component>
    {
        protected override void Awake(FUI_PopupConfirm_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_PopupConfirm_Component";
            IFGUIComponent.URL = "ui://8c55kxclb0ztb9";
        }
    }
}