/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_Inventory_ComponentSystem
    {
        public static void Init(this FUI_Inventory_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.Inventory)]
    [FriendOf(typeof(FUI_Inventory_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    public class FUI_Inventory_ComponentEvent: FGUIEvent<FUI_Inventory_Component>
    {
        public override void OnCreate(FUI_Inventory_Component component){}
        public override void OnShow(FUI_Inventory_Component component){}
        public override void OnRefresh(FUI_Inventory_Component component){}
        public override void OnHide(FUI_Inventory_Component component){}
        public override void OnDestroy(FUI_Inventory_Component component){}
    }
}