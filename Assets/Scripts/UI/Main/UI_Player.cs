/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_Player : GComponent
    {
        public Controller m_state;
        public Controller m_dead;
        public GLoader m_img;
        public GTextInput m_txtInputName;
        public GTextInput m_txtCharacter;
        public GList m_lstState;
        public GTextField m_txtName;
        public const string URL = "ui://mkospyuuplih5x";

        public static UI_Player CreateInstance()
        {
            return (UI_Player)UIPackage.CreateObject("Main", "Player");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_state = GetControllerAt(0);
            m_dead = GetControllerAt(1);
            m_img = (GLoader)GetChildAt(1);
            m_txtInputName = (GTextInput)GetChildAt(4);
            m_txtCharacter = (GTextInput)GetChildAt(6);
            m_lstState = (GList)GetChildAt(7);
            m_txtName = (GTextField)GetChildAt(8);
        }
    }
}