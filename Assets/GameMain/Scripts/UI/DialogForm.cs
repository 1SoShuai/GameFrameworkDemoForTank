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

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            DialogFormData formData = userData as DialogFormData;

            SetHeaderVal(formData.headVal);
            SetBodyVal(formData.bodyVal);
        }

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

        public void SetBodyVal(string msg)
        {
            msg_txt.text = msg;
        }

        private void OnDisable()
        {
            btn_Close.onClick.RemoveListener(OnDialogClose);
        }
    }

    /// <summary>
    /// 对话框参数类
    /// </summary>
    public class DialogFormData
    {
        public string headVal;

        public string bodyVal;
    }
}
