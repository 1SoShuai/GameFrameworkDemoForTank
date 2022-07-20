using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using ProtoMsg;

namespace Tank
{
    /// <summary>
    /// 菜单界面
    /// </summary>
    public class MenuForm : UIFormLogic
    {
        [SerializeField]
        private Button loginBtn, registerBtn, closeBtn;

        [SerializeField]
        private InputField inputPwd, inputUsername;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        private void OnEnable()
        {
            loginBtn.onClick.AddListener(LoginClick);
            registerBtn.onClick.AddListener(RegisterClick);

        }

        private void RegisterClick()
        {

        }

        private void LoginClick()
        {
            string userName = inputUsername.text;
            string pwd = inputPwd.text;

            CSLogin loginMsg = new CSLogin
            {
                UserName = userName,
                Pwd = pwd
            };

            Debug.Log("send msg,userName:" + userName + " pwd:" + pwd);
            GameEntry.Network.GetNetworkChannel("TCPNetwork").Send(loginMsg);
        }

        private void OnDisable()
        {
            loginBtn.onClick.RemoveListener(LoginClick);
            registerBtn.onClick.RemoveListener(RegisterClick);
        }
    }
}
