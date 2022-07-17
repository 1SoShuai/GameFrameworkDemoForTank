using GameFramework.Network;
using System;
using System.Collections.Generic;
using ProtoBuf;
using ProtoMsg;

namespace Tank
{
    /// <summary>
    /// 消息基类
    /// </summary>
    public abstract class PacketBase : Packet
    {
        //public abstract PacketType PacketType { get; set; }
    }
}
