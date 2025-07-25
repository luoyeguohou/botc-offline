/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_CreateScriptWin : FairyWindow
    {
        public UI_CreateScriptCont m_cont;
        public const string URL = "ui://mkospyuuvcll93";

        public static UI_CreateScriptWin CreateInstance()
        {
            return (UI_CreateScriptWin)UIPackage.CreateObject("Main", "CreateScriptWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_cont = (UI_CreateScriptCont)GetChildAt(0);
        }
    }
}