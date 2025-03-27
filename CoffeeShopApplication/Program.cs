using CoffeeShopApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopApplication
{
    static class Program
    {
        static Form mainForm = new LogInForm();
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
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainForm);
        }
    }
}
