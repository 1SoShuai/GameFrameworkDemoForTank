using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using System;
using System.Collections.Generic;
using UnityGameFramework.Runtime;

namespace Tank
{
    /// <summary>
    /// 菜单流程，登录、注册部分
    /// </summary>
    public class ProcedureMenu : ProcedureBase
    {
        IFsm<IProcedureManager> procedure;

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAsset("MenuForm"), "Default");

            GameEntry.Event.Subscribe(LoginEventArgs.EventId, OnLoginFeedback);

            procedure = procedureOwner;
        }

        /// <summary>
        /// 登录反馈
        /// </summary>
        /// <param name="sender">事件发送者</param>
        /// <param name="e">时间参数类</param>
        private void OnLoginFeedback(object sender, GameEventArgs e)
        {
            LoginEventArgs login = e as LoginEventArgs;

            if (login.loginResult)
            {
                GameEntry.UI.CloseUIForm(GameEntry.UI.GetUIForm(AssetUtility.GetUIFormAsset("MenuForm")));

                procedure.SetData<VarInt32>("NextSceneID", 2);
                ChangeState<ProcedureChangeScene>(procedure);
            }
            else
            {
                IDataTable<DRUIForm> uiForm = GameEntry.DataTable.GetDataTable<DRUIForm>();
                DRUIForm dtForm = uiForm.GetDataRow(101);

                GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAsset(dtForm.AssetName), "Default", new DialogFormData() { headVal = "Error", bodyVal = login.errorMsg });
            }
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Event.Unsubscribe(LoginEventArgs.EventId, OnLoginFeedback);
        }
    }
}
