/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_Chat_ComponentAwakeSystem : AwakeSystem<FUI_Chat_Component>
    {
        protected override void Awake(FUI_Chat_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_Chat_Component";
            IFGUIComponent.URL = "ui://8c55kxcleym8m2qm";
        }
    }
}