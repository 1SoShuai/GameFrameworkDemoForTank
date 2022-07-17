using GameFramework;
using GameFramework.Event;
using System;
using System.Collections.Generic;

namespace Tank
{
    /// <summary>
    /// 登录回调事件
    /// </summary>
    public class LoginEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(LoginEventArgs).GetHashCode();

        public override int Id
        {
            get { return EventId; }
        }

        public bool loginResult;
        public string errorMsg;

        public object userData;

        public static LoginEventArgs Create(bool result, string msg)
        {
            LoginEventArgs loginEvent = ReferencePool.Acquire<LoginEventArgs>();

            loginEvent.loginResult = result;
            loginEvent.errorMsg = msg;

            return loginEvent;
        }


        public override void Clear()
        {

        }
    }
}
