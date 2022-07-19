using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace СофтТрейдПлюс.Model
{
    internal static class DataBase
    {
        private static readonly string connectionStrings = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static SqlConnection sqlConnection = new SqlConnection(connectionStrings);

        public static SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }

        public static void OpenConnection()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Closed)
            {
                SqlConnection.Open();
            }
        }

        public static void CloseConnection()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }

        public static SqlConnection getConnect()
        {
            return SqlConnection;
        }
    }
}
