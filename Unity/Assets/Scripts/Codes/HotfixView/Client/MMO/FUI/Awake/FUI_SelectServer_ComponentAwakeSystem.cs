/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_SelectServer_ComponentAwakeSystem : AwakeSystem<FUI_SelectServer_Component>
    {
        protected override void Awake(FUI_SelectServer_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_SelectServer_Component";
            IFGUIComponent.URL = "ui://8c55kxclw9ob7k";
        }
    }
}