/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.SlgPlay)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_SlgPlay_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUICustomCom]
        public Btn_DiamandNext ButtonNext;
        [FGUICustomCom]
        public Btn_DiamandRestart ButtonRestart;
        [FGUIObject]
        public GList UnitCardList;
        [FGUIObject]
        public GTextField RoundText;
        [FGUIObject]
        public GTextField ActionTeamText;
        [FGUIObject]
        public GGroup Round;
    }
}