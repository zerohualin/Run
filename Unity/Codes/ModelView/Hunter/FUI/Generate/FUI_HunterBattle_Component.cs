/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET
{
    [FGUIComponent(Cfg.FGUIType.HunterBattle)]
    public sealed partial class FUI_HunterBattle_Component : Entity, IFGUIComponent
    {
        public const string UIPackageName = "Hunter";
        public const string UIResName = "FUI_HunterBattle_Component";
        public const string URL = "ui://qasmgabsqouv0";

        public string GetAddressablePath() { return $"{UIPackageName}_fui"; }

        public string GetPackageName() { return UIPackageName; }

        public string GetComponentName() { return UIResName; }

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUIObject]
        public GList CardList;
        [FGUIObject]
        public GTextField TurnTxt;
        [FGUICustomCom]
        public Btn_EndTurn Btn_EndTurn;
        [FGUICustomCom]
        public ProgressBar_Energy ProgressBar_Energy;
    }
}