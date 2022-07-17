using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Tank
{
    /// <summary>
    /// 
    /// </summary>
    [ProtoContract]
    public class CSLogin : PacketBase
    {
        public override int Id
        {
            get { return 1; }
        }

        [ProtoMember(1)]
        public string UserName
        {
            get; set;
        }

        [ProtoMember(2)]
        public string Pwd
        {
            get; set;
        }

        public override void Clear()
        {

        }
    }
}
