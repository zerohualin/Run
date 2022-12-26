/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.PopupSelect)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_PopupSelect_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUICustomCom]
        public Btn_Close ButtonClose;
        [FGUIObject]
        public GTextField title;
        [FGUIObject]
        public GTextField content;
        [FGUICustomCom]
        public Btn_Middle ButtonCancel;
        [FGUICustomCom]
        public Btn_Middle ButtonConfirm;
    }
}