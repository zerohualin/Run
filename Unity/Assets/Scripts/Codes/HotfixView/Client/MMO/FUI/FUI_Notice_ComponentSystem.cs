/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    public static class FUI_Notice_ComponentSystem
    {
        public static void Init(this FUI_Notice_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.Notice)]
    [FriendOf(typeof(FUI_Notice_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    [FriendOfAttribute(typeof(ET.Client.Btn_Close))]
    public class FUI_Notice_ComponentEvent : FGUIEvent<FUI_Notice_Component>
    {
        public override void OnCreate(FUI_Notice_Component component)
        {
            component.Btn_Close.self.AddListener(() =>
            {
                FGUIComponent.Instance.Close(FGUIType.Notice);
            });
            component.Text_Title.text = "这不是游戏";
            component.Text_Content.text = "它现在不是，将会也大概不会是。";
        }
        public override void OnShow(FUI_Notice_Component component) { }
        public override void OnRefresh(FUI_Notice_Component component) { }
        public override void OnHide(FUI_Notice_Component component) { }
        public override void OnDestroy(FUI_Notice_Component component) { }
    }
}