using GameFramework.Fsm;
using GameFramework.Procedure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    /// <summary>
    /// 根据不同的流程进入不同的模式
    /// </summary>
    public class ProcedureSplash : ProcedureBase
    {
        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            ChangeState<ProcedurePreload>(procedureOwner);
        }
    }
}
