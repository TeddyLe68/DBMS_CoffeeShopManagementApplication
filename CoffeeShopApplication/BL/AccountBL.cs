using CoffeeShopApplication.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopApplication.BL
{
    public class AccountBL
    {
        
        public static DataSet getAllAccount()
        {
            String str = "Select * from Account";
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, null);
            return ds;
        }
        //get role
        public static string getRole(string accountId)
        {
            try
            {
                string sqlStr = string.Format($"SELECT role FROM Account WHERE accountId = '{accountId}'");
                DataTable dtable = new DataTable();
                string connectionString = "Server=TATTHANG;Database=CoffeeShopManagement;Integrated Security=True;";
                SqlDataAdapter sda = new SqlDataAdapter(sqlStr, connectionString);
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    return dtable.Rows[0].ItemArray[0].ToString();
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi ở đây, ví dụ:
                Console.WriteLine("Error occurred while getting role: " + ex.Message);
            }
            return "";
        }


        public static DataSet findAccountByUserName(string username)
        {
            String str = "SELECT * FROM dbo.findAccountByUserName(@userName)";
            SqlParameter accountUserNameParam = new SqlParameter("@userName", username);
            SqlParameter[] parameters = { accountUserNameParam };
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, parameters);
            return ds;
        }
        public static string getAccount(string userName, string password)
        {
            try
            {
                string sqlStr = string.Format($"SELECT * FROM Account WHERE username = '{userName}' AND password = '{password}'");
                DataTable dtable = new DataTable();
                string connectionString = "Server=TATTHANG;Database=CoffeeShopManagement;Integrated Security=True;";
                SqlDataAdapter sda = new SqlDataAdapter(sqlStr, connectionString);

                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    return dtable.Rows[0].ItemArray[0].ToString();
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi ở đây, ví dụ:
                Console.WriteLine("Error occurred while getting account: " + ex.Message);
            }
            return "";
        }

        public static bool addAccount(string employeeId, string passwords, string userName, string role)
        {
            if (employeeId == "" || passwords == "" || userName == "" || role == "")
                return false;

            try
            {
                String str = "AddAccountProc";
                SqlParameter EmployeeIdParam = new SqlParameter("@EmployeeId", employeeId);
                SqlParameter PasswordsParam = new SqlParameter("@Passwords", passwords);
                SqlParameter UserNameParam = new SqlParameter("@UserName", userName);
                SqlParameter RoleParam = new SqlParameter("@Role", role);
                SqlParameter[] parameters = { EmployeeIdParam, PasswordsParam, UserNameParam, RoleParam };
                bool commandResult = DBConnection.getInstance().ExecuteNonQuery(str, CommandType.StoredProcedure, parameters);
                return commandResult;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool updateAccount(string employeeId, string accountId, string passwords, string userName, string role, string isDeleted)
        {
            if (employeeId == "" || accountId == "" || passwords == "" || userName == "" || role == "")
                return false;

            try
            {
                String str = "UpdateAccountProc";
                SqlParameter EmployeeIdParam = new SqlParameter("@EmployeeId", employeeId);
                SqlParameter accountIdParam = new SqlParameter("@AccountId", accountId);
                SqlParameter PasswordsParam = new SqlParameter("@Passwords", passwords);
                SqlParameter UserNameParam = new SqlParameter("@UserName", userName);
                SqlParameter RoleParam = new SqlParameter("@Role", role);
                SqlParameter isDeletedParam = new SqlParameter("@IsDeleted", isDeleted);
                SqlParameter[] parameters = { EmployeeIdParam, accountIdParam, PasswordsParam, UserNameParam, RoleParam, isDeletedParam };
                bool commandResult = DBConnection.getInstance().ExecuteNonQuery(str, CommandType.StoredProcedure, parameters);
                return commandResult;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}