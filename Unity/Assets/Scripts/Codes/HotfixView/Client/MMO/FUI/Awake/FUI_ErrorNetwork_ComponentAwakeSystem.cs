/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_ErrorNetwork_ComponentAwakeSystem : AwakeSystem<FUI_ErrorNetwork_Component>
    {
        protected override void Awake(FUI_ErrorNetwork_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_ErrorNetwork_Component";
            IFGUIComponent.URL = "ui://8c55kxcll43oec";
        }
    }
}