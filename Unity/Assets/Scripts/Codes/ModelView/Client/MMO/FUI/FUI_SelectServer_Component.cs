/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.SelectServer)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_SelectServer_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUICustomCom]
        public BgGray Btn_Bg;
        [FGUICustomCom]
        public Btn_RightSlash userNameBtn;
        [FGUICustomCom]
        public Btn_RightSlash serverListBtn;
        [FGUICustomCom]
        public Btn_Notice Btn_Notice;
        [FGUIObject]
        public GRichTextField Text_Version;
    }
}