/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_ChangeSeatWin : FairyWindow
    {
        public GLoader m_bg1;
        public UI_ChangeSeatCont m_cont;
        public const string URL = "ui://mkospyuuh32k97";

        public static UI_ChangeSeatWin CreateInstance()
        {
            return (UI_ChangeSeatWin)UIPackage.CreateObject("Main", "ChangeSeatWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_bg1 = (GLoader)GetChildAt(0);
            m_cont = (UI_ChangeSeatCont)GetChildAt(1);
        }
    }
}