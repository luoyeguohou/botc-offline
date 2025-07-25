using FairyGUI;
namespace Main
{
    public partial class UI_DealWithPlayerWin : FairyWindow
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            m_cont.m_btnClose.onClick.Add(Dispose);
            m_cont.m_btnChangeSeat.onClick.Add(OnClickChangeSeat);
            m_cont.m_btnMoveToSeat.onClick.Add(OnClickMoveToSeat);
            m_cont.m_btnDeletePlayer.onClick.Add(OnClickDeletePlayer);
            m_cont.m_btnTraveller.onClick.Add(OnClickTraveller);
            m_cont.m_btnChangeRole.onClick.Add(OnClickChangeRole);
            Msg.Bind(MsgID.AfterPlayerInfoChanged, UpdateRoleView);
            Msg.Bind(MsgID.AfterTipRoleChanged, UpdateRoleView);

            m_cont.m_btnAlignment.onClick.Add(OnClickChangeAlignment);
            m_cont.m_btnDeadVote.onClick.Add(OnClickChangeDeadVote);
            m_cont.m_btnDead.onClick.Add(OnClickDead);

            m_cont.m_lstStates.itemRenderer = StateIR;
            m_cont.m_btnAddRemind.onClick.Add(OnClickAddRemindTokens);
        }

        public override void Dispose()
        {
            Msg.UnBind(MsgID.AfterTipRoleChanged, UpdateRoleView);
            Msg.UnBind(MsgID.AfterPlayerInfoChanged, UpdateRoleView);
            base.Dispose();
        }

        Player p;
        public void Init(Player p)
        {
            this.p = p;
            UpdateRoleView();
            m_cont.m_isPlayer.selectedIndex = p.isRealPlayer ? 1 : 0;
        }

        private void UpdateRoleView(object[] p = null)
        {
            m_cont.m_player.Init(this.p);
            m_cont.m_isGood.selectedIndex = this.p.isGood ? 1 : 0;
            m_cont.m_hasDeadVote.selectedIndex = this.p.hasDeadVote ? 1 : 0;
            m_cont.m_lstStates.numItems = this.p.states.Count;
            m_cont.m_isTraveller.selectedIndex = this.p.isTraveller ? 1 : 0;
            m_cont.m_isDead.selectedIndex = this.p.dead ? 1 : 0;
            if (this.p.role != "")
            { 
                RoleCfg cfg = Cfg.roles[this.p.role];
                m_cont.m_txtAbility.text = cfg.GetAbility();
            }
        }

        private void OnClickChangeSeat()
        {
            FGUIUtil.CreateWindow<UI_ChangeSeatWin>("ChangeSeatWin").InitChangeSeat(p);
        }

        private void OnClickMoveToSeat()
        {
            FGUIUtil.CreateWindow<UI_ChangeSeatWin>("ChangeSeatWin").InitMoveToSeat(p);
        }

        private void OnClickDeletePlayer()
        {
            if (!p.isRealPlayer)
            {
                Msg.Dispatch(MsgID.DeleteTipRole, new object[] { p });
            }
            else
            {
                Msg.Dispatch(MsgID.DeletePlayer, new object[] { p });
            }
            Dispose();
        }

        private void OnClickTraveller()
        {
            Msg.Dispatch(MsgID.ChangeTraveller, new object[] { p });
        }

        private void OnClickChangeRole()
        {
            if (!p.isRealPlayer)
            {
                FGUIUtil.CreateWindow<UI_PickRoleWin>("PickRoleWin").InitTipRoles(p);
            }
            else if (p.isTraveller)
            {
                FGUIUtil.CreateWindow<UI_PickRoleWin>("PickRoleWin").InitTraveller(p);
            }
            else
            {
                RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
                if (ripComp.roles.Count == 0) return;
                FGUIUtil.CreateWindow<UI_PickRoleWin>("PickRoleWin").Init(p);
            }
        }

        private void OnClickChangeAlignment()
        {
            Msg.Dispatch(MsgID.ChangeAlignment, new object[] { p });
        }
        
        private void OnClickChangeDeadVote()
        {
            Msg.Dispatch(MsgID.ChangeDeadVote, new object[] { p });
        }

        private void OnClickDead()
        {
            Msg.Dispatch(MsgID.ChangeDead, new object[] { p });
        }
        
        private void StateIR(int index, GObject g)
        {
            UI_State ui = (UI_State)g;
            TipCfg cfg = Cfg.tips[p.states[index]];
            ui.m_txtCont.text = cfg.GetText();
            ui.m_img.url = "ui://Main/" + cfg.role;
            ui.onClick.Clear();
            ui.onClick.Add(() => Msg.Dispatch(MsgID.RemoveRemindTokens, new object[] { p, p.states[index] }));
        }

        private void OnClickAddRemindTokens()
        {
            FGUIUtil.CreateWindow<UI_AddRemindTokensWin>("AddRemindTokensWin").Init(p); ;
        }
    }
}

