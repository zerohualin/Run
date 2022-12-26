/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.PopupInput)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_PopupInput_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUICustomCom]
        public BgGray btnBg;
        [FGUIObject]
        public GTextInput input;
        [FGUICustomCom]
        public Btn_Gray OkBtn;
        [FGUIObject]
        public GTextField titleText;
        [FGUIObject]
        public GTextField buttonText;
    }
}