/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class Cell_MJRoom : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GButton self;

        [FGUIObject]
        public GImage bg;
        [FGUIObject]
        public GRichTextField Text_Name;
        [FGUIObject]
        public GImage Icon;
        [FGUIObject]
        public GImage actionIcon;
        [FGUIObject]
        public GRichTextField actionText;
        [FGUIObject]
        public GGroup actionF;
        [FGUIObject]
        public GRichTextField Text_ReadyState;
    }
}