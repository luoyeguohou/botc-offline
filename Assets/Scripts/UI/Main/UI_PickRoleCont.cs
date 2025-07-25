/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_PickRoleCont : GComponent
    {
        public GList m_lstRole;
        public const string URL = "ui://mkospyuuwu429b";

        public static UI_PickRoleCont CreateInstance()
        {
            return (UI_PickRoleCont)UIPackage.CreateObject("Main", "PickRoleCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_lstRole = (GList)GetChildAt(0);
        }
    }
}