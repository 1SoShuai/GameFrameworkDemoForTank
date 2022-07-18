using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Network;
using GameFramework.Procedure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Tank
{
    /// <summary>
    /// 预加载资源,加载配置表、数据表等资源
    /// </summary>
    public class ProcedurePreload : ProcedureBase
    {
        NetworkChannelHelper channelHelper;

        public static readonly string[] DataTableNames = new string[]
        {
            "Scene",
            "Entity",
            "Music",
            "UIForm"
        };

        Dictionary<string, bool> loadFlags = new Dictionary<string, bool>();

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            loadFlags.Clear();

            GameEntry.Event.Subscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDatatableSuccess);
            GameEntry.Event.Subscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDatatableFaild);

            ConnectToServer();

            PreloadResources();
        }

        /// <summary>
        /// 资源加载失败
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadDatatableFaild(object sender, GameEventArgs e)
        {
            LoadDataTableFailureEventArgs ne = (LoadDataTableFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Error("Can not load data table '{0}' from '{1}' with error message '{2}'.", ne.DataTableAssetName, ne.DataTableAssetName, ne.ErrorMessage);
        }

        /// <summary>
        /// 资源加载成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadDatatableSuccess(object sender, GameEventArgs e)
        {
            LoadDataTableSuccessEventArgs ne = e as LoadDataTableSuccessEventArgs;

            if (ne.UserData != this)
            {
                return;
            }

            loadFlags[ne.DataTableAssetName] = true;
        }

        private void ConnectToServer()
        {
            channelHelper = new NetworkChannelHelper();

            INetworkChannel networkChannel = GameEntry.Network.CreateNetworkChannel("TCPNetwork", ServiceType.Tcp, channelHelper);

            networkChannel.Connect(IPAddress.Parse("127.0.0.1"), 999);
        }

        private void PreloadResources()
        {
            //预加载数据表
            foreach (string dataTableName in DataTableNames)
            {
                LoadDataTable(dataTableName);
            }
        }

        private void LoadDataTable(string dataTableName)
        {
            string dataTableAssetName = AssetUtility.GetDataTableAsset(dataTableName, false);
            GameEntry.DataTable.LoadDataTable(dataTableName, dataTableAssetName, this);

            loadFlags.Add(dataTableAssetName, false);
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            foreach(var val in loadFlags.Values)
            {
                if (val == false)
                    return;
            }

            procedureOwner.SetData<VarInt32>("NextSceneID", 1);
            ChangeState<ProcedureChangeScene>(procedureOwner);
        }
    }
}
