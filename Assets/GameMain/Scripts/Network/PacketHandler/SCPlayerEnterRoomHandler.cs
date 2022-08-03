using GameFramework.Network;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;

namespace Tank
{
    /// <summary>
    /// 玩家进入房间回调
    /// </summary>
    public class SCPlayerEnterRoomHandler : PacketHandlerBase
    {
        public override void Handle(object sender, Packet packet)
        {
            SCPlayerEnterRoom player = Serializer.Deserialize<SCPlayerEnterRoom>(sender as Stream);

            GameEntry.Event.Fire(this, PlayerEnterRoomEventArgs.Create(player.playerName));
        }
    }
}
