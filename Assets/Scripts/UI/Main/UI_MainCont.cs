/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_MainCont : GComponent
    {
        public Controller m_state;
        public Controller m_firstNight;
        public GComponent m_emp;
        public GList m_lstTips;
        public GButton m_btnAddTip;
        public GButton m_btnShowSth;
        public GButton m_btnAddPerson;
        public GButton m_btnPickScript;
        public GButton m_btnDrawTokens;
        public GButton m_btnShuffleRoles;
        public GButton m_btnNightOrder;
        public GButton m_btnPickRoles;
        public GTextField m_txtScript;
        public GList m_lstRoleInPlay;
        public GList m_lstNightOrder;
        public GButton m_btnBackToLastGame;
        public GLoader m_btnChinese;
        public GLoader m_btnEnglish;
        public const string URL = "ui://mkospyuua48c92";

        public static UI_MainCont CreateInstance()
        {
            return (UI_MainCont)UIPackage.CreateObject("Main", "MainCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_state = GetControllerAt(0);
            m_firstNight = GetControllerAt(1);
            m_emp = (GComponent)GetChildAt(0);
            m_lstTips = (GList)GetChildAt(1);
            m_btnAddTip = (GButton)GetChildAt(2);
            m_btnShowSth = (GButton)GetChildAt(3);
            m_btnAddPerson = (GButton)GetChildAt(4);
            m_btnPickScript = (GButton)GetChildAt(5);
            m_btnDrawTokens = (GButton)GetChildAt(6);
            m_btnShuffleRoles = (GButton)GetChildAt(7);
            m_btnNightOrder = (GButton)GetChildAt(8);
            m_btnPickRoles = (GButton)GetChildAt(9);
            m_txtScript = (GTextField)GetChildAt(11);
            m_lstRoleInPlay = (GList)GetChildAt(12);
            m_lstNightOrder = (GList)GetChildAt(13);
            m_btnBackToLastGame = (GButton)GetChildAt(14);
            m_btnChinese = (GLoader)GetChildAt(15);
            m_btnEnglish = (GLoader)GetChildAt(16);
        }
    }
}