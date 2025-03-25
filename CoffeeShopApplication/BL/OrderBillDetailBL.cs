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
    public class OrderBillDetailBL
    {
        public static DataSet getAllOrderBill(string billId)
        {
            string str = string.Format($"Select * from OrderBillDetails Where billId = '{billId}'");
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, null);
            return ds;
        }

        public static bool addOrderBillDetails(string billId, string productId, string quantity)
        {
            if (billId == "" || productId == "" || quantity == "")
                return false;

            try
            {
                string str = "AddOrderBillDetailsProc";
                SqlParameter BillIdParam = new SqlParameter("@BillId", billId);
                SqlParameter ProcductIdParam = new SqlParameter("@ProductId", productId);
                SqlParameter QuantityParam = new SqlParameter("@Quantity", quantity);
                SqlParameter[] parameters = { BillIdParam, ProcductIdParam, QuantityParam };
                bool commandResult = DBConnection.getInstance().ExecuteNonQuery(str, CommandType.StoredProcedure, parameters);
                return commandResult;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool updateOrderBillDetails(string billId, string productId, string quantity, string updateType)
        {
            if (billId == "" || productId == "" || quantity == "" || updateType == "")
                return false;

            try
            {
                string str = "UpdateOrderBillDetialsProc";
                SqlParameter BillIdParam = new SqlParameter("@BillId", billId);
                SqlParameter ProcductIdParam = new SqlParameter("@ProductId", productId);
                SqlParameter QuantityParam = new SqlParameter("@Quantity", quantity);
                SqlParameter UpdateTypeParam = new SqlParameter("@UpdateType ", updateType);
                SqlParameter[] parameters = { BillIdParam, ProcductIdParam, QuantityParam, UpdateTypeParam };
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