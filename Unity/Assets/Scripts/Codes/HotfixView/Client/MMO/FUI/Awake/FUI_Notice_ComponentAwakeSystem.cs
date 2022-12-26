/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_Notice_ComponentAwakeSystem : AwakeSystem<FUI_Notice_Component>
    {
        protected override void Awake(FUI_Notice_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_Notice_Component";
            IFGUIComponent.URL = "ui://8c55kxclwzu0m2r9";
        }
    }
}