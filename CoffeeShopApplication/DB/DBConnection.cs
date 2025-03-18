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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CoffeeShopApplication.DB
{
    public class DBConnection
    {
        // init connection
        private static DBConnection _instance;
        private static SqlConnection conn;
        private static string username, password;
        private const string serverName = "TATTHANG";

        public static string Username { set => username = value; }
        public static string Password { set => password = value; }
        public static void resetConnection()
        {
            conn = null;
            Username = null;
            Password = null;
        }


        // private constructor to prevent instantiation of the class
        private DBConnection()
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
        public static DBConnection getInstance()
        {
            if (_instance == null || conn == null)
            {
                _instance = new DBConnection();
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
        public DataSet ExecuteQuery(string sqlStr, CommandType ct, SqlParameter[] parameters = null)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Connection Error"); }

            SqlCommand comm = new SqlCommand(sqlStr, conn);
            comm.CommandType = ct;
            if (parameters != null)
                comm.Parameters.AddRange(parameters);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "ERROR MESSAGE"); }
            return ds;
        }
        public bool ExecuteNonQuery(string sqlStr, CommandType ct, SqlParameter[] parameters = null)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Connection Error"); }

            SqlCommand comm = new SqlCommand(sqlStr, conn);
            comm.CommandType = ct;
            if (parameters != null)
                comm.Parameters.AddRange(parameters);
            try
            {
                comm.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR");
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
