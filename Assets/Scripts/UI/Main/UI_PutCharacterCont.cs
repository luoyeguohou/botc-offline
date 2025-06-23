/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_PutCharacterCont : GComponent
    {
        public Controller m_choosingSpecific;
        public GTextField m_txtTitle;
        public GButton m_btnFinish;
        public GList m_lstCharacter;
        public GButton m_btnTownsfolk;
        public GButton m_btnOutsider;
        public GButton m_btnMinion;
        public GButton m_btnDemon;
        public GButton m_btnSpecific;
        public GList m_lstSpecific;
        public GButton m_btnConfirm;
        public const string URL = "ui://mkospyuugxos8l";

        public static UI_PutCharacterCont CreateInstance()
        {
            return (UI_PutCharacterCont)UIPackage.CreateObject("Main", "PutCharacterCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_choosingSpecific = GetControllerAt(0);
            m_txtTitle = (GTextField)GetChildAt(1);
            m_btnFinish = (GButton)GetChildAt(2);
            m_lstCharacter = (GList)GetChildAt(3);
            m_btnTownsfolk = (GButton)GetChildAt(4);
            m_btnOutsider = (GButton)GetChildAt(5);
            m_btnMinion = (GButton)GetChildAt(6);
            m_btnDemon = (GButton)GetChildAt(7);
            m_btnSpecific = (GButton)GetChildAt(8);
            m_lstSpecific = (GList)GetChildAt(10);
            m_btnConfirm = (GButton)GetChildAt(11);
        }
    }
}