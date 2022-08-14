/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public partial class FGUI_CheckWindow : GComponent
    {
        public GGraph mask2;
        public GLoader Bg;
        public GTextField Text_Title;
        public GList ButtonList;
        public GRichTextField Text_Content;
        public GGroup Group;
        public const string URL = "ui://srx1uas5pns04";

        public static FGUI_CheckWindow CreateInstance()
        {
            return (FGUI_CheckWindow)UIPackage.CreateObject("CheckForResUpdate", "CheckWindow", typeof(FGUI_CheckWindow));
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            mask2 = (GGraph)GetChildAt(0);
            Bg = (GLoader)GetChildAt(1);
            Text_Title = (GTextField)GetChildAt(2);
            ButtonList = (GList)GetChildAt(3);
            Text_Content = (GRichTextField)GetChildAt(4);
            Group = (GGroup)GetChildAt(5);
        }
    }
}