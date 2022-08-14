/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public partial class CheckForResUpdateBar : GProgressBar
    {
        public GGraph n0;
        public GGraph bar;
        public const string URL = "ui://srx1uas5lo9d1";

        public static CheckForResUpdateBar CreateInstance()
        {
            return (CheckForResUpdateBar)UIPackage.CreateObject("CheckForResUpdate", "CheckForResUpdateBar", typeof(CheckForResUpdateBar));
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GGraph)GetChildAt(0);
            bar = (GGraph)GetChildAt(1);
        }
    }
}