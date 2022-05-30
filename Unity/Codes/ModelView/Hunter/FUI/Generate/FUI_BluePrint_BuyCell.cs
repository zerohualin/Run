/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET
{
    public sealed partial class FUI_BluePrint_BuyCell : Entity, IFGUIComponent
    {
        public const string UIPackageName = "Hunter";
        public const string UIResName = "FUI_BluePrint_BuyCell";
        public const string URL = "ui://qasmgabsfeco8";

        public string GetAddressablePath() { return $"{UIPackageName}_fui"; }

        public string GetPackageName() { return UIPackageName; }

        public string GetComponentName() { return UIResName; }

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUICustomCom]
        public FUI_BulePrint BluePrint;
        [FGUICustomCom]
        public Btn_BuyBluePrint Btn_BluePrint;
    }
}