/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_Setting_ComponentAwakeSystem : AwakeSystem<FUI_Setting_Component>
    {
        protected override void Awake(FUI_Setting_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_Setting_Component";
            IFGUIComponent.URL = "ui://8c55kxclq5qfm2r6";
        }
    }
}