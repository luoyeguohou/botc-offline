/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_NIghtOrderCont : GComponent
    {
        public GButton m_btnFirstLeft;
        public GButton m_btnFirstRight;
        public GButton m_btnFirstAdd;
        public GButton m_btnFirstDelete;
        public GButton m_btnOtherLeft;
        public GButton m_btnOtherRight;
        public GButton m_btnOtherAdd;
        public GButton m_btnOtherDelete;
        public GButton m_btnFirstInsert;
        public GTextInput m_txtFirstText;
        public GTextInput m_txtOtherText;
        public GButton m_btnOtherInsert;
        public const string URL = "ui://mkospyuuw7dk9k";

        public static UI_NIghtOrderCont CreateInstance()
        {
            return (UI_NIghtOrderCont)UIPackage.CreateObject("Main", "NIghtOrderCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btnFirstLeft = (GButton)GetChildAt(4);
            m_btnFirstRight = (GButton)GetChildAt(5);
            m_btnFirstAdd = (GButton)GetChildAt(6);
            m_btnFirstDelete = (GButton)GetChildAt(7);
            m_btnOtherLeft = (GButton)GetChildAt(8);
            m_btnOtherRight = (GButton)GetChildAt(9);
            m_btnOtherAdd = (GButton)GetChildAt(10);
            m_btnOtherDelete = (GButton)GetChildAt(11);
            m_btnFirstInsert = (GButton)GetChildAt(12);
            m_txtFirstText = (GTextInput)GetChildAt(13);
            m_txtOtherText = (GTextInput)GetChildAt(14);
            m_btnOtherInsert = (GButton)GetChildAt(15);
        }
    }
}