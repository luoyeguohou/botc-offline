/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_ChooseWhoDrawFirstCont : GComponent
    {
        public Controller m_direction;
        public GButton m_btnDirection;
        public GButton m_btnStart;
        public GComboBox m_comboBox;
        public const string URL = "ui://mkospyuugxos8i";

        public static UI_ChooseWhoDrawFirstCont CreateInstance()
        {
            return (UI_ChooseWhoDrawFirstCont)UIPackage.CreateObject("Main", "ChooseWhoDrawFirstCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_direction = GetControllerAt(0);
            m_btnDirection = (GButton)GetChildAt(0);
            m_btnStart = (GButton)GetChildAt(3);
            m_comboBox = (GComboBox)GetChildAt(4);
        }
    }
}