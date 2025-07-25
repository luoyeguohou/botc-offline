/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_PutCharacterWin : FairyWindow
    {
        public GLoader m_bg1;
        public UI_PutCharacterCont m_cont;
        public const string URL = "ui://mkospyuukt9f5r";

        public static UI_PutCharacterWin CreateInstance()
        {
            return (UI_PutCharacterWin)UIPackage.CreateObject("Main", "PutCharacterWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_bg1 = (GLoader)GetChildAt(0);
            m_cont = (UI_PutCharacterCont)GetChildAt(1);
        }
    }
}