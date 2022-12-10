/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public partial class CheckButton : GButton
    {
        public Controller button;
        public GImage Bg;
        public GTextField Text_Name;
        public const string URL = "ui://srx1uas5pns05";

        public static CheckButton CreateInstance()
        {
            return (CheckButton)UIPackage.CreateObject("CheckForResUpdate", "CheckButton", typeof(CheckButton));
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            Bg = (GImage)GetChildAt(0);
            Text_Name = (GTextField)GetChildAt(1);
        }
    }
}