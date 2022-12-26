/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class Cell_SlgUnit : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUIObject]
        public GTextField TitleText;
        [FGUIObject]
        public GTextField AtkText;
        [FGUIObject]
        public GTextField PhyDefText;
        [FGUIObject]
        public GTextField MoveText;
        [FGUIObject]
        public GTextField TitleText_2;
    }
}