using CoffeeShopApplication.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopApplication.Interfaces
{
    public partial class HomeForm: Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }

        private void pbAccounts_Click(object sender, EventArgs e)
        {
            //Form newForm = new ShopAccountForm();
            //newForm.Show();
            MessageBox.Show("This feature is not available yet", "Feature not available");
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DBConnection.resetConnection();
            Program.MainForm.Show();
            this.Close();
        }
    }
}
