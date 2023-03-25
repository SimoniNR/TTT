using NetworkShared;
using NetworkShared.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Server.NetworkShared;

namespace TTT.Server.PacketHandlers
{
    [HandlerRegister(PacketType.AuthRequest)]
    
    public class AuthRequestHandler : IPacketHandler
    {
        public void Handle(INetPacket packet, int connectionId)
        {
            throw new NotImplementedException();
        }
    }
}
