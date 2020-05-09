using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSImageServer
{
    public class Consts
    {
        public static string TempPath { get; private set; }
        public static string StoragePath { get; private set; }
        public static string QualityLevel { get; private set; }
        public static bool IsBalanceServer { get; private set; }

        public static void Configure(ServerConfig config)
        {
            if (!Directory.Exists(config.TempImagesPath))
                Directory.CreateDirectory(config.TempImagesPath);
            TempPath = config.TempImagesPath;

            if (!Directory.Exists(config.ImageStoragePath))
                Directory.CreateDirectory(config.ImageStoragePath);
            StoragePath = config.ImageStoragePath;
            QualityLevel = config.ImageQualityConvertLevel;
            IsBalanceServer = config.IsLoadBalanceFrontServer;
        }
    }
}
