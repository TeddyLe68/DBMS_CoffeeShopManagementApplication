using CoffeeShopApplication.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopApplication.BL
{
    public class InventoryCheckDetailsBL
    {
        public DataSet getAllInventoryCheckDetails()
        {
            String str = "Select * from InventoryCheckDetails";
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, null);
            return ds;
        }
        public static DataSet findInventoryCheckDetailsById(string checkId)
        {
            string str = "SELECT * FROM GetInventoryCheckDetailsView WHERE checkId = @checkId";
            SqlParameter productParam = new SqlParameter("@checkId", checkId);
            SqlParameter[] parameters = { productParam };
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, parameters);
            return ds;
        }
        public static bool addInventoryCheckDetails(string ingredientId, string checkId, string quantity)
        {
            if (ingredientId == "" || quantity == "")
                return false;
            try
            {
                string procedureName = "InsertInventoryCheckDetailsProc";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ingredientId", ingredientId),
                    new SqlParameter("@checkId", checkId),
                    new SqlParameter("@quantity", quantity)
                };
                bool success = DBConnection.getInstance().ExecuteNonQuery(procedureName, CommandType.StoredProcedure, parameters);
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while adding inventory check details: " + ex.Message);
                return false;
            }
        }

        public static bool updateInventoryCheckDetails(string ingredientId, string checkId, string quantity)
        {
            if (ingredientId == "" || checkId == "" || quantity == "")
                return false;
            try
            {
                string procedureName = "UpdateInventoryCheckDetailsProc";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ingredientId", ingredientId),
                    new SqlParameter("@checkId", checkId),
                    new SqlParameter("@quantity", quantity)
                };
                bool success = DBConnection.getInstance().ExecuteNonQuery(procedureName, CommandType.StoredProcedure, parameters);
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while updating inventory check details: " + ex.Message);
                return false;
            }
        }

        public static bool deleteInventoryCheckDetails(string ingredientId, string checkId)
        {
            try
            {
                string procedureName = "DeleteInventoryCheckDetailsProc";
                SqlParameter[] parameters =
                {

                    new SqlParameter("@ingredientId", ingredientId),
                    new SqlParameter("@checkId", checkId),
                };
                bool success = DBConnection.getInstance().ExecuteNonQuery(procedureName, CommandType.StoredProcedure, parameters);
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while deleting inventory check details: " + ex.Message);
                return false;
            }
        }

    }
}