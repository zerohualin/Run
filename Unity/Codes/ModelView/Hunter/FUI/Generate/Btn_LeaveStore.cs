/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET
{
    public sealed partial class Btn_LeaveStore : Entity, IFGUIComponent
    {
        public const string UIPackageName = "Hunter";
        public const string UIResName = "Btn_LeaveStore";
        public const string URL = "ui://qasmgabsfecoa";

        public string GetAddressablePath() { return $"{UIPackageName}_fui"; }

        public string GetPackageName() { return UIPackageName; }

        public string GetComponentName() { return UIResName; }

        [FGUISelfObjectAttribute]
        public GButton self;

        [FGUIObject]
        public GTextField Title;
    }
}