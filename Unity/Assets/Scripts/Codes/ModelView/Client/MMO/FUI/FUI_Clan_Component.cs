/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.Clan)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_Clan_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUIObject]
        public GImage Bg;
        [FGUIObject]
        public GList List;
        [FGUICustomCom]
        public Btn_Back Btn_Back;
        [FGUIObject]
        public GImage focus;
        [FGUICustomCom]
        public Btn_Search Btn_Search;
        [FGUICustomCom]
        public Btn_AddRoom Btn_AddRoom;
    }
}