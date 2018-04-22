using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLD.RegistroNET
{
    public class Configuration
    {
        public static string application = "em3";
        public static string server = "localhost";
        public static int port = 8081;
        public static int standard_company = 0;
        public static int nav_mode = 0; //0 = Tabs; 1 = Windows;
        public static bool quiet_mode = false;
        public static bool suppress_exception = false;
        public static int licence_mode = 1; //1 - producao; 0 - homologacao;
        public static string cache_server = "";
        public static int cache_server_port = 8081;
        public static string cache_application = "";

        public static string GetApplication
        {
            get
            {
                return ("http://" + server + ":" + port + "/" + application + "/");
            }
        }

        public static bool LoadFromLocalSettings()
        {
            StreamReader reader = null;
            try
            {
                string localFile = Directory.GetCurrentDirectory() + @"\Files\NetLauncher.dwconf";
                if (!File.Exists(localFile))
                    return false;

                reader = new StreamReader(localFile);
                string line = "";

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("licence_mode"))
                    {
                        string value = line.Replace("licence_mode=", "");
                        licence_mode = int.Parse(value);
                        continue;
                    }

                    if(line.StartsWith("cache_server"))
                    {
                        string value = line.Replace("cache_server=", "");
                        cache_server = value;
                        continue;
                    }

                    if(line.StartsWith("cache_server_port"))
                    {
                        string value = line.Replace("cache_server_port=", "");
                        cache_server_port = int.Parse(value);
                        continue;
                    }

                    if(line.StartsWith("cache_application"))
                    {
                        string value = line.Replace("cache_application=", "");
                        cache_application = value;
                        continue;
                    }

                    if (line.StartsWith("interface"))
                    {
                        string value = line.Replace("interface=", "");
                        nav_mode = (value.Equals("windows") ? 1 : 0);
                        continue;
                    }

                    if (line.StartsWith("quiet"))
                    {
                        string value = line.Replace("quiet=", "");
                        quiet_mode = value.Equals("enabled");
                        continue;
                    }

                    if(line.StartsWith("suppress_exceptions"))
                    {
                        string value = line.Replace("suppress_exceptions=", "");
                        suppress_exception = value.Equals("true");
                        continue;
                    }

                    if (line.StartsWith("appserver_port"))
                    {
                        port = int.Parse(line.Replace("appserver_port=", ""));
                        continue;
                    }

                    if (line.StartsWith("appserver"))
                    {
                        server = line.Replace("appserver=", "");
                        continue;
                    }

                    if (line.StartsWith("default_application"))
                    {
                        application = line.Replace("default_application=", "");
                        continue;
                    }
                }

                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (reader != null) reader.Close();
            }

            return false;
        }
    }
}
