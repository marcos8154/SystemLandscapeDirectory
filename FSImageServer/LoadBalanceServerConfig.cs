using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSImageServer
{
    public class LoadBalanceConfig
    {
        public int MaxAttemptsToGetAvailableServer { get; set; }
        public bool CacheResultsForUnreachableServers { get; set; }
        public Subserver[] SubServers { get; set; }
    }

    public class Subserver
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public string Encoding { get; set; }
        public int BufferSize { get; set; }
        public int MaxConnectionsAttemtps { get; set; }
        public int MaxThreadsCount { get; set; }
    }
}
