/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_EmojiSelect_ComponentSystem
    {
        public static void Init(this FUI_EmojiSelect_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.EmojiSelect)]
    [FriendOf(typeof(FUI_EmojiSelect_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    public class FUI_EmojiSelect_ComponentEvent: FGUIEvent<FUI_EmojiSelect_Component>
    {
        public override void OnCreate(FUI_EmojiSelect_Component component){}
        public override void OnShow(FUI_EmojiSelect_Component component){}
        public override void OnRefresh(FUI_EmojiSelect_Component component){}
        public override void OnHide(FUI_EmojiSelect_Component component){}
        public override void OnDestroy(FUI_EmojiSelect_Component component){}
    }
}