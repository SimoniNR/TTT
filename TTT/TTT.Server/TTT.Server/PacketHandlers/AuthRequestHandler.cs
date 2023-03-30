using Microsoft.Extensions.Logging;
using NetworkShared;
using NetworkShared.Attributes;
using NetworkShared.Packets.ClientServer;
using TTT.Server.Game;
using TTT.Server.NetworkShared;

namespace TTT.Server.PacketHandlers
{
    [HandlerRegister(PacketType.AuthRequest)]

    public class AuthRequestHandler : IPacketHandler
    {
        private readonly ILogger<AuthRequestHandler> _logger;
        private readonly UsersManager _usersManager;

        public AuthRequestHandler(ILogger<AuthRequestHandler> logger,
            UsersManager usersManager )
        {
            _logger = logger;
        }

        public void Handle(INetPacket packet, int connectionId)
        {
            var msg = (Net_AuthRequest)packet;

            // Logging
            _logger.LogInformation($"Received login request for user: {msg.Username} with pass: {msg.Password}");

            var loginSuccess = _usersManager.LoginOrRegister(connectionId, msg.Username, msg.Password);

            //logging or Register

            //if sucess, send back Net_OAuth message

            //else, send back Net_OAuthFail message
        }
    }
}
