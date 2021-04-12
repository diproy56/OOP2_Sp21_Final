using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sql_DB
{
    class Database
    {
        public static SqlConnection ConnectDatabase()
        {
            string connString = @"Server=DESKTOP-NEQG5IT;Database=sql_demo;Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
