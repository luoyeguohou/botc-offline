/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_AddRemindTokensWin : FairyWindow
    {
        public UI_AddRemindTokensCont m_cont;
        public const string URL = "ui://mkospyuuoj1u9f";

        public static UI_AddRemindTokensWin CreateInstance()
        {
            return (UI_AddRemindTokensWin)UIPackage.CreateObject("Main", "AddRemindTokensWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_cont = (UI_AddRemindTokensCont)GetChildAt(0);
        }
    }
}