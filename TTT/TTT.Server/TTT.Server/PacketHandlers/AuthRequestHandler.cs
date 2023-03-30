using Microsoft.Extensions.Logging;
using NetworkShared;
using NetworkShared.Attributes;
using NetworkShared.Packets.ClientServer;
using TTT.Server.Game;
using TTT.Server.NetworkShared;
using TTT.Server.NetworkShared.Packets.ClientServer.ServerClient;

namespace TTT.Server.PacketHandlers
{
    [HandlerRegister(PacketType.AuthRequest)]

    public class AuthRequestHandler : IPacketHandler
    {
        private readonly ILogger<AuthRequestHandler> _logger;
        private readonly UsersManager _usersManager;
        private readonly NetworkServer _server;

        public AuthRequestHandler(
            ILogger<AuthRequestHandler> logger,
            UsersManager usersManager,
            NetworkServer server)
        {
            _logger = logger;
            _usersManager = usersManager;
            _server = server;
        }

        public void Handle(INetPacket packet, int connectionId)
        {
            var msg = (Net_AuthRequest)packet;

            // Logging
            _logger.LogInformation($"Received login request for user: {msg.Username} with pass: {msg.Password}");

            //logging or Register
            var loginSuccess = _usersManager.LoginOrRegister(connectionId, msg.Username, msg.Password);

            INetPacket rmsg;
            if ( loginSuccess ) 
            { 
                rmsg = new Net_OnAuth();
            }
            else
            {
                rmsg = new Net_OnAuthFail();
            }

            _server.SendClient(connectionId, rmsg);
            
            //if sucess, send back Net_OAuth message#
            if ( loginSuccess ) 
            {
                notifyOtherPlayer(connectionId);
            }

            //else, send back Net_OAuthFail message
        }
    }
}
