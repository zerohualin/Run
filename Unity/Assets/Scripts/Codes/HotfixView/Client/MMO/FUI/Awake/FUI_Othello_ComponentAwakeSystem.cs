/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_Othello_ComponentAwakeSystem : AwakeSystem<FUI_Othello_Component>
    {
        protected override void Awake(FUI_Othello_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_Othello_Component";
            IFGUIComponent.URL = "ui://8c55kxcli36bm2rb";
        }
    }
}