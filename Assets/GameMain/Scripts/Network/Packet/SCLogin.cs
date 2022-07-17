using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace Tank
{
    /// <summary>
    /// 服务器对登录请求的响应
    /// </summary>
    [ProtoContract]
    public class SCLogin : PacketBase
    {
        public override int Id
        {
            get { return 1; }
        }

        [ProtoMember(1)]
        public bool result;

        [ProtoMember(2)]
        public string errorMsg;

        public override void Clear()
        {

        }
    }
}
