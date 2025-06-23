/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_PutPlayNameWin : FairyWindow
    {
        public GLoader m_bg;
        public UI_PutPlayerNameCont m_cont;
        public const string URL = "ui://mkospyuukt9f5p";

        public static UI_PutPlayNameWin CreateInstance()
        {
            return (UI_PutPlayNameWin)UIPackage.CreateObject("Main", "PutPlayNameWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_bg = (GLoader)GetChildAt(0);
            m_cont = (UI_PutPlayerNameCont)GetChildAt(1);
        }
    }
}