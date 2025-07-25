using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    public partial class UI_NewMainWin : FairyWindow
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();

            // script 
            m_cont.m_btnPickScript.onClick.Add(OnClickPickScript);
            Msg.Bind(MsgID.AfterPickScript, AfterPickScript);
            Msg.Bind(MsgID.AfterPickScript, UpdateScriptText);
            // player
            m_cont.m_btnAddPerson.onClick.Add(AddPlayer);
            Msg.Bind(MsgID.AfterPlayerNumChanged, UpadtePlayerView);
            Msg.Bind(MsgID.AfterChangeSeat, UpadtePlayerView);
            // roles
            m_cont.m_btnPickRoles.onClick.Add(OnClickPickRoles);
            m_cont.m_lstRoleInPlay.itemRenderer = RoleInPlayIR;
            Msg.Bind(MsgID.ConfirmRole, UpdateRolesInPlay);
            m_cont.m_btnShuffleRoles.onClick.Add(OnClickDispatchRoles);
            m_cont.m_btnDrawTokens.onClick.Add(OnClickDrawTokens);
            Msg.Bind(MsgID.AfterDrawRole, AfterDrawRole);
            Msg.Bind(MsgID.AfterLoadGame, AfterLoadGame);
            Msg.Bind(MsgID.AfterTipRoleChanged, UpdateTipRole);
            m_cont.m_btnAddTip.onClick.Add(OnClickAddTipRole);
            m_cont.m_lstTips.itemRenderer = TipRoleIR;

            m_cont.m_btnNightOrder.onClick.Add(OnClickNight);
            m_cont.m_lstNightOrder.itemRenderer = NightCharacterIR;
            m_cont.m_btnShowSth.onClick.Add(OnClickShowSth);

            m_cont.m_btnBackToLastGame.onClick.Add(() => Msg.Dispatch(MsgID.LoadGame));

            m_cont.m_btnChinese.onClick.Add(SetLanguageChinese);
            m_cont.m_btnEnglish.onClick.Add(SetLanguageEnglish);
        }

        public override void Dispose()
        {
            Msg.UnBind(MsgID.AfterPickScript, AfterPickScript);
            Msg.UnBind(MsgID.AfterPickScript, UpdateScriptText);
            Msg.UnBind(MsgID.AfterPlayerNumChanged, UpadtePlayerView);
            Msg.UnBind(MsgID.AfterChangeSeat, UpadtePlayerView);
            Msg.UnBind(MsgID.ConfirmRole, UpdateRolesInPlay);
            Msg.UnBind(MsgID.AfterDrawRole, AfterDrawRole);
            Msg.UnBind(MsgID.AfterLoadGame, AfterLoadGame);
            Msg.UnBind(MsgID.AfterTipRoleChanged, UpdateTipRole);
            base.Dispose();
        }

        public void Init()
        {
            UpdateScriptText();
            UpdateRolesInPlay();
        }

        private readonly List<UI_Player> uiPlayers = new();

        private void AfterDrawRole(object[] p = null)
        {
            m_cont.m_state.selectedIndex = 2;
            UpdateNightListView();
        }

        private void OnClickPickScript()
        {
            FGUIUtil.CreateWindow<UI_ScriptWin>("ScriptWin").Init();
        }

        private void AfterPickScript(object[] p = null)
        {
            m_cont.m_state.selectedIndex = 1;
        }

        private void AfterLoadGame(object[] p = null)
        {
            m_cont.m_state.selectedIndex = 2;
            UpdateNightListView();
            UpdateRolesInPlay();
            UpadtePlayerView();
            UpdateTipRole();
            UpdateScriptText();
        }



        private void UpdateScriptText(object[] p = null)
        {
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            if (csComp.curr == "")
                m_cont.m_txtScript.SetVar("curr", "null").FlushVars();
            else
                m_cont.m_txtScript.SetVar("curr", Cfg.scripts[csComp.curr].GetName()).FlushVars();
        }

        private void AddPlayer()
        {
            Msg.Dispatch(MsgID.AddPlayer);
        }

        private void UpadtePlayerView(object[] p = null)
        {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            Vector2 midPos = new(m_cont.width / 2, m_cont.height / 2);
            int radius = 650;
            for (int i = uiPlayers.Count; i < Mathf.Max(pComp.players.Count, uiPlayers.Count); i++)
            {
                uiPlayers.Add(GenNewPlayerUI());
            }
            int cnt = uiPlayers.Count;
            for (int i = pComp.players.Count; i < Mathf.Max(pComp.players.Count, cnt); i++)
            {
                uiPlayers.Shift().Dispose();
            }
            for (int i = 0; i < pComp.players.Count; i++)
            {
                Player player = pComp.players[i];
                uiPlayers[i].position = new Vector3(midPos.x + radius * Mathf.Sin(2 * i * Mathf.PI / pComp.players.Count) * 1.1f
               , midPos.y - radius * Mathf.Cos(2 * i * Mathf.PI / pComp.players.Count) * 0.96f);
                uiPlayers[i].Init(player);
                uiPlayers[i].onClick.Clear();
                uiPlayers[i].onClick.Add(() => FGUIUtil.CreateWindow<UI_DealWithPlayerWin>("DealWithPlayerWin").Init(player));
            }
        }

        private UI_Player GenNewPlayerUI()
        {
            GComponent gcom = UIPackage.CreateObject("Main", "Player").asCom;
            m_cont.m_emp.AddChild(gcom);
            gcom.SetPivot(0.5f, 0.5f, true);
            gcom.scale = new Vector2(0.7f, 0.7f);
            return (UI_Player)gcom;
        }

        private void OnClickPickRoles()
        {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            if (Util.Count(pComp.players, p => !p.isTraveller) < 5)
            {
                if (Cfg.language == "chinese")
                    FGUIUtil.ShowMsg("至少要有5个非旅行者玩家！！！");
                else
                    FGUIUtil.ShowMsg("There should be at least 5 non travelers！！！");
                return;
            }
            FGUIUtil.CreateWindow<UI_PutCharacterWin>("PutCharacterWin").Init();
        }

        private void UpdateRolesInPlay(object[] p = null)
        {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            m_cont.m_lstRoleInPlay.numItems = ripComp.roles.Count;
        }

        private void RoleInPlayIR(int index, GObject g)
        {
            UI_Player ui = (UI_Player)g;
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            ui.InitByRole(ripComp.roles[index]);
        }

        private void OnClickDispatchRoles()
        {
            Msg.Dispatch(MsgID.DispatchRole);
        }

        private void OnClickDrawTokens()
        {
            PlayerComp playerComp = World.e.sharedConfig.GetComp<PlayerComp>();
            if (Util.Any(playerComp.players, p => p.role == ""))
            {
                if (Cfg.language == "chinese")
                    FGUIUtil.ShowMsg("有玩家未分配到角色！！！");
                else
                    FGUIUtil.ShowMsg("Some one donesn't have character！！！");
                return;
            }
            FGUIUtil.CreateWindow<UI_ChooseWhoDrawFirstWin>("ChooseWhoDrawFirstWin").Init();
        }

        private void OnClickAddTipRole()
        {
            Msg.Dispatch(MsgID.AddTipRole);
        }

        private void UpdateTipRole(object[] p = null)
        {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            m_cont.m_lstTips.numItems = ripComp.rolesForTipping.Count;
        }

        private void TipRoleIR(int index, GObject g)
        {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            UI_Player ui = (UI_Player)g;
            ui.Init(ripComp.rolesForTipping[index]);
            ui.onClick.Clear();
            ui.onClick.Add(() => FGUIUtil.CreateWindow<UI_DealWithPlayerWin>("DealWithPlayerWin").Init(ripComp.rolesForTipping[index]));
        }

        private void OnClickNight()
        {
            m_cont.m_firstNight.selectedIndex = m_cont.m_firstNight.selectedIndex == 1 ? 0 : 1;
            UpdateNightListView();
        }

        private void UpdateNightListView()
        {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            if (m_cont.m_firstNight.selectedIndex == 0)
            {
                m_cont.m_lstNightOrder.numItems = ripComp.otherNightOrder.Count;
            }
            else
            {
                m_cont.m_lstNightOrder.numItems = ripComp.firstNightOrder.Count;
            }
        }

        private void NightCharacterIR(int index, GObject g)
        {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            string role;
            if (m_cont.m_firstNight.selectedIndex == 0)
            {
                role = ripComp.otherNightOrder[index];
            }
            else
            {
                role = ripComp.firstNightOrder[index];
            }
            UI_Player ui = (UI_Player)g;
            ui.InitByRole(role);
        }

        private void OnClickShowSth()
        {
            FGUIUtil.CreateWindow<UI_ShowSomethingWin>("ShowSomethingWin").Init();
        }

        private void SetLanguageChinese()
        {
            PlayerPrefs.SetString("language", "chinese");
            Dispose();
            SceneManager.LoadScene(0);
        }

        private void SetLanguageEnglish()
        {
            PlayerPrefs.SetString("language", "english");
            Dispose();
            SceneManager.LoadScene(0);
        }
    }
}
