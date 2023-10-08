/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public partial class FGUI_CheckForResUpdate : GComponent
    {
        public GGraph Bg;
        public FGUI_CheckForResUpdateBar ProgressBarDownload;
        public GTextInput TextProgress;
        public const string URL = "ui://srx1uas5lo9d0";

        public static FGUI_CheckForResUpdate CreateInstance()
        {
            return (FGUI_CheckForResUpdate)UIPackage.CreateObject("CheckForResUpdate", "CheckForResUpdate", typeof(FGUI_CheckForResUpdate));
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Bg = (GGraph)GetChildAt(0);
            ProgressBarDownload = (FGUI_CheckForResUpdateBar)GetChildAt(1);
            TextProgress = (GTextInput)GetChildAt(2);
        }
    }
}