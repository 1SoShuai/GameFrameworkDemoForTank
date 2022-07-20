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

        private EntityData m_currentEntityData;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            prev.onClick.AddListener(OnPrevClick);
            after.onClick.AddListener(OnAfterClick);

            TankData tankData = new TankData(GameEntry.Entity.GenerateSerialId(), MappingUtility.KarlID);
            GameEntry.Entity.ShowEntity<TankEntity>(tankData);
            m_currentEntityData = tankData;

            GenerateIcon();
        }

        private void GenerateIcon()
        {
            GameObject icon = GameObject.Instantiate<GameObject>(iconPrefab);
            icon.transform.SetParent(iconParent.transform);
        }

        private void OnConfirmClick()
        {

        }

        private void OnPrevClick()
        {

        }

        private void OnAfterClick()
        {
            GameEntry.Entity.HideEntity(m_currentEntityData.Id);

            TankData tankData  = new TankData(GameEntry.Entity.GenerateSerialId(), MappingUtility.FireflyID);
            GameEntry.Entity.ShowEntity<TankEntity>(tankData);
            m_currentEntityData = tankData;


        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);

            prev.onClick.RemoveListener(OnPrevClick);
            after.onClick.RemoveListener(OnAfterClick);
        }
    }
}
