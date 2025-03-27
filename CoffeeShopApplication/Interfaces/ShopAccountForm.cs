using CoffeeShopApplication.BL;
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
    public partial class ShopAccountForm : Form
    {
        private Point[] componentLocations;
        public ShopAccountForm()
        {
            InitializeComponent();
            componentLocations = new Point[5];
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            String accountId, userName, employeeId, role, password, isDeleted;
            accountId = tbAccountId.Text;
            userName = tbUserName.Text;
            employeeId = tbEmployeeId.Text;
            password = tbPassword.Text;
            role = cbRole.Text;
            isDeleted = cbDeleted.Text;
            if (isDeleted == "yes")
            {
                if (AccountBL.updateAccount(employeeId, accountId, password, userName, role, "1"))
                {
                    MessageBox.Show("Updated a row successfully!", "Action result");
                    DataSet accountDataSet = AccountBL.getAllAccount();
                    dgvAccount.DataSource = accountDataSet.Tables[0].DefaultView;
                }
                else
                    MessageBox.Show("Failed to update a row! Check your input data!", "Action result");
            }
            else
            {
                if (AccountBL.updateAccount(employeeId, accountId, password, userName, role, "0"))
                {
                    MessageBox.Show("Updated a row successfully!", "Action result");
                    DataSet accountDataSet = AccountBL.getAllAccount();
                    dgvAccount.DataSource = accountDataSet.Tables[0].DefaultView;
                }
                else
                    MessageBox.Show("Failed to update a row! Check your input data!", "Action result");
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            DataSet accountDataSet = AccountBL.getAllAccount();
            try
            {
                dgvAccount.DataSource = accountDataSet.Tables[0].DefaultView;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "ERROR"); }
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvAccount.Rows[e.RowIndex];
                tbEmployeeId.Text = row.Cells[1].Value.ToString();
                tbAccountId.Text = row.Cells[0].Value.ToString();
                tbUserName.Text = row.Cells[2].Value.ToString();
                tbPassword.Text = row.Cells[3].Value.ToString();
                cbRole.SelectedIndex = cbRole.FindStringExact(row.Cells[4].Value.ToString());

                switch (row.Cells[7].Value)
                {
                    case true:
                        cbDeleted.SelectedIndex = 0;
                        break;
                    case false:
                        cbDeleted.SelectedIndex = 1;
                        break;
                    default:
                        break;
                }
            }
        }

        private void ShopAccountForm_Load(object sender, EventArgs e)
        {
            DataSet accountDataSet = AccountBL.getAllAccount();
            try
            {
                dgvAccount.DataSource = accountDataSet.Tables[0].DefaultView;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "ERROR"); }
            componentLocations[0] = pbSearch.Location;
            componentLocations[2] = pbSave.Location;
            componentLocations[3] = pbDelete.Location;
            componentLocations[4] = pbRefresh.Location;
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 0)
            {
                DataSet accountDataSet = AccountBL.findAccountByUserName(tbSearch.Text);
                dgvAccount.DataSource = accountDataSet.Tables[0].DefaultView;
            }
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            String userName, employeeId, role, password;
            userName = tbUserName.Text;
            employeeId = tbEmployeeId.Text;
            password = tbPassword.Text;
            role = cbRole.Text;
            if (AccountBL.addAccount(employeeId, password, userName, role))
            {
                MessageBox.Show("Added a row successfully!", "Action result");
                DataSet accountDataSet = AccountBL.getAllAccount();
                dgvAccount.DataSource = accountDataSet.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("Failed to add a row! Check your input data!", "Action result");
        }
    }
}
