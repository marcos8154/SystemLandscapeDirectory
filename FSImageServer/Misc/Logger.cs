using SocketAppServer.CoreServices.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FSImageServer.Misc
{
    public class Logger : ILoggerWrapper
    {
        public List<ServerLog> List(Expression<Func<ServerLog, bool>> query)
        {
            return new List<ServerLog>();
        }

        public void Register(ref ServerLog log)
        {
            using(StreamWriter sw = new StreamWriter(@"C:\temp\IMG_SERV_LOG.log", true))
            {
                sw.WriteLineAsync($"[{log.Type}][{log.EventDate}]@{log.ActionName}/{log.ActionName}: {log.LogText}");
            }
        }
    }
}
