using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSImageServer
{
    public class ServerConfig
    {
        public bool IsLoadBalanceFrontServer { get; set; }
        public int TCPPort { get; set; }
        public int BufferSize { get; set; }
        public string Encoding { get; set; }
        public int MaxThreadsCount { get; set; }
        public bool EnableHTTPComunication { get; set; }
        public string HttpServerAddress { get; set; }
        public string TempImagesPath { get; set; }
        public string ImageStoragePath { get; set; }
        public string ImageQualityConvertLevel { get; set; }
    }
}
