using FSImageServer.Controllers;
using SocketAppServer.LoadBalancingServices;
using SocketAppServer.ServerObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketAppServer.Extensions.HttpServer;
using System.Net.Sockets;
using SocketAppServer.Hosting;

namespace FSImageServer
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketServerHost.CreateHostBuilder()
                .UseStartup<Startup>()
                .Run();
        }
    }
}
