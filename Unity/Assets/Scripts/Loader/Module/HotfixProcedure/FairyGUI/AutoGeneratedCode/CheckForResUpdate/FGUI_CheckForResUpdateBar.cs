/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public partial class FGUI_CheckForResUpdateBar : GProgressBar
    {
        public GGraph n0;
        public GGraph bar;
        public const string URL = "ui://srx1uas5lo9d1";

        public static FGUI_CheckForResUpdateBar CreateInstance()
        {
            return (FGUI_CheckForResUpdateBar)UIPackage.CreateObject("CheckForResUpdate", "CheckForResUpdateBar", typeof(FGUI_CheckForResUpdateBar));
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GGraph)GetChildAt(0);
            bar = (GGraph)GetChildAt(1);
        }
    }
}