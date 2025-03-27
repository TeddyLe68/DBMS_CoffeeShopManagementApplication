using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopApplication.DB;
using CoffeeShopApplication.Interfaces;

namespace CoffeeShopApplication.UC
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();
            string userRole = Program.loggedInUserRole; // Access the role

            if (userRole == "Manager")
            {
                pbManageAccount.Visible = true;
                pbManageAccount.Enabled = true;
                pbManageAccount.Cursor = Cursors.Hand;
                lbHello.Text = "Hello Manager !!!";
            }
            else if (userRole == "Employee")
            {
                pbManageAccount.Enabled = false;
                lbHello.Text = "Hello Employee !!!";
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DBConnection.resetConnection();
            Program.MainForm.Show();
            this.ParentForm.Close();
        }

        private void pbManageAccount_Click(object sender, EventArgs e)
        {
            Form newForm = new ShopAccountForm();
            newForm.Show();
        }
    }
}
