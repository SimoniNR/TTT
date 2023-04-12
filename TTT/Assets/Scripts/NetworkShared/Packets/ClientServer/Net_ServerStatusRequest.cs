﻿using LiteNetLib.Utils;
using NetworkShared;

namespace NetworkShared.Packets.ClientServer
{
    public struct Net_ServerStatusRequest : INetPacket
    {
        public PacketType Type => PacketType.ServerStatusRequest;

        public void Deserialize(NetDataReader reader)
        {
            throw new System.NotImplementedException();
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)Type);
        }
    }
}
