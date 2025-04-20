using CoffeeShopApplication.BL;
using CoffeeShopApplication.Interfaces;
using CoffeeShopApplication.Test;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopApplication
{
    static class Program
    {
        static Form mainForm = new LogInForm();
        //static Form mainForm = new checkConnection();

        static public String loggedInEmployeeId;
        static public String loggedInUserRole;

        public static Form MainForm { get => mainForm; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(mainForm);
            //Application.SetCompatibleTextRenderingDefault(false);
            //Console.WriteLine("==== TESTING CustomerBL ====");

            //// 1. Thêm khách hàng mới
            //Console.WriteLine("Thêm khách hàng...");
            //bool addResult = CustomerBL.addCustomer("Nguyễn Văn A", "0987654321");
            //Console.WriteLine("Thêm thành công: " + addResult);

            //// 2. Lấy danh sách khách hàng
            //Console.WriteLine("\nLấy danh sách khách hàng...");
            //DataSet ds = CustomerBL.getAllCustomers();

            //// 3. Tìm khách hàng theo số điện thoại
            //Console.WriteLine("\nTìm khách hàng theo số điện thoại...");
            //DataSet searchPhoneResult = CustomerBL.findCustomerByPhoneNumber("0987654321");

        }
    }
}
