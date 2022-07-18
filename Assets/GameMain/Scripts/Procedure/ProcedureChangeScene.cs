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
        enum NextProcedure
        {
            Menu,
            Lobby
        }

        private NextProcedure nextProcedure;


        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            // 卸载所有场景
            string[] loadedSceneAssetNames = GameEntry.Scene.GetLoadedSceneAssetNames();
            for (int i = 0; i < loadedSceneAssetNames.Length; i++)
            {
                GameEntry.Scene.UnloadScene(loadedSceneAssetNames[i]);
            }

            //加载新场景
            int sceneId = procedureOwner.GetData<VarInt32>("NextSceneID");

            nextProcedure = (NextProcedure)(sceneId - 1);

            IDataTable<DRScene> dtScene = GameEntry.DataTable.GetDataTable<DRScene>();
            DRScene drScene = dtScene.GetDataRow(sceneId);

            GameEntry.Scene.LoadScene(AssetUtility.GetSceneAsset(drScene.AssetName), this);
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (nextProcedure == NextProcedure.Menu)
            {
                ChangeState<ProcedureMenu>(procedureOwner);
            }
            else if (nextProcedure == NextProcedure.Lobby)
            {
                ChangeState<ProcedureLobby>(procedureOwner);
            }
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }
    }
}
