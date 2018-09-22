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
            // Evite usar o ConfigurationManager durante a execução - faça isso no Startup
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString);
            
            // Nao está errado - mas muito cuidado com abertura automática de conexão
            connection.Open();
            
            return connection;
        }
    }
}
