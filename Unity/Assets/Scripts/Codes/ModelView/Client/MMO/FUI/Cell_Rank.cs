/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class Cell_Rank : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GButton self;

        [FGUIObject]
        public GImage Bg;
        [FGUIObject]
        public GTextField Text_Num;
        [FGUIObject]
        public GTextField Text_Star;
        [FGUIObject]
        public GTextField Text_Name;
    }
}