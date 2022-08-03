using GameFramework.Event;
using System;
using System.Collections.Generic;

namespace Tank
{
    /// <summary>
    /// 玩家进入房间回调函数
    /// </summary>
    public class PlayerEnterRoomEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(LoginEventArgs).GetHashCode();

        public override int Id
        {
            get { return EventId; }
        }

        public string playerName;

        public static PlayerEnterRoomEventArgs Create(string name)
        {
            PlayerEnterRoomEventArgs args = new PlayerEnterRoomEventArgs();
            args.playerName = name;

            return args;
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
