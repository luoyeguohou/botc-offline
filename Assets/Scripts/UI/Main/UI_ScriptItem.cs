/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_ScriptItem : GComponent
    {
        public Controller m_custom;
        public GTextField m_txtName;
        public GButton m_btnPick;
        public GButton m_btnEdit;
        public GButton m_btnDelete;
        public const string URL = "ui://mkospyuukt9f5o";

        public static UI_ScriptItem CreateInstance()
        {
            return (UI_ScriptItem)UIPackage.CreateObject("Main", "ScriptItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_custom = GetControllerAt(0);
            m_txtName = (GTextField)GetChildAt(1);
            m_btnPick = (GButton)GetChildAt(2);
            m_btnEdit = (GButton)GetChildAt(3);
            m_btnDelete = (GButton)GetChildAt(4);
        }
    }
}