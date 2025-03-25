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
    public class OrderBillBL
    {
        public static DataSet getAllOrderBill()
        {
            string str = "Select * from OrderBill";
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, null);
            return ds;
        }

        //function
        public static DataSet findOrderBillById(string orderBillId)
        {
            string str = "SELECT * FROM dbo.findOrderBillByIdFunction(@orderBillId)";
            SqlParameter orderBillIdParam = new SqlParameter("@orderBillId", orderBillId);
            SqlParameter[] parameters = { orderBillIdParam };
            DataSet ds = DBConnection.getInstance().ExecuteQuery(str, CommandType.Text, parameters);
            return ds;
        }
        public static bool addOrderBill(string CustomerId, string EmployeeId, string RewardPointsUsed, string initialBill, string finalBill)
        {
            if (CustomerId == "" || EmployeeId == "" || RewardPointsUsed == "")
                return false;

            try
            {
                string str = "AddOrderBillProc";
                SqlParameter CustomerIdParam = new SqlParameter("@CustomerId", CustomerId);
                SqlParameter EmployeeIdParam = new SqlParameter("@EmployeeId", EmployeeId);
                SqlParameter RewardPointUserParam = new SqlParameter("@RewardPointsUsed", RewardPointsUsed);
                SqlParameter[] parameters = { CustomerIdParam, EmployeeIdParam, RewardPointUserParam };
                bool commandResult = DBConnection.getInstance().ExecuteNonQuery(str, CommandType.StoredProcedure, parameters);
                return commandResult;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool updateOrderBill(string CustomerId, string EmployeeId, string BillId, string RewardPointsUsed, string initialBill, string finalBill, string updateType)
        {
            if (CustomerId == null || EmployeeId == "" || BillId == "" || RewardPointsUsed == "" || initialBill == "" || finalBill == "")
                return false;

            try
            {
                string str = "UpdateOrderBillProc";
                SqlParameter CustomerIdParam = new SqlParameter("@CustomerId", CustomerId);
                SqlParameter EmployeeIdParam = new SqlParameter("@EmployeeId", EmployeeId);
                SqlParameter RewardPointUserParam = new SqlParameter("@RewardPointsUsed", RewardPointsUsed);
                SqlParameter BillIdParam = new SqlParameter("@BillId", BillId);
                SqlParameter IntialBillParam = new SqlParameter("@InitailBill", initialBill);
                SqlParameter FinalBillParam = new SqlParameter("@FinalBill", finalBill);
                SqlParameter UpdateTypeParam = new SqlParameter("@UpdateType", updateType);
                SqlParameter[] parameters = { CustomerIdParam, EmployeeIdParam,BillIdParam, RewardPointUserParam, UpdateTypeParam };
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