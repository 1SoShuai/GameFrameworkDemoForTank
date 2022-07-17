using GameFramework;
using GameFramework.Event;
using GameFramework.Network;
using System;
using System.Collections.Generic;
using System.IO;
using UnityGameFramework.Runtime;
using ProtoBuf;
using ProtoBuf.Meta;
using ProtoMsg;

namespace Tank
{
    /// <summary>
    /// 网络帮助类
    /// </summary>
    public class NetworkChannelHelper : INetworkChannelHelper
    {
        private INetworkChannel m_NetworkChannel = null;

        private MemoryStream stream = new MemoryStream(1024);

        public int PacketHeaderLength
        {
            get
            {
                Log.Info("packerHeaderLen:" + sizeof(int));
                return sizeof(int) * 2;
            }
        }

        //反序列化消息体，收到消息时调用
        public Packet DeserializePacket(IPacketHeader packetHeader, Stream source, out object customErrorData)
        {
            customErrorData = null;

            SCPacketHeader SCHeader = packetHeader as SCPacketHeader;

            Log.Info("Receive msg length: " + source.Length + ",type:" + SCHeader.type);

            Type type = Type.GetType("Tank." + SCHeader.type.ToString() + "Handler");
 
            object obj = Activator.CreateInstance(type);

            PacketHandlerBase headerBase = obj as PacketHandlerBase;

            headerBase.Handle(source, null);

            return null;
        }

        //反序列化消息头，收到消息时调用
        public IPacketHeader DeserializePacketHeader(Stream source, out object customErrorData)
        {
            Log.Info("Receive msgHeader:" + source.Length);

            SCPacketHeader packetHeader = Serializer.DeserializeWithLengthPrefix<SCPacketHeader>(source, PrefixStyle.Fixed32);
            Log.Info(packetHeader.type + packetHeader.PacketLength);

            customErrorData = null;
            return packetHeader;
        }

        public void Initialize(INetworkChannel networkChannel)
        {
            m_NetworkChannel = networkChannel;

            GameEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
            GameEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkClosedEventArgs.EventId, OnNetworkClosed);
            GameEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
            GameEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId, OnNetworkError);
            GameEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);
        }

        public void PrepareForConnecting()
        {
            m_NetworkChannel.HeartBeatInterval = int.MaxValue;
        }

        public bool SendHeartBeat()
        {
            m_NetworkChannel.Send(ReferencePool.Acquire<CSHeartBeat>());
            return true;
        }

        public bool Serialize<T>(T packet, Stream destination) where T : Packet
        {
            PacketBase packetTemp = packet as PacketBase;

            if (packetTemp == null)
            {
                Log.Error("send packet is null");
                return false;
            }

            CSPacketHeader header = new CSPacketHeader()
            {
                type = Tools.GetMsgType(packet.GetType().Name)
            };

            Serializer.SerializeWithLengthPrefix(stream, header, PrefixStyle.Fixed32);
            Serializer.Serialize(stream, packet);

            stream.WriteTo(destination);

            Log.Info("send packet len:" + stream.Length);

            stream.Position = 0;
            stream.Flush();

            return true;
        }

        public void Shutdown()
        {
            GameEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
            GameEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkClosedEventArgs.EventId, OnNetworkClosed);
            GameEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
            GameEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId, OnNetworkError);
            GameEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);

            m_NetworkChannel = null;
        }

        private void OnNetworkConnected(object sender, GameEventArgs e)
        {
            Log.Info("Connected to server!");
            SendHeartBeat();
        }

        private void OnNetworkClosed(object sender, GameEventArgs e)
        {

        }
        private void OnNetworkMissHeartBeat(object sender, GameEventArgs e)
        {
            Log.Info("Miss heart beat");
        }

        private void OnNetworkError(object sender, GameEventArgs e)
        {
            var ne = e as UnityGameFramework.Runtime.NetworkErrorEventArgs;

            Log.Error("Network channel '{0}' error, error code is '{1}', error message is '{2}'.", ne.NetworkChannel.Name, ne.ErrorCode.ToString(), ne.ErrorMessage);
        }

        private void OnNetworkCustomError(object sender, GameEventArgs e)
        {

        }

    }
}
