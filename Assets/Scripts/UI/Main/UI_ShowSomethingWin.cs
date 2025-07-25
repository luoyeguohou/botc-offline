/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_ShowSomethingWin : FairyWindow
    {
        public GLoader m_bg1;
        public UI_ShowSomethingCont m_cont;
        public const string URL = "ui://mkospyuuwu429c";

        public static UI_ShowSomethingWin CreateInstance()
        {
            return (UI_ShowSomethingWin)UIPackage.CreateObject("Main", "ShowSomethingWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_bg1 = (GLoader)GetChildAt(0);
            m_cont = (UI_ShowSomethingCont)GetChildAt(1);
        }
    }
}