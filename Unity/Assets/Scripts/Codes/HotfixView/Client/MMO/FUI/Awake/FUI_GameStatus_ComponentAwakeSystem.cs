/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_GameStatus_ComponentAwakeSystem : AwakeSystem<FUI_GameStatus_Component>
    {
        protected override void Awake(FUI_GameStatus_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_GameStatus_Component";
            IFGUIComponent.URL = "ui://8c55kxclikqd2n9";
        }
    }
}