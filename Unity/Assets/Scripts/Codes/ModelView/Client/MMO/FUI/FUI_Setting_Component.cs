/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.Setting)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_Setting_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUIObject]
        public GImage gray;
        [FGUIObject]
        public GTextField HintText;
        [FGUICustomCom]
        public Btn_Close Btn_Close;
        [FGUICustomCom]
        public Toggle_Setting Toggle_PushAlarm;
        [FGUICustomCom]
        public Btn_Quit Btn_QuitGame;
    }
}