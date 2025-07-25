/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_PickRoleWin : FairyWindow
    {
        public GLoader m_bg1;
        public UI_PickRoleCont m_cont;
        public const string URL = "ui://mkospyuuwu429a";

        public static UI_PickRoleWin CreateInstance()
        {
            return (UI_PickRoleWin)UIPackage.CreateObject("Main", "PickRoleWin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_bg1 = (GLoader)GetChildAt(0);
            m_cont = (UI_PickRoleCont)GetChildAt(1);
        }
    }
}