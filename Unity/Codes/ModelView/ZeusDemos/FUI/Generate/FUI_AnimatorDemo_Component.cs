/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET
{
    [FGUIComponent(Cfg.FGUIType.AnimatorDemo)]
    public sealed partial class FUI_AnimatorDemo_Component : Entity, IFGUIComponent
    {
        public const string UIPackageName = "ZeusDemos";
        public const string UIResName = "FUI_AnimatorDemo_Component";
        public const string URL = "ui://4gaby71ogerh2";

        public string GetAddressablePath() { return $"{UIPackageName}_fui"; }

        public string GetPackageName() { return UIPackageName; }

        public string GetComponentName() { return UIResName; }

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUICustomCom]
        public Btn_SelectDemo Btn_ChangeAnima1;
    }
}