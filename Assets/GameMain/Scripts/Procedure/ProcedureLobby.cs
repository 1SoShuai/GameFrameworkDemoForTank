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
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAsset("TankSelectForm"), "Default");

            GameEntry.Entity.ShowEntity<TankLogic>(5, AssetUtility.GetEntityAsset("Karl"), "Tanks",1,new TankData(5,1005) { });
        }
    }
}