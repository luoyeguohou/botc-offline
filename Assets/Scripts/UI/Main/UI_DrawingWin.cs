/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_DrawingWin : FairyWindow
    {
        public GLoader m_bg;
        public UI_DrawingCont m_cont;
        public const string URL = "ui://mkospyuuivx25u";

        public static UI_DrawingWin CreateInstance()
        {
            return (UI_DrawingWin)UIPackage.CreateObject("Main", "DrawingWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_bg = (GLoader)GetChildAt(0);
            m_cont = (UI_DrawingCont)GetChildAt(1);
        }
    }
}