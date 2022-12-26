/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class MoveJoystick : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUIObject]
        public GGraph touchArea;
        [FGUIObject]
        public GImage bg;
        [FGUIObject]
        public GImage dirDownRight;
        [FGUIObject]
        public GImage dirDownLeft;
        [FGUIObject]
        public GImage dirUpLeft;
        [FGUIObject]
        public GImage dirUpRight;
        [FGUIObject]
        public GImage thumb;
    }
}