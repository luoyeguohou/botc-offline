/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_ScriptCont : GComponent
    {
        public Controller m_createScript;
        public GList m_lstScripts;
        public GButton m_btnCreateScript;
        public GButton m_btnBack1;
        public GTextInput m_txtScriptName;
        public GList m_lstCharacter;
        public GButton m_btnConfirm;
        public const string URL = "ui://mkospyuugxos8n";

        public static UI_ScriptCont CreateInstance()
        {
            return (UI_ScriptCont)UIPackage.CreateObject("Main", "ScriptCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_createScript = GetControllerAt(0);
            m_lstScripts = (GList)GetChildAt(0);
            m_btnCreateScript = (GButton)GetChildAt(1);
            m_btnBack1 = (GButton)GetChildAt(3);
            m_txtScriptName = (GTextInput)GetChildAt(4);
            m_lstCharacter = (GList)GetChildAt(5);
            m_btnConfirm = (GButton)GetChildAt(6);
        }
    }
}