using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreData
{
    public class MusicStoreDB
    {
        public static SqlConnection GetSqlConnection()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["musicStoreConnectionString"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}