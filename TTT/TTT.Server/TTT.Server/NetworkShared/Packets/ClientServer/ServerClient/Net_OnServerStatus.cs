using LiteNetLib.Utils;
using NetworkShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT.Server.NetworkShared.Packets.ClientServer.ServerClient
{
    public struct Net_OnServerStatus : INetPacket
    {
        public PacketType Type => PacketType.OnServerStatus;

        public void Deserialize(NetDataReader reader)
        {
        }

        public void Serialize(NetDataWriter writer)
        {
            //TODO: implement
            writer.Put((byte)Type);
        }
    }
}
