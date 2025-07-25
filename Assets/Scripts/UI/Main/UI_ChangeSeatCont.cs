/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_ChangeSeatCont : GComponent
    {
        public GComponent m_emp;
        public const string URL = "ui://mkospyuuh32k98";

        public static UI_ChangeSeatCont CreateInstance()
        {
            return (UI_ChangeSeatCont)UIPackage.CreateObject("Main", "ChangeSeatCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_emp = (GComponent)GetChildAt(0);
        }
    }
}