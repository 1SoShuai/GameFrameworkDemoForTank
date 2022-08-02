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
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.UI.OpenUIForm(MappingUtility.TwoPlayerFormID);
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.UI.CloseUIForm(MappingUtility.TwoPlayerFormID);
        }
    }
}
