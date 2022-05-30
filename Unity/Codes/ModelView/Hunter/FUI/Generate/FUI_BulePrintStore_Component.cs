/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET
{
    [FGUIComponent(Cfg.FGUIType.BulePrintStore)]
    public sealed partial class FUI_BulePrintStore_Component : Entity, IFGUIComponent
    {
        public const string UIPackageName = "Hunter";
        public const string UIResName = "FUI_BulePrintStore_Component";
        public const string URL = "ui://qasmgabsfeco6";

        public string GetAddressablePath() { return $"{UIPackageName}_fui"; }

        public string GetPackageName() { return UIPackageName; }

        public string GetComponentName() { return UIResName; }

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUIObject]
        public GGraph Bg;
        [FGUIObject]
        public GList BluePrintList;
        [FGUICustomCom]
        public Btn_LeaveStore Btn_LevelStore;
    }
}