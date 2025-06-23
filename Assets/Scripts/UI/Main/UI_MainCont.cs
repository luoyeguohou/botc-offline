/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_MainCont : GComponent
    {
        public Controller m_state;
        public Controller m_selectWords;
        public Controller m_dealWithPlayer;
        public Controller m_dead;
        public Controller m_selectCharacter;
        public Controller m_firstNight;
        public GComponent m_emp;
        public GList m_lstNightCharacter;
        public GButton m_btnFirstNight;
        public GTextField m_txtCounter;
        public GButton m_btnAdd60s;
        public GButton m_btnAdd30s;
        public GButton m_btnReset;
        public GButton m_btnShowSth;
        public GTextInput m_txtText;
        public GList m_lstShowingCharacter;
        public GList m_lstShowingWords;
        public GButton m_btnFinish;
        public GButton m_btnAddCahracter;
        public GButton m_btnMinusCahracter;
        public GButton m_btnSelectWords;
        public GList m_lstStateWords;
        public GTextInput m_txtState;
        public GButton m_btnAddState;
        public GButton m_btnBackDealPlayers;
        public GList m_lstStates;
        public GButton m_btnDead;
        public GList m_lstSpecific;
        public GButton m_btnConfirm;
        public const string URL = "ui://mkospyuugxos8k";

        public static UI_MainCont CreateInstance()
        {
            return (UI_MainCont)UIPackage.CreateObject("Main", "MainCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_state = GetControllerAt(0);
            m_selectWords = GetControllerAt(1);
            m_dealWithPlayer = GetControllerAt(2);
            m_dead = GetControllerAt(3);
            m_selectCharacter = GetControllerAt(4);
            m_firstNight = GetControllerAt(5);
            m_emp = (GComponent)GetChildAt(0);
            m_lstNightCharacter = (GList)GetChildAt(1);
            m_btnFirstNight = (GButton)GetChildAt(2);
            m_txtCounter = (GTextField)GetChildAt(3);
            m_btnAdd60s = (GButton)GetChildAt(4);
            m_btnAdd30s = (GButton)GetChildAt(5);
            m_btnReset = (GButton)GetChildAt(6);
            m_btnShowSth = (GButton)GetChildAt(7);
            m_txtText = (GTextInput)GetChildAt(10);
            m_lstShowingCharacter = (GList)GetChildAt(11);
            m_lstShowingWords = (GList)GetChildAt(13);
            m_btnFinish = (GButton)GetChildAt(14);
            m_btnAddCahracter = (GButton)GetChildAt(15);
            m_btnMinusCahracter = (GButton)GetChildAt(16);
            m_btnSelectWords = (GButton)GetChildAt(17);
            m_lstStateWords = (GList)GetChildAt(19);
            m_txtState = (GTextInput)GetChildAt(21);
            m_btnAddState = (GButton)GetChildAt(22);
            m_btnBackDealPlayers = (GButton)GetChildAt(23);
            m_lstStates = (GList)GetChildAt(25);
            m_btnDead = (GButton)GetChildAt(26);
            m_lstSpecific = (GList)GetChildAt(28);
            m_btnConfirm = (GButton)GetChildAt(29);
        }
    }
}