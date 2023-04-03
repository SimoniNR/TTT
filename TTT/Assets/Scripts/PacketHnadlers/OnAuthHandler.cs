using NetworkShared;
using NetworkShared.Attributes;
using UnityEngine.SceneManagement;

namespace TTT.PacketHnadlers
{
    [HandlerRegister(PacketType.OnAuth)]
    public class OnAuthHandler : IPacketHandler
    {
        public void Handle(INetPacket packet, int connectionId)
        {

            SceneManager.LoadScene("01_Lobby");

        }
    }
}
