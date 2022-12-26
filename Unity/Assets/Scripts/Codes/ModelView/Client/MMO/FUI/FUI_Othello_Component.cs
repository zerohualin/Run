/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.Othello)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_Othello_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUIObject]
        public GGraph Bg;
        [FGUIObject]
        public GImage Board;
        [FGUIObject]
        public GList List;
        [FGUIObject]
        public GRichTextField Text_Next;
    }
}