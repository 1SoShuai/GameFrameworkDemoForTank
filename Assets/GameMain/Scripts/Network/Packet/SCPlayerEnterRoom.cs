using ProtoBuf;
using System;
using System.Collections.Generic;

namespace Tank
{
    /// <summary>
    /// 玩家进入房间消息
    /// </summary>
    public class SCPlayerEnterRoom : PacketBase
    {
        public override int Id
        {
            get { return 2; }
        }

        [ProtoMember(1)]
        public string playerName;

        public override void Clear()
        {

        }
    }
}
