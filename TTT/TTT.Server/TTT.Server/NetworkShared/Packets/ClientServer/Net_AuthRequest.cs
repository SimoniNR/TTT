using LiteNetLib.Utils;

namespace NetworkShared.Packets.ClientServer
{
    public class Net_AuthRequest : INetPacket
    {
        public PacketType Type => PacketType.AuthRequest;

        public string Username { get; set; }
        public string Password { get; set; }


       //receiving the message
        public void Deserialize(NetDataReader reader)
        {
            Username = reader.GetString();
            Password = reader.GetString();
        }

       //sending the message
        public void Serialize(NetDataWriter writer)
        {
            //get the strings username and password and converting to byte to make networking information lighter
            writer.Put((byte)Type);
            writer.Put(Username);
            writer.Put(Password);
        }
    }
}
