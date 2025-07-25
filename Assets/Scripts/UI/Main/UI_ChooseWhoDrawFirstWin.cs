/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_ChooseWhoDrawFirstWin : FairyWindow
    {
        public GLoader m_bg1;
        public UI_ChooseWhoDrawFirstCont m_cont;
        public const string URL = "ui://mkospyuuspc15s";

        public static UI_ChooseWhoDrawFirstWin CreateInstance()
        {
            return (UI_ChooseWhoDrawFirstWin)UIPackage.CreateObject("Main", "ChooseWhoDrawFirstWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_bg1 = (GLoader)GetChildAt(0);
            m_cont = (UI_ChooseWhoDrawFirstCont)GetChildAt(1);
        }
    }
}