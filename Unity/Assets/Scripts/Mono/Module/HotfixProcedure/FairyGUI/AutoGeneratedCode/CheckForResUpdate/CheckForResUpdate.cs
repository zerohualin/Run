/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public partial class CheckForResUpdate : GComponent
    {
        public GGraph Bg;
        public GImage n3;
        public FGUI_CheckForResUpdateBar ProgressBarDownload;
        public GTextInput TextProgress;
        public const string URL = "ui://srx1uas5lo9d0";

        public static CheckForResUpdate CreateInstance()
        {
            return (CheckForResUpdate)UIPackage.CreateObject("CheckForResUpdate", "CheckForResUpdate", typeof(CheckForResUpdate));
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Bg = (GGraph)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            ProgressBarDownload = (FGUI_CheckForResUpdateBar)GetChildAt(2);
            TextProgress = (GTextInput)GetChildAt(3);
        }
    }
}