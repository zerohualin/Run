/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_CharacterDialog_ComponentSystem
    {
        public static void Init(this FUI_CharacterDialog_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.CharacterDialog)]
    [FriendOf(typeof(FUI_CharacterDialog_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    public class FUI_CharacterDialog_ComponentEvent: FGUIEvent<FUI_CharacterDialog_Component>
    {
        public override void OnCreate(FUI_CharacterDialog_Component component){}
        public override void OnShow(FUI_CharacterDialog_Component component){}
        public override void OnRefresh(FUI_CharacterDialog_Component component){}
        public override void OnHide(FUI_CharacterDialog_Component component){}
        public override void OnDestroy(FUI_CharacterDialog_Component component){}
    }
}