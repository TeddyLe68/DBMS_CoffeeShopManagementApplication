using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopApplication.DB
{
    public class ConnectionDB
    {
        // init connection
        private static ConnectionDB _instance;
        private static SqlConnection conn;
        private const string serverName = "TATTHANG";

        // private constructor to prevent instantiation of the class
        private ConnectionDB()
        {
            string connectionString = $"Server={serverName};Database=CoffeeShopManagement;Integrated Security=True;";
            conn = new SqlConnection(connectionString);
        }

        // get connection string
        public string GetConnectionString()
        {
            return conn.ConnectionString;
        }

        // get instance of the class to use
        public static ConnectionDB getInstance()
        {
            if (_instance == null || conn == null)
            {
                _instance = new ConnectionDB();
            }
            return _instance;
        }

        public bool TestConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Test Failed");
                return false;
            }
        }

    }
}
