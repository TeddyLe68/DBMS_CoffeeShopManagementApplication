using CoffeeShopApplication.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopApplication.BL
{
    public class RestockBillDetailsBL
    {
        public static DataSet findRestockBillDetailsById(String restockBillId)
        {
            String str = "SELECT * FROM GetRestockBillView WHERE restockBillId = @restockBillId";
            SqlParameter restockBillIdParam = new SqlParameter("@restockBillId", restockBillId);
            SqlParameter[] parameters = { restockBillIdParam };
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, parameters);
            return ds;
        }

        public static bool addRestockBillDetails(String ingredientId, String restockBillId, String quantity, String price)
        {
            if (ingredientId == "" || quantity == "" || price == "")
                return false;

            try
            {
                int.Parse(quantity);
                float.Parse(price);

                String str = "InsertRestockBillDetailsProc";
                SqlParameter ingredientIdParam = new SqlParameter("@ingredientId", ingredientId);
                SqlParameter restockBillIdParam = new SqlParameter("@restockBillId", restockBillId);
                SqlParameter quantityParam = new SqlParameter("@quantity", quantity);
                SqlParameter priceParam = new SqlParameter("@price", price);
                SqlParameter[] parameters = { ingredientIdParam, restockBillIdParam, quantityParam, priceParam };
                bool commandResult = DBConnection.getInstance().ExecuteNonQuery(str, CommandType.StoredProcedure, parameters);
                return commandResult;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool deleteRestockBillDetails(String ingredientId, String restockBillId)
        {
            if (ingredientId == "" || restockBillId == "")
                return false;
            try
            {
                String str = "DeleteRestockBillDetailsProc";
                SqlParameter ingredientIdParam = new SqlParameter("@ingredientId", ingredientId);
                SqlParameter restockBillIdParam = new SqlParameter("@restockBillId", restockBillId);
                SqlParameter[] parameters = { ingredientIdParam, restockBillIdParam };
                bool commandResult = DBConnection.getInstance().ExecuteNonQuery(str, CommandType.StoredProcedure, parameters);
                return commandResult;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool updateRestockBill(String ingredientId, String restockBillId, String quantity, String price)
        {
            if (ingredientId == "" || restockBillId == "" || quantity == "" || price == "")
                return false;

            try
            {
                String str = "UpdateRestockBillDetailsProc";
                SqlParameter ingredientIdParam = new SqlParameter("@ingredientId", ingredientId);
                SqlParameter restockBillIdParam = new SqlParameter("@restockBillId", restockBillId);
                SqlParameter quantityParam = new SqlParameter("@quantity", quantity);
                SqlParameter priceParam = new SqlParameter("@price", price);
                SqlParameter[] parameters = { ingredientIdParam, restockBillIdParam, quantityParam, priceParam };
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