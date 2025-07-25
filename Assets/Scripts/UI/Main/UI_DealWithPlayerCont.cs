/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_DealWithPlayerCont : GComponent
    {
        public Controller m_isTraveller;
        public Controller m_isPlayer;
        public Controller m_isGood;
        public Controller m_hasDeadVote;
        public Controller m_isDead;
        public GButton m_btnDeletePlayer;
        public GButton m_btnChangeSeat;
        public GButton m_btnClose;
        public GButton m_btnTraveller;
        public GButton m_btnMoveToSeat;
        public GButton m_btnChangeRole;
        public UI_Player m_player;
        public GButton m_btnAddRemind;
        public GButton m_btnAlignment;
        public GButton m_btnDeadVote;
        public GList m_lstStates;
        public GTextField m_txtAbility;
        public GButton m_btnDead;
        public const string URL = "ui://mkospyuuh32k95";

        public static UI_DealWithPlayerCont CreateInstance()
        {
            return (UI_DealWithPlayerCont)UIPackage.CreateObject("Main", "DealWithPlayerCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_isTraveller = GetControllerAt(0);
            m_isPlayer = GetControllerAt(1);
            m_isGood = GetControllerAt(2);
            m_hasDeadVote = GetControllerAt(3);
            m_isDead = GetControllerAt(4);
            m_btnDeletePlayer = (GButton)GetChildAt(1);
            m_btnChangeSeat = (GButton)GetChildAt(2);
            m_btnClose = (GButton)GetChildAt(3);
            m_btnTraveller = (GButton)GetChildAt(4);
            m_btnMoveToSeat = (GButton)GetChildAt(5);
            m_btnChangeRole = (GButton)GetChildAt(6);
            m_player = (UI_Player)GetChildAt(7);
            m_btnAddRemind = (GButton)GetChildAt(8);
            m_btnAlignment = (GButton)GetChildAt(9);
            m_btnDeadVote = (GButton)GetChildAt(10);
            m_lstStates = (GList)GetChildAt(12);
            m_txtAbility = (GTextField)GetChildAt(13);
            m_btnDead = (GButton)GetChildAt(14);
        }
    }
}