/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_DrawingCont : GComponent
    {
        public Controller m_state;
        public GTextField m_txtTitle;
        public GButton m_btnLook;
        public GButton m_btnFinish;
        public GLoader m_imgCharacter;
        public GTextField m_txtCont;
        public GButton m_btnStartGame;
        public const string URL = "ui://mkospyuugxos8j";

        public static UI_DrawingCont CreateInstance()
        {
            return (UI_DrawingCont)UIPackage.CreateObject("Main", "DrawingCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_state = GetControllerAt(0);
            m_txtTitle = (GTextField)GetChildAt(1);
            m_btnLook = (GButton)GetChildAt(2);
            m_btnFinish = (GButton)GetChildAt(3);
            m_imgCharacter = (GLoader)GetChildAt(5);
            m_txtCont = (GTextField)GetChildAt(7);
            m_btnStartGame = (GButton)GetChildAt(8);
        }
    }
}