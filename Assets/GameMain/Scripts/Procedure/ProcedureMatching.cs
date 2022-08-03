using GameFramework.Fsm;
using GameFramework.Procedure;
using System;
using System.Collections.Generic;

namespace Tank
{
    /// <summary>
    /// 匹配流程逻辑
    /// </summary>
    public class ProcedureMatching : ProcedureBase
    {
        int? serialID = 0;

        bool toLobby;

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            toLobby = false;

            serialID = GameEntry.UI.OpenUIForm(MappingUtility.TwoPlayerFormID, this);
        }

        public void ChangeToLobby()
        {
            toLobby = true;
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (toLobby)
            {
                ChangeState<ProcedureLobby>(procedureOwner);
            }
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.UI.CloseUIForm((int)serialID);
        }
    }
}
