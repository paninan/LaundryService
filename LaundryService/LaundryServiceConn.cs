using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryService
{
    class LaundryServiceConn
    {
        private static string connetionString;
        private static SqlConnection conn = null;

        public static SqlConnection GetConnection()
        {
            connetionString = ConfigurationManager.ConnectionStrings["laundryService"].ConnectionString;
            conn = new SqlConnection(connetionString);
            return conn;
        }

        public static SqlConnection GetConnection(string dbname)
        {
            connetionString = ConfigurationManager.ConnectionStrings[dbname].ConnectionString;
            conn = new SqlConnection(connetionString);
            return conn;
        }
    }
}
