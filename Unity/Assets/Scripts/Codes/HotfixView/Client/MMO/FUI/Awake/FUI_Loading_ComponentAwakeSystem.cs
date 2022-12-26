/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_Loading_ComponentAwakeSystem : AwakeSystem<FUI_Loading_Component>
    {
        protected override void Awake(FUI_Loading_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_Loading_Component";
            IFGUIComponent.URL = "ui://8c55kxcl122dm2na";
        }
    }
}