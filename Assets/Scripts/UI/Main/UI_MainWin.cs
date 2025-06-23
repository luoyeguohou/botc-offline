/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_MainWin : FairyWindow
    {
        public GLoader m_bg;
        public UI_MainCont m_cont;
        public const string URL = "ui://mkospyuupa1f5v";

        public static UI_MainWin CreateInstance()
        {
            return (UI_MainWin)UIPackage.CreateObject("Main", "MainWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_bg = (GLoader)GetChildAt(0);
            m_cont = (UI_MainCont)GetChildAt(1);
        }
    }
}