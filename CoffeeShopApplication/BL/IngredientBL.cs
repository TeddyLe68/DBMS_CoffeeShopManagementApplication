using System;
using System.Collections.Generic;
using CoffeeShopApplication.DB;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CoffeeShopApplication.BL
{
    public class IngredientBL
    {
        public static DataSet getAllIngredients()
        {
            String str = "Select * from Ingredient";
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, null);
            return ds;
        }

        public static DataSet findIngredientsByName(String ingredientName)
        {
            String str = "SELECT * FROM dbo.FindIngredientByNameFunction(@ingredientName)";
            SqlParameter ingredientNameParam = new SqlParameter("@ingredientName", ingredientName);
            SqlParameter[] parameters = { ingredientNameParam };
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, parameters);
            return ds;
        }

        public static bool updateIngredient(String ingredientId, String ingredientName, String manufacturerName, bool isDeleted)
        {
            if (ingredientId == "" || ingredientName == "" || manufacturerName == "")
                return false;

            try
            {
                String str = "UpdateIngredientProc";
                SqlParameter ingredientIdParam = new SqlParameter("@ingredientId", ingredientId);
                SqlParameter ingredientNameParam = new SqlParameter("@ingredientName", ingredientName);
                SqlParameter manufacturerNameParam = new SqlParameter("@manufacturerName", manufacturerName);
                SqlParameter isDeletedParam = new SqlParameter("@isDeleted", isDeleted.ToString());
                SqlParameter[] parameters = { ingredientIdParam, ingredientNameParam, manufacturerNameParam, isDeletedParam };
                bool commandResult = DBConnection.getInstance().ExecuteNonQuery(str, CommandType.StoredProcedure, parameters);
                return commandResult;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public static bool addIngredient(String ingredientName, String manufacturerName)
        {
            if (ingredientName == "" || manufacturerName == "")
                return false;

            try
            {
                String str = "InsertIngredientProc";
                SqlParameter ingredientNameParam = new SqlParameter("@ingredientName", ingredientName);
                SqlParameter manufacturerNameParam = new SqlParameter("@manufacturerName", manufacturerName);
                SqlParameter[] parameters = { ingredientNameParam, manufacturerNameParam };
                bool commandResult = DBConnection.getInstance().ExecuteNonQuery(str, CommandType.StoredProcedure, parameters);
                return commandResult;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool deleteIngredient(String ingredientId)
        {
            if (ingredientId == "")
                return false;
            try
            {
                String str = "DeleteIngredientProc";
                SqlParameter ingredientIdParam = new SqlParameter("@ingredientId", ingredientId);
                SqlParameter[] parameters = { ingredientIdParam };
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