using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace Tank
{
    /// <summary>
    /// 坦克图标管理类
    /// </summary>
    public class TankIconItem : MonoBehaviour
    {
        //当前选中状态
        private SelectStatus curStatus;
        public SelectStatus CurStatus
        {
            get { return curStatus; }
            set
            {
                curStatus = value;

                if (value == SelectStatus.Selcted)
                    OnSelected();
                else
                    OnUnSelected();
            }
        }

        [SerializeField]
        private GameObject focusFrame, focusIcon;

        [SerializeField]
        private TMP_Text tankName;

        [SerializeField]
        private Button btnSelf;

        private ReferenceTankInfo tankInfo;

        public int index;

        private void OnEnable()
        {
            btnSelf.onClick.AddListener(OnSelfClick);
        }

        private void OnSelfClick()
        {
            if (CurStatus != SelectStatus.Selcted)
            {
                UIForm form = GameEntry.UI.GetUIForm(AssetUtility.GetUIFormAsset("TankSelectForm"));
                form.GetComponent<TankSelectForm>().ShowTankEntity(tankInfo.typeId, index);
            }
        }

        //设置当前坦克的信息
        public void InitTankInfo(ReferenceTankInfo info)
        {
            Debug.Log("init tank info:" + info.typeId);

            tankName.text = info.entityName;
            tankInfo.typeId = info.typeId;

            CurStatus = SelectStatus.UnSelected;
        }

        //选中
        private void OnSelected()
        {
            focusFrame.SetActive(true);
            focusIcon.SetActive(true);
        }

        //未选中
        private void OnUnSelected()
        {
            focusFrame.SetActive(false);
            focusIcon.SetActive(false);
        }

        private void OnDisable()
        {
            btnSelf.onClick.RemoveListener(OnSelfClick);
        }
    }

    public enum SelectStatus
    {
        Selcted,
        UnSelected
    }

    public struct ReferenceTankInfo
    {
        public string entityName;

        public int typeId;
    }
}