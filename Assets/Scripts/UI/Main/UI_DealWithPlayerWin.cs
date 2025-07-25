/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_DealWithPlayerWin : FairyWindow
    {
        public UI_DealWithPlayerCont m_cont;
        public const string URL = "ui://mkospyuuh32k96";

        public static UI_DealWithPlayerWin CreateInstance()
        {
            return (UI_DealWithPlayerWin)UIPackage.CreateObject("Main", "DealWithPlayerWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_cont = (UI_DealWithPlayerCont)GetChildAt(0);
        }
    }
}