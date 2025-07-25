/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_ShowSomethingCont : GComponent
    {
        public Controller m_selectWord;
        public Controller m_selectCharacter;
        public GTextInput m_txtText;
        public GList m_lstShowingCharacter;
        public GButton m_btnFinish;
        public GButton m_btnAddCahracter;
        public GButton m_btnMinusCahracter;
        public GButton m_btnSelectWords;
        public GList m_lstShowingWords;
        public GList m_lstSpecific;
        public GButton m_btnConfirm;
        public const string URL = "ui://mkospyuuwu429d";

        public static UI_ShowSomethingCont CreateInstance()
        {
            return (UI_ShowSomethingCont)UIPackage.CreateObject("Main", "ShowSomethingCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_selectWord = GetControllerAt(0);
            m_selectCharacter = GetControllerAt(1);
            m_txtText = (GTextInput)GetChildAt(1);
            m_lstShowingCharacter = (GList)GetChildAt(2);
            m_btnFinish = (GButton)GetChildAt(3);
            m_btnAddCahracter = (GButton)GetChildAt(4);
            m_btnMinusCahracter = (GButton)GetChildAt(5);
            m_btnSelectWords = (GButton)GetChildAt(6);
            m_lstShowingWords = (GList)GetChildAt(8);
            m_lstSpecific = (GList)GetChildAt(10);
            m_btnConfirm = (GButton)GetChildAt(11);
        }
    }
}