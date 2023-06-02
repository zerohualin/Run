/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.PopupConfirm)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_PopupConfirm_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUICustomCom]
        public BgGray BgGray;
        [FGUIObject]
        public GImage Bg;
        [FGUIObject]
        public GImage Line;
        [FGUIObject]
        public GTextField Text_Title;
        [FGUIObject]
        public GTextField Text_Context;
        [FGUICustomCom]
        public Btn_Middle Btn_Confirm;
        [FGUICustomCom]
        public Btn_Close Btn_Close;
    }
}