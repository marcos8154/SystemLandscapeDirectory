using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace SLD.Controller
{
    public class ConnectionManager
    {
        public static SqlConnection GetConnection()
        {
            return new ConnectionManager().OpenConnection();
        }

        public SqlConnection OpenConnection()
        {
            string confFile = @".\Files\SLD.conf";
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = File.ReadAllLines(confFile)[0].FromCompact();
            sb.UserID = File.ReadAllLines(confFile)[1].FromCompact();
            sb.Password = File.ReadAllLines(confFile)[2].FromCompact();
            sb.InitialCatalog = "SLD";

            SqlConnection conn = new SqlConnection(sb.ConnectionString);
            conn.Open();

            return conn;
        }
    }
}
