/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.CharacterDialog)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_CharacterDialog_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUIObject]
        public GImage CharacterIcon;
        [FGUIObject]
        public GImage ActionIcon;
        [FGUIObject]
        public GTextField ButtonText;
        [FGUIObject]
        public GTextField ContentText;
    }
}