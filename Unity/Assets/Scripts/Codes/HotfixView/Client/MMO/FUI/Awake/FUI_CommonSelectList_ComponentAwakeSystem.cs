/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_CommonSelectList_ComponentAwakeSystem : AwakeSystem<FUI_CommonSelectList_Component>
    {
        protected override void Awake(FUI_CommonSelectList_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_CommonSelectList_Component";
            IFGUIComponent.URL = "ui://8c55kxcljdk1m2ng";
        }
    }
}