/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_NightOrderWin : FairyWindow
    {
        public GLoader m_bg1;
        public UI_NIghtOrderCont m_cont;
        public const string URL = "ui://mkospyuuw7dk9j";

        public static UI_NightOrderWin CreateInstance()
        {
            return (UI_NightOrderWin)UIPackage.CreateObject("Main", "NightOrderWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_bg1 = (GLoader)GetChildAt(0);
            m_cont = (UI_NIghtOrderCont)GetChildAt(1);
        }
    }
}