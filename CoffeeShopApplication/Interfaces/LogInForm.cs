using CoffeeShopApplication.BL;
using CoffeeShopApplication.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopApplication.Interfaces
{
    public partial class LogInForm: Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            tbUserName.Clear();
            tbPassword.Clear();
            tbUserName.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String accountId = AccountBL.getAccount(tbUserName.Text, tbPassword.Text);
            if (accountId != "")
            {
                Program.loggedInEmployeeId = accountId;
                DBConnection.Username = tbUserName.Text;
                DBConnection.Password = tbPassword.Text;
                MainForm homeForm = new MainForm();
                homeForm.Show();
                tbUserName.Clear();
                tbPassword.Clear();
                tbUserName.Focus();
                this.Hide();
            }
            else
                MessageBox.Show("Username or password is incorrect!", "Log In Error");
        }

        private void cb_Show_Password_CheckedChanged(object sender, EventArgs e)
        {
            // show password
            if (cb_Show_Password.Checked)
                tbPassword.PasswordChar = '\0';
            else
                tbPassword.PasswordChar = '*';

        }
    }
}
