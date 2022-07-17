using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Tank
{
    /// <summary>
    /// 切换场景流程
    /// </summary>
    public class ProcedureChangeScene : ProcedureBase
    {
        IFsm<IProcedureManager> procedure;

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            int sceneId = procedureOwner.GetData<VarInt32>("NextSceneID");

            IDataTable<DRScene> dtScene = GameEntry.DataTable.GetDataTable<DRScene>();
            DRScene drScene = dtScene.GetDataRow(sceneId);

            GameEntry.Scene.LoadScene(AssetUtility.GetSceneAsset(drScene.AssetName), this);

            procedure = procedureOwner;

            GameEntry.Event.Subscribe(LoginEventArgs.EventId, OnLoginFeedback);
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            DialogForm dialogForm = GameEntry.UI.GetUIForm(AssetUtility.GetUIFormAsset("DialogForm")).Logic as DialogForm;
            OpenUIFormSuccessEventArgs openArgs = e as OpenUIFormSuccessEventArgs;

            if (dialogForm != null)
            {
                dialogForm.SetHeaderVal("Error");
                dialogForm.SetMgsVal(openArgs.UserData.ToString());
            }
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
                ChangeState<ProcedureLobby>(procedure);
            }
            else
            {
                GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAsset("DialogForm"), "Default", login.errorMsg);
            }
        }


        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Event.Unsubscribe(LoginEventArgs.EventId, OnLoginFeedback);
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
        }
    }
}
