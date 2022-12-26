/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.BattleGround)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_BattleGround_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUIObject]
        public GImage Bg;
        [FGUICustomCom]
        public Btn_Exit ButtonExit;
        [FGUICustomCom]
        public Btn_Middle ButtonCheck;
        [FGUIObject]
        public GTextField HintText;
    }
}