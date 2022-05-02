/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET
{
    public sealed class Btn_SelectDemo : Entity, IFGUIComponent, IAwake<GObject>
    {
        public const string UIPackageName = "ZesuDemos";
        public const string UIResName = "Btn_SelectDemo";
        public const string URL = "ui://4gaby71ov3w91";

        public string GetAddressablePath() { return $"{UIPackageName}_fui"; }

        public string GetPackageName() { return UIPackageName; }

        public string GetComponentName() { return UIResName; }

        [FGUISelfObjectAttribute]
        public GButton self;

        [FGUIObject]
        public GGraph Bg;
        [FGUIObject]
        public GTextField Txt_Title;
    }
}