/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.BattleVs)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_BattleVs_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUIObject]
        public GGraph BgColor;
        [FGUIObject]
        public GTextField PlayerA;
        [FGUIObject]
        public GTextField PlayerB;
        [FGUIObject]
        public GImage greenShadow;
        [FGUIObject]
        public GImage blueShadow;
        [FGUIObject]
        public Transition Vs;
    }
}