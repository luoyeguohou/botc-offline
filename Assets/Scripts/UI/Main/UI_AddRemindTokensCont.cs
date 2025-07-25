/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_AddRemindTokensCont : GComponent
    {
        public GButton m_btnConfirm;
        public GList m_lstStates;
        public const string URL = "ui://mkospyuuoj1u9e";

        public static UI_AddRemindTokensCont CreateInstance()
        {
            return (UI_AddRemindTokensCont)UIPackage.CreateObject("Main", "AddRemindTokensCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btnConfirm = (GButton)GetChildAt(1);
            m_lstStates = (GList)GetChildAt(2);
        }
    }
}