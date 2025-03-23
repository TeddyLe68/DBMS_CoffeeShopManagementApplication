using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopApplication.BL;

namespace CoffeeShopApplication.UC
{
    public partial class ShopCustomersControl: UserControl
    {
        private Point[] componentLocation1;
        private Size pbSize1;
        public ShopCustomersControl()
        {
            InitializeComponent();
            componentLocation1 = new Point[5];
        }

        private void ShopCustomersControl_Load(object sender, EventArgs e)
        {
            //this.ControlBox = false;
            DataSet customerDataSet = CustomerBL.getAllCustomers();
            dgvCustomers.DataSource = customerDataSet.Tables[0].DefaultView;
            componentLocation1[0] = pbSearch.Location;
            componentLocation1[1] = pbAdd.Location;
            componentLocation1[2] = pbSave.Location;
            componentLocation1[3] = pbDelete.Location;
            componentLocation1[4] = pbRefresh.Location;
            pbSize1 = pbSearch.Size;
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 0)
            {
                DataSet customerDataSet = CustomerBL.findCustomerByPhoneNumber(tbSearch.Text);
                if (customerDataSet.Tables.Count > 0)
                {
                    dgvCustomers.DataSource = customerDataSet.Tables[0].DefaultView;
                }
                else
                {
                    MessageBox.Show("No customers found.");
                }
            }
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            String customerName, phoneNumber;
            customerName = tbName.Text;
            phoneNumber = tbPhoneNumber.Text;
            if (CustomerBL.addCustomer(customerName, phoneNumber))
            {
                MessageBox.Show("Added a new row successfully!", "Action result");
                DataSet productDataSet = CustomerBL.getAllCustomers();
                dgvCustomers.DataSource = productDataSet.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("Failed to add a row! Check your input data!", "Action result");
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            String customerId, customerName, phoneNumber, isDeleted;
            customerId = tbId.Text;
            customerName = tbName.Text;
            phoneNumber = tbPhoneNumber.Text;
            isDeleted = cbDeleted.Text;
            if (CustomerBL.updateCustomer(customerId, customerName, phoneNumber, isDeleted == "Yes"))
            {
                MessageBox.Show("Updated a row successfully!", "Action result");
                DataSet productDataSet = CustomerBL.getAllCustomers();
                dgvCustomers.DataSource = productDataSet.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("Failed to update a row! Check your input data!", "Action result");
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            // clear all textboxes
            tbSearch.Text = "";
            tbId.Text = "";
            tbName.Text = "";
            tbPhoneNumber.Text = "";

            DataSet customerDataSet = CustomerBL.getAllCustomers();
            dgvCustomers.DataSource = customerDataSet.Tables[0].DefaultView;
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            String customerId;
            customerId = tbId.Text;

            if (MessageBox.Show("Are you sure you want to delete customer " + tbName.Text + " (id: " + customerId + ")?", "Delete Confirmation",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                if (CustomerBL.deleteCustomer(customerId))
                {
                    MessageBox.Show("Deleted a row successfully!", "Action result");
                    DataSet productDataSet = CustomerBL.getAllCustomers();
                    dgvCustomers.DataSource = productDataSet.Tables[0].DefaultView;
                }
                else
                    MessageBox.Show("Failed to delete a row! Check your input data!", "Action result");
            }
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvCustomers.Rows[e.RowIndex];
                tbId.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                tbPhoneNumber.Text = row.Cells[2].Value.ToString();
                tbId.ReadOnly = true;

                switch (row.Cells[4].Value)
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
    }
}
