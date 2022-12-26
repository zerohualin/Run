/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_BottomCheck_ComponentAwakeSystem : AwakeSystem<FUI_BottomCheck_Component>
    {
        protected override void Awake(FUI_BottomCheck_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_BottomCheck_Component";
            IFGUIComponent.URL = "ui://8c55kxcla3wsi2";
        }
    }
}