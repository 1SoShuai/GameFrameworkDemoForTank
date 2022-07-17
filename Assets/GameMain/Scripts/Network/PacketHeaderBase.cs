using GameFramework;
using GameFramework.Network;
using ProtoBuf;
using ProtoMsg;
using System;
using System.Collections.Generic;

namespace Tank
{
    /// <summary>
    /// 消息包头基类
    /// </summary>
    public abstract class PacketHeaderBase : IPacketHeader, IReference
    {
        /// <summary>
        /// 当前消息包的类型(唯一)
        /// </summary>
        public virtual MsgType type
        {
            get; set;
        }

        /// <summary>
        /// 消息包的长度
        /// </summary>
        public virtual int PacketLength
        {
            get; set;
        }

        public void Clear()
        {

        }
    }
}