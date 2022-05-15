/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET
{
    public sealed partial class FUI_Card : Entity, IFGUIComponent
    {
        public const string UIPackageName = "Hunter";
        public const string UIResName = "FUI_Card";
        public const string URL = "ui://qasmgabscw0i3";

        public string GetAddressablePath() { return $"{UIPackageName}_fui"; }

        public string GetPackageName() { return UIPackageName; }

        public string GetComponentName() { return UIResName; }

        [FGUISelfObjectAttribute]
        public GButton self;

        [FGUIObject]
        public GGraph CanUseFrame;
        [FGUIObject]
        public GGraph Bg;
        [FGUIObject]
        public GGraph ContentFrame;
        [FGUIObject]
        public GRichTextField TitleTxt;
        [FGUIObject]
        public GRichTextField ContentTxt;
        [FGUIObject]
        public GRichTextField CostTxt;
    }
}