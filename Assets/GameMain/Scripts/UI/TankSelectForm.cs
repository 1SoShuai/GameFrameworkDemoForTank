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

        private void OnEnable()
        {

            prev.onClick.AddListener(OnPrevClick);
            after.onClick.AddListener(OnAfterClick);
        }

        private void OnConfirmClick()
        {

        }

        private void OnPrevClick()
        {

        }

        private void OnAfterClick()
        {
            GameEntry.Entity.HideEntity(5);

            GameEntry.Entity.ShowEntity<TankLogic>(1, AssetUtility.GetEntityAsset("Firefly"), "Tanks", 1, new TankData(1, 1002) { });

        }

        private void OnDisable()
        {
            prev.onClick.RemoveListener(OnPrevClick);
            after.onClick.RemoveListener(OnAfterClick);
        }
    }
}
