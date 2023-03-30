using System.Collections.Generic;
using TTT.Server.Data;

namespace TTT.Server.Game
{
    public class UsersManager
    {
        private Dictionary<int, ServerConnection> _connections;
        private readonly IUserRepository _userRespository;

        public UsersManager(IUserRepository userRespository) 
        {
            _userRespository = userRespository;
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
    }
}
