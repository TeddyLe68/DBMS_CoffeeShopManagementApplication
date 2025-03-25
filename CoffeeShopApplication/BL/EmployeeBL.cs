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
    public class EmployeeBL
    {
        public static DataSet getAllEmployee()
        {
            String str = "Select * from Employee";
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, null);
            return ds;
        }

        public static DataSet findEmployeeByName(String employeeName)
        {
            String str = "SELECT * FROM dbo.findEmployeeByNameFunction(@employeeName)";
            SqlParameter productNameParam = new SqlParameter("@employeeName", employeeName);
            SqlParameter[] parameters = { productNameParam };
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, parameters);
            return ds;
        }

        public static DataSet findEmployeeByPhoneNumber(String phoneNumber)
        {
            String str = "SELECT * FROM dbo.findEmployeeByPhoneNumberFunction(@PhoneNumber)";
            SqlParameter phoneNumberParam = new SqlParameter("@PhoneNumber", phoneNumber);
            SqlParameter[] parameters = { phoneNumberParam };
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, parameters);
            return ds;
        }

        public static bool addEmployee(string fullName, string phoneNumber, string address, string email, string isWorking)
        {
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(phoneNumber) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(isWorking))
                return false;

            try
            {
                // Chuyển đổi "Yes" thành true, ngược lại là false
                bool isWorkingBool = (isWorking == "Yes");

                string str = "AddEmployeeProc";
                SqlParameter FullNameParam = new SqlParameter("@FullName", fullName);
                SqlParameter PhoneNumParam = new SqlParameter("@PhoneNumber", phoneNumber);
                SqlParameter AddressParam = new SqlParameter("@Address", address);
                SqlParameter EmailParam = new SqlParameter("@Email", email);
                SqlParameter IsWorkingParam = new SqlParameter("@IsWorking", isWorkingBool); // Chuyển sang kiểu bool

                SqlParameter[] parameters = { FullNameParam, PhoneNumParam, AddressParam, EmailParam, IsWorkingParam };
                bool commandResult = DBConnection.getInstance().ExecuteNonQuery(str, CommandType.StoredProcedure, parameters);
                return commandResult;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }


        public static bool updateEmployee(string id, string fullName, string phoneNumber, string address, string email, string isWorking, string updateType)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Chuyển đổi "Yes" thành true, ngược lại là false
                bool isWorkingBool = isWorking.Equals("Yes", StringComparison.OrdinalIgnoreCase);
                Guid employeeGuid;

                if (!Guid.TryParse(id, out employeeGuid))
                {
                    MessageBox.Show("Employee ID không hợp lệ!", "Lỗi");
                    return false;
                }

                String str = "UpdateEmployeeProc";
                SqlParameter EmployeeIdParam = new SqlParameter("@EmployeeId", SqlDbType.UniqueIdentifier) { Value = employeeGuid };
                SqlParameter FullNameParam = new SqlParameter("@FullName", fullName);
                SqlParameter PhoneNumParam = new SqlParameter("@PhoneNumber", phoneNumber);
                SqlParameter AddressParam = new SqlParameter("@Address", address);
                SqlParameter EmailParam = new SqlParameter("@Email", email);
                SqlParameter IsWorkingParam = new SqlParameter("@IsWorking", isWorkingBool);
                SqlParameter UpdateTypeParam = new SqlParameter("@UpdateType", updateType);

                SqlParameter[] parameters = { EmployeeIdParam, FullNameParam, PhoneNumParam, AddressParam, EmailParam, IsWorkingParam, UpdateTypeParam };

                bool commandResult = DBConnection.getInstance().ExecuteNonQuery(str, CommandType.StoredProcedure, parameters);
                return commandResult;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi cập nhật: " + e.Message, "Lỗi");
                return false;
            }
        }

    }
}