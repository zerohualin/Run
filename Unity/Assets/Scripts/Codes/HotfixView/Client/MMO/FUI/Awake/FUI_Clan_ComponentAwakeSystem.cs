/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public class FUI_Clan_ComponentAwakeSystem : AwakeSystem<FUI_Clan_Component>
    {
        protected override void Awake(FUI_Clan_Component self)
        {
            var IFGUIComponent = self.GetParent<FGUIEntity>().AddComponent<IFGUIComponent>();
            IFGUIComponent.UIPackageName = "MMO";
            IFGUIComponent.UIResName = "FUI_Clan_Component";
            IFGUIComponent.URL = "ui://8c55kxclm4bjfa";
        }
    }
}