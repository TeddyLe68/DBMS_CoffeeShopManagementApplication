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
    public class ProductBL
    {
        public static DataSet getAllProducts()
        {
            String str = "Select * from Product";
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, null);
            return ds;
        }

        public static DataSet getListProducts()
        {
            String str = "Select * from ListProcductView";
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, null);
            return ds;
        }

        public static DataSet findProductsByName(String productName)
        {
            String str = "SELECT * FROM dbo.FindProductByNameFunction(@productName)";
            SqlParameter productNameParam = new SqlParameter("@productName", productName);
            SqlParameter[] parameters = { productNameParam };
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, parameters);
            return ds;
        }

        public static DataSet findProductsViewByName(String productName)
        {
            String str = "SELECT * FROM dbo.FindProductViewByNameFunction(@productName)";
            SqlParameter productNameParam = new SqlParameter("@productName", productName);
            SqlParameter[] parameters = { productNameParam };
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, parameters);
            return ds;
        }

        public static bool updateProduct(String productId, String productName, String productSize, String productPrice, bool isDeleted)
        {
            if (productId == "" || productName == "" || productSize == "" || productPrice == "")
                return false;

            try
            {
                float.Parse(productPrice);
                String str = "UpdateProductProc";
                SqlParameter productIdParam = new SqlParameter("@productId", productId);
                SqlParameter productNameParam = new SqlParameter("@productName", productName);
                SqlParameter productSizeParam = new SqlParameter("@productSize", productSize);
                SqlParameter productPriceParam = new SqlParameter("@productPrice", productPrice);
                SqlParameter isDeletedParam = new SqlParameter("@isDeleted", isDeleted.ToString());
                SqlParameter[] parameters = { productIdParam, productNameParam, productSizeParam, productPriceParam, isDeletedParam };
                bool commandResult = DBConnection.getInstance().ExecuteNonQuery(str, CommandType.StoredProcedure, parameters);
                return commandResult;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public static bool addProduct(String productName, string productSize, String productPrice)
        {
            if (productName == "" || productSize == "" || productPrice == "")
                return false;

            try
            {
                float.Parse(productPrice);
                String str = "InsertProductProc";
                SqlParameter productNameParam = new SqlParameter("@productName", productName);
                SqlParameter productSizeParam = new SqlParameter("@productSize", productSize);
                SqlParameter productPriceParam = new SqlParameter("@productPrice", productPrice);
                SqlParameter[] parameters = { productNameParam, productSizeParam, productPriceParam };
                bool commandResult = DBConnection.getInstance().ExecuteNonQuery(str, CommandType.StoredProcedure, parameters);
                return commandResult;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool deleteProduct(String productId)
        {
            if (productId == "")
                return false;
            try
            {
                String str = "DeleteProductProc";
                SqlParameter productIdParam = new SqlParameter("@productId", productId);
                SqlParameter[] parameters = { productIdParam };
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