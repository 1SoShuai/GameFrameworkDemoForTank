using GameFramework.Fsm;
using GameFramework.Network;
using GameFramework.Procedure;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using UnityGameFramework.Runtime;

namespace Tank
{
    /// <summary>
    /// 
    /// </summary>
    public class SCLoginHandler : PacketHandlerBase
    {
        public static Action loginSuccess;

        public override void Handle(object sender, Packet packet)
        {
            SCLogin login = Serializer.Deserialize<SCLogin>(sender as Stream);

            GameEntry.Event.Fire(this, LoginEventArgs.Create(login.result, login.errorMsg));

            //if (login.result)
            //{
            //    Log.Info("success");
            //    loginSuccess?.Invoke();
            //}
            //else
            //{
            //    GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAsset("DialogForm"), "Default");
            //    Log.Error(login.errorMsg);
            //}
        }
    }
}
