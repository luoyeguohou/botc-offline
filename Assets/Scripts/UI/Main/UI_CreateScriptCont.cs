/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_CreateScriptCont : GComponent
    {
        public GButton m_btnBack;
        public GTextInput m_txtScriptName;
        public GList m_lstCharacter;
        public GButton m_btnConfirm;
        public const string URL = "ui://mkospyuuvcll94";

        public static UI_CreateScriptCont CreateInstance()
        {
            return (UI_CreateScriptCont)UIPackage.CreateObject("Main", "CreateScriptCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btnBack = (GButton)GetChildAt(1);
            m_txtScriptName = (GTextInput)GetChildAt(2);
            m_lstCharacter = (GList)GetChildAt(3);
            m_btnConfirm = (GButton)GetChildAt(4);
        }
    }
}