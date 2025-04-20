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

namespace CoffeeShopApplication.Test
{
    public partial class checkConnection : Form
    {
        public checkConnection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check connection
            if(DBConnect.getInstance().TestConnection())
            {
                MessageBox.Show("Connection successful!");
            }
            else
            {
                MessageBox.Show("Connection failed!");
            }
        }
    }
}
