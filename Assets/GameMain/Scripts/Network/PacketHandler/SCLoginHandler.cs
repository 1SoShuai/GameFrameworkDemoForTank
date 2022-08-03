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
    /// 处理登录回调事件
    /// </summary>
    public class SCLoginHandler : PacketHandlerBase
    {
        public override void Handle(object sender, Packet packet)
        {
            SCLogin login = Serializer.Deserialize<SCLogin>(sender as Stream);

            GameEntry.Event.Fire(this, LoginEventArgs.Create(login.result, login.errorMsg));
        }
    }
}
