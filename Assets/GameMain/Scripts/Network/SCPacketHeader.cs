using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;
using ProtoMsg;

namespace Tank
{
    [ProtoContract]
    public class SCPacketHeader : PacketHeaderBase
    {
        [ProtoMember(1)]
        public override MsgType type { get; set; }

        [ProtoMember(2)]
        public override int PacketLength
        {
            get; set;
        }
    }
}
