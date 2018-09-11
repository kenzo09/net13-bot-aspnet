using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SimpleBot.Repository
{
    public class ConnectionFactory
    {
        public static DbConnection GetConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString);
            connection.Open();
            
            return connection;
        }
    }
}