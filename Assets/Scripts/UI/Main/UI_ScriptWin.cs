/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_ScriptWin : FairyWindow
    {
        public GLoader m_bg1;
        public UI_ScriptCont m_cont;
        public const string URL = "ui://mkospyuu9ckk0";

        public static UI_ScriptWin CreateInstance()
        {
            return (UI_ScriptWin)UIPackage.CreateObject("Main", "ScriptWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_bg1 = (GLoader)GetChildAt(0);
            m_cont = (UI_ScriptCont)GetChildAt(1);
        }
    }
}