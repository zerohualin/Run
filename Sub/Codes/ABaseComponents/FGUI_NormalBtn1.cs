/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public partial class FGUI_NormalBtn1 : GButton
    {
        public Controller button;
        public GImage n0;
        public GImage n1;
        public GImage n2;
        public GImage n3;
        public GTextField title;
        public const string URL = "ui://d3gnvpdkotnu0";

        public static FGUI_NormalBtn1 CreateInstance()
        {
            return (FGUI_NormalBtn1)UIPackage.CreateObject("ABaseComponents", "NormalBtn1", typeof(FGUI_NormalBtn1));
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            n3 = (GImage)GetChildAt(3);
            title = (GTextField)GetChildAt(4);
        }
    }
}