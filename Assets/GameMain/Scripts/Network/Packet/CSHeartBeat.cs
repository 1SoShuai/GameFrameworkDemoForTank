using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Tank
{
    /// <summary>
    /// 客户端向服务器发送的消息
    /// </summary>
    [ProtoContract]
    public class CSHeartBeat : PacketBase
    {
        public override int Id
        {
            get
            {
                return 2;
            }
        }

        //[ProtoMember(1)]
        //public override PacketType PacketType { get; set; }

        [ProtoMember(1)]
        public string na;

        public override void Clear()
        {

        }

    }
}
