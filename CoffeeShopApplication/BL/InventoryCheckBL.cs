using CoffeeShopApplication.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace CoffeeShopApplication.BL
{
    public class InventoryCheckBL
    {
        public static DataSet getAllInventoryCheckFromView()
        {
            string query = "SELECT * FROM GetInventoryCheckView";
            DataSet ds = DBConnection.getInstance().ExecuteQuery(query, CommandType.Text, null);
            return ds;
        }
        public static DataSet findInventoryCheckByDateFromView(string date)
        {
            try
            {
                string str = "SELECT * FROM dbo.FindInventoryCheckByDateFromViewFunction(@checkDate)";
                SqlParameter checkDateParam = new SqlParameter("@checkDate", date);
                SqlParameter[] parameters = { checkDateParam };
                DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, parameters);
                return ds;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error occurred while finding inventory check by date: " + ex.Message);
                return null;
            }
        }
        public static bool addInventoryCheck(string employeeId, string inventoryId, string date)
        {
            try
            {
                string procedureName = "InsertInventoryCheckProc";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@employeeId", employeeId),
                    new SqlParameter("@inventoryId", inventoryId),
                    new SqlParameter("@checkDate", date)
                };
                bool success = DBConnection.getInstance().ExecuteNonQuery(procedureName, CommandType.StoredProcedure, parameters);
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while adding inventory check: " + ex.Message);
                return false;
            }
        }

        public static bool updateInventoryCheck(string checkId, string employeeId, string inventoryId, string date)
        {
            try
            {
                string procedureName = "UpdateInventoryCheckProc";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@checkId", checkId),
                    new SqlParameter("@employeeId", employeeId),
                    new SqlParameter("@inventoryId", inventoryId),
                    new SqlParameter("@checkDate", date)
                };
                bool success = DBConnection.getInstance().ExecuteNonQuery(procedureName, CommandType.StoredProcedure, parameters);
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while updating inventory check: " + ex.Message);
                return false;
            }
        }

        public static bool deleteInventoryCheck(string checkId)
        {
            try
            {
                string procedureName = "DeleteInventoryCheckProc";
                SqlParameter[] parameters = { new SqlParameter("@checkId", checkId) };
                bool success = DBConnection.getInstance().ExecuteNonQuery(procedureName, CommandType.StoredProcedure, parameters);
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while deleting inventory check: " + ex.Message);
                return false;
            }
        }

    }
}