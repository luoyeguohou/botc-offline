/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_Player : GComponent
    {
        public Controller m_dead;
        public Controller m_hasRole;
        public Controller m_outline;
        public Controller m_isRealPlayer;
        public Controller m_hasDeadVote;
        public Controller m_isGood;
        public GLoader m_img;
        public GTextInput m_txtInputName;
        public GTextInput m_txtCharacter;
        public GList m_lstState;
        public const string URL = "ui://mkospyuuplih5x";

        public static UI_Player CreateInstance()
        {
            return (UI_Player)UIPackage.CreateObject("Main", "Player");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_dead = GetControllerAt(0);
            m_hasRole = GetControllerAt(1);
            m_outline = GetControllerAt(2);
            m_isRealPlayer = GetControllerAt(3);
            m_hasDeadVote = GetControllerAt(4);
            m_isGood = GetControllerAt(5);
            m_img = (GLoader)GetChildAt(2);
            m_txtInputName = (GTextInput)GetChildAt(5);
            m_txtCharacter = (GTextInput)GetChildAt(7);
            m_lstState = (GList)GetChildAt(8);
        }
    }
}