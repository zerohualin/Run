/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET
{
    [FGUIComponent(Cfg.FGUIType.ZesuDemoSelect)]
    public sealed partial class FUI_ZesuDemoSelect_Component : Entity, IFGUIComponent
    {
        public const string UIPackageName = "ZeusDemos";
        public const string UIResName = "FUI_ZesuDemoSelect_Component";
        public const string URL = "ui://4gaby71ov3w90";

        public string GetAddressablePath() { return $"{UIPackageName}_fui"; }

        public string GetPackageName() { return UIPackageName; }

        public string GetComponentName() { return UIResName; }

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUICustomCom]
        public Btn_SelectDemo Btn_SelectDemo;
    }
}