/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_Inventory_ComponentAwakeSystem : AwakeSystem<FUI_Inventory_Component>
    {
        protected override void Awake(FUI_Inventory_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_Inventory_Component";
            IFGUIComponent.URL = "ui://8c55kxclb4xu7l";
        }
    }
}