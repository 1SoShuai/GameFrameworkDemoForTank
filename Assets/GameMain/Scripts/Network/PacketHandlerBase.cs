using GameFramework.Network;
using System;
using System.Collections.Generic;

namespace Tank
{
    /// <summary>
    /// 处理接收到的消息
    /// </summary>
    public abstract class PacketHandlerBase : IPacketHandler
    {
        public int Id
        {
            get { return 1; }
        }

        public abstract void Handle(object sender, Packet packet);
    }
}
