/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_Lobby_ComponentAwakeSystem : AwakeSystem<FUI_Lobby_Component>
    {
        protected override void Awake(FUI_Lobby_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_Lobby_Component";
            IFGUIComponent.URL = "ui://8c55kxclpmm04h";
        }
    }
}