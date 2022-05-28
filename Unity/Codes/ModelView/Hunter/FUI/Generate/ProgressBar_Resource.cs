/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET
{
    public sealed partial class ProgressBar_Resource : Entity, IFGUIComponent
    {
        public const string UIPackageName = "Hunter";
        public const string UIResName = "ProgressBar_Resource";
        public const string URL = "ui://qasmgabsjggg5";

        public string GetAddressablePath() { return $"{UIPackageName}_fui"; }

        public string GetPackageName() { return UIPackageName; }

        public string GetComponentName() { return UIResName; }

        [FGUISelfObjectAttribute]
        public GProgressBar self;

        [FGUIObject]
        public GGraph Bg;
        [FGUIObject]
        public GGraph Bar;
        [FGUIObject]
        public GTextField ProgressTxt;
        [FGUIObject]
        public GTextField ProgressTitle;
    }
}