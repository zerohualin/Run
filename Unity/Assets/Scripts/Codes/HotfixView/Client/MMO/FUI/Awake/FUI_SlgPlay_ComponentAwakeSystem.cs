/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_SlgPlay_ComponentAwakeSystem : AwakeSystem<FUI_SlgPlay_Component>
    {
        protected override void Awake(FUI_SlgPlay_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_SlgPlay_Component";
            IFGUIComponent.URL = "ui://8c55kxclac2wm2ni";
        }
    }
}