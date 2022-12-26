/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class HeadBar : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUIObject]
        public GLoader icon;
        [FGUIObject]
        public GTextField title;
        [FGUIObject]
        public GImage network;
        [FGUICustomCom]
        public ProgressBarHp ProgressBarHp;
        [FGUICustomCom]
        public ProgressBarMp ProgressBarMp;
    }
}