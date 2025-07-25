/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_State : GButton
    {
        public GTextField m_txtCont;
        public GLoader m_img;
        public const string URL = "ui://mkospyuuplih5w";

        public static UI_State CreateInstance()
        {
            return (UI_State)UIPackage.CreateObject("Main", "State");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_txtCont = (GTextField)GetChildAt(2);
            m_img = (GLoader)GetChildAt(3);
        }
    }
}