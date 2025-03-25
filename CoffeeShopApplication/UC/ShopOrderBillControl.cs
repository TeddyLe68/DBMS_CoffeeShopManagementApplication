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
using System.Text.RegularExpressions;
using CoffeeShopApplication.Interfaces;

namespace CoffeeShopApplication.UC
{
    public partial class ShopOrderBillControl: UserControl
    {
        private Point[] componentLocations;
        public ShopOrderBillControl()
        {
            InitializeComponent();
            componentLocations = new Point[5];
        }

        private void ShopOrderBillControl_Load(object sender, EventArgs e)
        {
            // Load data order bill
            tbEmployeeId.Text = Program.loggedInEmployeeId;
            DataSet orderBillDataSet = OrderBillBL.getAllOrderBill();
            dgvOrderBill.DataSource = orderBillDataSet.Tables[0].DefaultView;
            // Load data customer
            DataSet customerDataSet = CustomerBL.getAllCustomers();
            dgvCustomer.DataSource = customerDataSet.Tables[0].DefaultView;

            componentLocations[0] = pbSearch.Location;
            componentLocations[1] = pbAdd.Location;
            componentLocations[2] = pbSave.Location;
            componentLocations[3] = pbDelete.Location;
            componentLocations[4] = pbRefresh.Location;
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 0)
            {
                DataSet customerDataSet;
                bool includesPhone = Regex.IsMatch(tbSearch.Text, "[0-9]{7,}");
                if (includesPhone)
                {
                    customerDataSet = CustomerBL.findCustomerByPhoneNumber(tbSearch.Text);
                }
                else
                {
                    customerDataSet = CustomerBL.findCustomerByName(tbSearch.Text);
                }
                dgvCustomer.DataSource = customerDataSet.Tables[0].DefaultView;
            }
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            String rewardPointUsed, customerId, employeeId, initialBill, finalBill;
            customerId = tbCustomerId.Text;
            employeeId = tbEmployeeId.Text;
            initialBill = tbInitialBill.Text;
            finalBill = tbFinalBill.Text;
            rewardPointUsed = tbRewardPointUsed.Text;
            if (OrderBillBL.addOrderBill(customerId, employeeId, rewardPointUsed, initialBill, finalBill))
            {
                MessageBox.Show("Added a new row successfully!", "Action result");
                DataSet orderBillDataSet = OrderBillBL.getAllOrderBill();
                dgvOrderBill.DataSource = orderBillDataSet.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("Failed to add a row! Check your input data!", "Action result");
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            String billId, rewardPointUsed, customerId, employeeId, initialBill, finalBill, isDeleted;
            billId = tbBillId.Text;
            customerId = tbCustomerId.Text;
            employeeId = tbEmployeeId.Text;
            initialBill = tbInitialBill.Text;
            finalBill = tbFinalBill.Text;
            rewardPointUsed = tbRewardPointUsed.Text;
            isDeleted = cbDeleted.Text;
            if (isDeleted != "yes")
            {
                if (OrderBillBL.updateOrderBill(customerId, employeeId, billId, rewardPointUsed, initialBill, finalBill, "update"))
                {
                    MessageBox.Show("Updated a row successfully!", "Action result");
                    DataSet orderBillDataSet = OrderBillBL.getAllOrderBill();
                    dgvOrderBill.DataSource = orderBillDataSet.Tables[0].DefaultView;
                }
                else
                    MessageBox.Show("Failed to update a row! Check your input data!", "Action result");
            }
            else
            {
                if (OrderBillBL.updateOrderBill(customerId, employeeId, billId, rewardPointUsed, initialBill, finalBill, "delete"))
                {
                    MessageBox.Show("Updated a row successfully!", "Action result");
                    DataSet orderBillDataSet = OrderBillBL.getAllOrderBill();
                    dgvOrderBill.DataSource = orderBillDataSet.Tables[0].DefaultView;
                }
                else
                    MessageBox.Show("Failed to update a row! Check your input data!", "Action result");
            }
        }

        private void pbRefreshOrderBill_Click(object sender, EventArgs e)
        {
            //clear all textboxes
            tbBillId.Text = "";
            tbRewardPointUsed.Text = "";
            tbInitialBill.Text = "";
            tbFinalBill.Text = "";
            tbCustomerId.Text = "";

            // Load data order bill
            DataSet orderBillDataSet = OrderBillBL.getAllOrderBill();
            dgvOrderBill.DataSource = orderBillDataSet.Tables[0].DefaultView;
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            //clear all textboxes
           tbSearch.Text = "";

            DataSet customerDataSet = CustomerBL.getAllCustomers();
            dgvCustomer.DataSource = customerDataSet.Tables[0].DefaultView;
        }

        private void dgvOrderBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < this.dgvOrderBill.Rows.Count)
            {
                DataGridViewRow row = this.dgvOrderBill.Rows[e.RowIndex];
                tbBillId.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
                tbRewardPointUsed.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                tbInitialBill.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                tbFinalBill.Text = row.Cells[3].Value?.ToString() ?? string.Empty;
                tbEmployeeId.Text = row.Cells[6].Value?.ToString() ?? string.Empty;
                tbCustomerId.Text = row.Cells[7].Value?.ToString() ?? string.Empty;
                switch (row.Cells[5].Value)
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

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvCustomer.Rows[e.RowIndex];
                tbCustomerId.Text = row.Cells[0].Value.ToString();

            }
        }

        private void dgvOrderBill_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvOrderBill_CellContentClick(sender, e);
            ShopOrderBillDetailForm newForm = new ShopOrderBillDetailForm(tbBillId.Text);
            newForm.Show();
        }
    }
}
