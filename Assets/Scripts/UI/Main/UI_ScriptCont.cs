/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_ScriptCont : GComponent
    {
        public GButton m_btnClose;
        public GButton m_btnFromJson;
        public GList m_lstScripts;
        public GButton m_btnCreateScript;
        public const string URL = "ui://mkospyuugxos8n";

        public static UI_ScriptCont CreateInstance()
        {
            return (UI_ScriptCont)UIPackage.CreateObject("Main", "ScriptCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btnClose = (GButton)GetChildAt(0);
            m_btnFromJson = (GButton)GetChildAt(1);
            m_lstScripts = (GList)GetChildAt(2);
            m_btnCreateScript = (GButton)GetChildAt(3);
        }
    }
}