using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopApplication.Test
{
 
    public class DBConnect
    {
        private static DBConnect _instance;
        private static SqlConnection conn = null;
        private const string serverName = "TATTHANG";
        private DBConnect()
        {
            string connectionString = $"Server={serverName};Database=CoffeeShopManagement;Integrated Security=True;";
            conn = new SqlConnection(connectionString);
        }
        public static DBConnect getInstance()
        {
            if (_instance == null || conn == null)
            {
                _instance = new DBConnect();
            }
            return _instance;
        }
        public bool TestConnection()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
