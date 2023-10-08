/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public partial class FGUI_CheckButton : GButton
    {
        public Controller button;
        public GImage n4;
        public GTextField Text_Name;
        public const string URL = "ui://srx1uas5pns05";

        public static FGUI_CheckButton CreateInstance()
        {
            return (FGUI_CheckButton)UIPackage.CreateObject("CheckForResUpdate", "CheckButton", typeof(FGUI_CheckButton));
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            Text_Name = (GTextField)GetChildAt(1);
        }
    }
}