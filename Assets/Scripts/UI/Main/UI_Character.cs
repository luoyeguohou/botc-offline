/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_Character : GButton
    {
        public Controller m_inPlay;
        public GLoader m_img;
        public GTextField m_txtCont;
        public GTextField m_txtName;
        public const string URL = "ui://mkospyuuy7l25";

        public static UI_Character CreateInstance()
        {
            return (UI_Character)UIPackage.CreateObject("Main", "Character");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_inPlay = GetControllerAt(1);
            m_img = (GLoader)GetChildAt(2);
            m_txtCont = (GTextField)GetChildAt(5);
            m_txtName = (GTextField)GetChildAt(6);
        }
    }
}