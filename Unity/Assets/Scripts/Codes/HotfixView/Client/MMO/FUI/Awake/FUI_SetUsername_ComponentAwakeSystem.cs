/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_SetUsername_ComponentAwakeSystem : AwakeSystem<FUI_SetUsername_Component>
    {
        protected override void Awake(FUI_SetUsername_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_SetUsername_Component";
            IFGUIComponent.URL = "ui://8c55kxclou114l";
        }
    }
}