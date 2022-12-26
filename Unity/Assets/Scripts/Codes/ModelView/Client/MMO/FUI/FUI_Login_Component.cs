/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.Login)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_Login_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUIObject]
        public GTextInput Input_Account;
        [FGUIObject]
        public GTextInput Input_Password;
        [FGUICustomCom]
        public Btn_Login Btn_Login;
        [FGUIObject]
        public GGroup Group;
    }
}