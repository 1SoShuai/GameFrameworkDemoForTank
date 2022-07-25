using GameFramework.DataTable;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace Tank
{
    /// <summary>
    /// 坦克选择界面
    /// </summary>
    public class TankSelectForm : UIFormLogic
    {
        [SerializeField]
        private Button prev, after;

        [SerializeField]
        private GameObject iconParent, iconPrefab;

        //当前实体数据
        private EntityData m_currentEntityData;

        //所有坦克实体
        private List<ReferenceTankInfo> tankInfoList = new List<ReferenceTankInfo> { };

        private List<TankIconItem> iconItems = new List<TankIconItem>();

        private int tankIndex;
        private int TankIndex
        {
            get { return tankIndex % (tankInfoList.Count); }
            set
            {
                Log.Info("Set val : " + value);
                if (value < 0)
                    tankIndex = tankInfoList.Count - 1;
                else
                    tankIndex = value;
            }
        }

        private int iconIndex;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            TankIndex = 0;
            iconIndex = 0;
            tankInfoList.Clear();

            IDataTable<DREntity> tempTab = GameEntry.DataTable.GetDataTable<DREntity>();

            DREntity[] entities = tempTab.GetAllDataRows();

            foreach (DREntity entity in entities)
            {
                if (entity.GroupName == "Tanks")
                {
                    ReferenceTankInfo info = new ReferenceTankInfo();
                    info.entityName = entity.AssetName;
                    info.typeId = entity.Id;
                    tankInfoList.Add(info);

                    GenerateIcon(info);
                }
            }
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            prev.onClick.AddListener(OnPrevClick);
            after.onClick.AddListener(OnAfterClick);

            ShowTankEntity(tankInfoList[TankIndex].typeId);
        }

        private void GenerateIcon(ReferenceTankInfo info)
        {
            GameObject icon = GameObject.Instantiate<GameObject>(iconPrefab);
            icon.transform.SetParent(iconParent.transform);
            icon.GetComponent<TankIconItem>().InitTankInfo(info);
            icon.GetComponent<TankIconItem>().index = iconIndex++;

            iconItems.Add(icon.GetComponent<TankIconItem>());
        }

        private void OnConfirmClick()
        {

        }

        private void OnPrevClick()
        {
            --TankIndex;
            Log.Info(TankIndex);
            ShowTankEntity(tankInfoList[TankIndex].typeId);
        }

        private void OnAfterClick()
        {
            ++TankIndex;
            ShowTankEntity(tankInfoList[TankIndex].typeId);

        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);

            prev.onClick.RemoveListener(OnPrevClick);
            after.onClick.RemoveListener(OnAfterClick);
        }

        /// <summary>
        /// 展示坦克信息包含三个步骤
        /// 1. 隐藏之前的坦克  2. 切换当前UI界面 3. 加载当前坦克资源
        /// </summary>
        /// <param name="typeId"></param>
        public void ShowTankEntity(int typeId, int iconIndex = -1)
        {
            if (m_currentEntityData != null)
                GameEntry.Entity.HideEntity(m_currentEntityData.Id);
            if (iconIndex != -1)
                TankIndex = iconIndex;

            SwitchSelectedIcon(TankIndex);

            TankData tankData = new TankData(GameEntry.Entity.GenerateSerialId(), typeId);
            GameEntry.Entity.ShowEntity<TankEntity>(tankData);
            m_currentEntityData = tankData;
        }




        private void SwitchSelectedIcon(int curIndex)
        {
            foreach (var item in iconItems)
                item.CurStatus = SelectStatus.UnSelected;

            iconItems[curIndex].CurStatus = SelectStatus.Selcted;
        }
    }
}
