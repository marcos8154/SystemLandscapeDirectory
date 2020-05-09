using FSImageServer.Controllers;
using FSImageServer.Misc;
using Newtonsoft.Json;
using SocketAppServer.CoreServices;
using SocketAppServer.CoreServices.CoreServer;
using SocketAppServer.Extensions.HttpServer;
using SocketAppServer.LoadBalancingServices;
using SocketAppServer.ManagedServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSImageServer
{
    public class Startup : AppServerConfigurator
    {
        ServerConfig config = null;
        public override void ConfigureServices(IServiceManager serviceManager)
        {
            string jsonConfig = File.ReadAllText(@".\serverconfig.json");
            config = JsonConvert.DeserializeObject<ServerConfig>(jsonConfig);
            Consts.Configure(config);

            SetDefaultLoggerWrapper(new Logger());

            if (config.IsLoadBalanceFrontServer)
            {
                string jsonLb = File.ReadAllText(@".\loadbalanceserverconfig.json");
                LoadBalanceConfig lbConfig = JsonConvert.DeserializeObject<LoadBalanceConfig>(jsonLb);
                LoadBalanceConfigurator configurator = EnableLoadBalanceServer(lbConfig.MaxAttemptsToGetAvailableServer, lbConfig.CacheResultsForUnreachableServers);

                foreach (var subServer in lbConfig.SubServers)
                    configurator.AddSubServer(subServer.Address, subServer.Port,
                        Encoding.GetEncoding(subServer.Encoding), subServer.BufferSize,
                        subServer.MaxConnectionsAttemtps, subServer.MaxThreadsCount);
            }
            else
                RegisterController(typeof(ImageController));

            if (config.EnableHTTPComunication)
                EnableExtension(new HttpModule($"{config.HttpServerAddress}/"));
        }

        public override ServerConfiguration GetServerConfiguration()
        {
            return new ServerConfiguration(Encoding.GetEncoding(config.Encoding),
                config.TCPPort, config.BufferSize, false,
                config.MaxThreadsCount);
        }
    }
}
