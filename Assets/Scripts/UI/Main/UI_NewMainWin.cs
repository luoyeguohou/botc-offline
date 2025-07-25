/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_NewMainWin : FairyWindow
    {
        public GLoader m_bg1;
        public UI_NewMainCont m_cont;
        public const string URL = "ui://mkospyuuperk91";

        public static UI_NewMainWin CreateInstance()
        {
            return (UI_NewMainWin)UIPackage.CreateObject("Main", "NewMainWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_bg1 = (GLoader)GetChildAt(0);
            m_cont = (UI_NewMainCont)GetChildAt(1);
        }
    }
}