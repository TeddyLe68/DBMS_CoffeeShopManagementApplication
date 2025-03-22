using CoffeeShopApplication.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopApplication.BL
{
    public class CustomerBL
    {
        public static DataSet getAllCustomers()
        {
            String str = "Select * from Customer";
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, null);
            return ds;
        }
        public static DataSet findCustomerByPhoneNumber(String phoneNumber)
        {
            String str = "SELECT * FROM dbo.findCustomerByPhoneNumberFunction(@phoneNumber)";
            SqlParameter customerPhoneNumParam = new SqlParameter("@phoneNumber", phoneNumber);
            SqlParameter[] parameters = { customerPhoneNumParam };
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, parameters);
            return ds;
        }
        public static DataSet findCustomerByName(String customerName)
        {
            String str = "SELECT * FROM dbo.findCustomerByNameFunction(@CustomerName)";
            SqlParameter customerNameParam = new SqlParameter("@CustomerName", customerName);
            SqlParameter[] parameters = { customerNameParam };
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, parameters);
            return ds;
        }

        public static bool addCustomer(String customerName, String phoneNumber)
        {
            if (customerName == "" || phoneNumber == "")
                return false;

            try
            {
                String str = "InsertCustomerProc";
                SqlParameter customerNameParam = new SqlParameter("@customerName", customerName);
                SqlParameter phoneNumberParam = new SqlParameter("@phoneNumber", phoneNumber);
                SqlParameter[] parameters = { customerNameParam, phoneNumberParam };
                bool commandResult = DBConnection.getInstance().ExecuteNonQuery(str, CommandType.StoredProcedure, parameters);
                return commandResult;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool updateCustomer(String customerId, String customerName, String phoneNumber, bool isDeleted)
        {
            if (customerId == "" || customerName == "" || phoneNumber == "")
            {
                return false;
            }
            try
            {
                String str = "UpdateCustomerProc";
                SqlParameter customerIdParam = new SqlParameter("@customerId", customerId);
                SqlParameter customerNameParam = new SqlParameter("@customerName", customerName);
                SqlParameter phoneNumberParam = new SqlParameter("@phoneNumber", phoneNumber);
                SqlParameter isDeletedParam = new SqlParameter("@isDeleted", isDeleted.ToString());
                SqlParameter[] parameters = { customerIdParam, customerNameParam, phoneNumberParam, isDeletedParam };
                bool commandResult = DBConnection.getInstance().ExecuteNonQuery(str, CommandType.StoredProcedure, parameters);
                return commandResult;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public static bool deleteCustomer(String customerId)
        {
            if (customerId == "")
                return false;
            try
            {
                String str = "DeleteCustomerProc";
                SqlParameter customerIdParam = new SqlParameter("@customerId", customerId);
                SqlParameter[] parameters = { customerIdParam };
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