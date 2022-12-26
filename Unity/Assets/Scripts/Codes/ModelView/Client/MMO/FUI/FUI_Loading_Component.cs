/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.Loading)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_Loading_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUIObject]
        public GImage windmill;
        [FGUIObject]
        public Transition t0;
        [FGUIObject]
        public Transition Close;
        [FGUIObject]
        public Transition Show;
    }
}