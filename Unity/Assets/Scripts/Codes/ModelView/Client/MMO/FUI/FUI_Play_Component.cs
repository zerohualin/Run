/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.Play)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_Play_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUICustomCom]
        public Btn_PlayerInfo ButtonPlayerInfo;
        [FGUICustomCom]
        public Btn_Setting ButtonSetting;
        [FGUICustomCom]
        public Btn_Chat ButtonChat;
        [FGUICustomCom]
        public MoveJoystick MoveJoystick;
        [FGUICustomCom]
        public Btn_PlayA ButtonPlayA;
        [FGUICustomCom]
        public Btn_PlayB ButtonPlayB;
        [FGUIObject]
        public GGroup NormalController;
    }
}