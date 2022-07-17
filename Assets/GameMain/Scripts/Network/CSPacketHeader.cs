using System;
using System.Collections.Generic;
using ProtoBuf;
using ProtoMsg;

namespace Tank
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable, ProtoContract]
    public class CSPacketHeader : PacketHeaderBase
    {
        [ProtoMember(1)]
        public override MsgType type { get; set; }
    }
}
