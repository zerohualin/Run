/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public partial class FGUI_UIBackgroundComponent : GComponent
    {
        public GImage n1;
        public const string URL = "ui://d3gnvpdkzo1jg";

        public static FGUI_UIBackgroundComponent CreateInstance()
        {
            return (FGUI_UIBackgroundComponent)UIPackage.CreateObject("ABaseComponents", "UIBackgroundComponent", typeof(FGUI_UIBackgroundComponent));
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
        }
    }
}