/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_NameAndDelete : GComponent
    {
        public GButton m_btnName;
        public GButton m_btnDelete;
        public const string URL = "ui://mkospyuugxos8g";

        public static UI_NameAndDelete CreateInstance()
        {
            return (UI_NameAndDelete)UIPackage.CreateObject("Main", "NameAndDelete");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btnName = (GButton)GetChildAt(0);
            m_btnDelete = (GButton)GetChildAt(1);
        }
    }
}