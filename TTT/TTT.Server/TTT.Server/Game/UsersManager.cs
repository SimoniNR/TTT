using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using TTT.Server.Data;

namespace TTT.Server.Game
{
    public class UsersManager
    {
        private Dictionary<int, ServerConnection> _connections;
        private readonly IUserRepository _userRespository;

        public UsersManager(IUserRepository userRespository) 
        {
            _connections = new Dictionary<int, ServerConnection>();
            _userRespository = userRespository;
        }

        public void AddConnection(NetPeer peer)
        {
            _connections.Add(peer.Id, new ServerConnection
            {
                ConnectionId = peer.Id,
                Peer = peer

            });

        }
        public bool LoginOrRegister(int connectionID, string username, string password)
        {
            var dbUser = _userRespository.get(username);

            if (dbUser == null) 
            {
                if (dbUser.Password != password)
                {
                    return false;
                }
            }

            if (dbUser == null) 
            {
                var newUser = new User
                {
                    Id = username,
                    Password = password,
                    IsOnline = true,
                    Score = 0,
                };

                _userRespository.Add(newUser);
                dbUser = newUser;
            }
            if(_connections.ContainsKey(connectionID)) 
            { 
                dbUser.IsOnline = true;
                _connections[connectionID].User = dbUser;
            
            }
            
            return true;
        }

        internal void Disconnect(int peerId)
        {
            var connection = GetConnection(peerId);
            if (connection.User != null) 
            {
                var userId = connection.User.Id;
                _userRespository.SetOffline(userId);

                //matchmaker.Unregister

                //gamesManager.CloseGame


            }
            _connections.Remove(peerId);
        }

        public ServerConnection GetConnection(int peerId)
        {
            return _connections[peerId];
        }

        public int[] GetOtherConnectionIds(int excludedconnectionId)
        {
            return _connections.Keys.Where(v => v != excludedconnectionId).ToArray();
        }
    }
}
