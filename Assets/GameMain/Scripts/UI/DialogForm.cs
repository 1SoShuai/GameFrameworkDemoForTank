using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace Tank
{
    /// <summary>
    /// 对话框
    /// </summary>
    public class DialogForm : UIFormLogic
    {
        [SerializeField]
        private Button btn_Close;

        [SerializeField]
        private Text header_txt, msg_txt;

        private void OnEnable()
        {
            btn_Close.onClick.AddListener(OnDialogClose);
        }

        private void OnDialogClose()
        {
            GameEntry.UI.CloseUIForm(UIForm);
        }

        public void SetHeaderVal(string val)
        {
            header_txt.text = val;
        }

        public void SetMgsVal(string msg)
        {
            msg_txt.text = msg;
        }

        private void OnDisable()
        {
            btn_Close.onClick.RemoveListener(OnDialogClose);
        }
    }
}
