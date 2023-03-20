using System.Threading;
using TTT.Server;

var server = new NetworkServer();
server.Start();

while (true)
{
    server.PoolEvents();
    Thread.Sleep(15);
}

