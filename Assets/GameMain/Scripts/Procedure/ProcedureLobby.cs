using GameFramework.DataTable;
using GameFramework.Fsm;
using GameFramework.Procedure;
using System;
using System.Collections.Generic;

namespace Tank
{
    /// <summary>
    /// 游戏大厅
    /// 包括个人信息展示，房间创建、选择等功能
    /// </summary>
    public class ProcedureLobby : ProcedureBase
    {
        private bool startMatching;

        private int? serialID;

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            startMatching = false;
            serialID = GameEntry.UI.OpenUIForm(MappingUtility.TankSelectFormID, this);
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if(startMatching)
            {
                ChangeState<ProcedureMatching>(procedureOwner);
            }
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.UI.CloseUIForm((int)serialID);
        }

        public void StartMatching()
        {
            startMatching = true;
        }
    }
}