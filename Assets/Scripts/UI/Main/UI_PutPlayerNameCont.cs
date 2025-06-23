/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class UI_PutPlayerNameCont : GComponent
    {
        public GButton m_btnAddPlayer;
        public GButton m_btnRemovePlayer;
        public GButton m_btnStartGame;
        public GList m_lstNames;
        public const string URL = "ui://mkospyuugxos8m";

        public static UI_PutPlayerNameCont CreateInstance()
        {
            return (UI_PutPlayerNameCont)UIPackage.CreateObject("Main", "PutPlayerNameCont");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btnAddPlayer = (GButton)GetChildAt(0);
            m_btnRemovePlayer = (GButton)GetChildAt(1);
            m_btnStartGame = (GButton)GetChildAt(2);
            m_lstNames = (GList)GetChildAt(3);
        }
    }
}