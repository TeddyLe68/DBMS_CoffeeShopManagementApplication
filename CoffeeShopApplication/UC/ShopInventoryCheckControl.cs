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
using CoffeeShopApplication.Interfaces;

namespace CoffeeShopApplication.UC
{
    public partial class ShopInventoryCheckControl: UserControl
    {
        public DataSet inventoryDataSet;
        public DataSet employeeDataSet;
        private Point[] componentLocations;
        public ShopInventoryCheckDetailsForm inventoryCheckDetailsForm;
        public ShopInventoryCheckControl()
        {
            InitializeComponent();
            componentLocations = new Point[5];
        }

        private void ShopInventoryCheckControl_Load(object sender, EventArgs e)
        {
            dtpCheckDate.Value = DateTime.Parse(dtpCheckDate.Value.ToString());
            DataSet inventoryCheckDataSet = InventoryCheckBL.getAllInventoryCheckFromView();
            if (inventoryCheckDataSet.Tables.Count > 0)
            {
                dgvInventoryCheck.DataSource = inventoryCheckDataSet.Tables[0].DefaultView;
            }
            inventoryDataSet = InventoryBL.getAllInventory();
            cbInventory.DataSource = inventoryDataSet.Tables[0];
            cbInventory.DisplayMember = "name";
            cbInventory.ValueMember = "inventoryId";
            employeeDataSet = EmployeeBL.getAllEmployee();
            cbEmployee.DataSource = employeeDataSet.Tables[0];
            cbEmployee.DisplayMember = "fullName";
            cbEmployee.ValueMember = "employeeId";
            componentLocations[0] = pbSearch.Location;
            componentLocations[1] = pbAdd.Location;
            componentLocations[2] = pbSave.Location;
            componentLocations[3] = pbDelete.Location;
            componentLocations[4] = pbRefresh.Location;
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            DataSet inventoryCheckDataSet = InventoryCheckBL.findInventoryCheckByDateFromView(dtpSearch.Value.ToString("MM/dd/yyyy"));
            dgvInventoryCheck.DataSource = inventoryCheckDataSet.Tables[0].DefaultView;
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            String checkDate, inventoryId, inventoryName, employeeId, employeeName;
            if (cbInventory.SelectedValue == null || cbEmployee.SelectedIndex == null)
            {
                MessageBox.Show("Please input all the fields first!");
                return;
            }
            checkDate = dtpCheckDate.Value.ToString("MM/dd/yyyy");
            inventoryId = cbInventory.SelectedValue.ToString();
            employeeId = cbEmployee.SelectedValue.ToString();
            if (InventoryCheckBL.addInventoryCheck(employeeId, inventoryId, checkDate))
            {
                MessageBox.Show("Added a new row successfully!", "Action result");
                DataSet inventoryCheckDataSet = InventoryCheckBL.getAllInventoryCheckFromView();
                dgvInventoryCheck.DataSource = inventoryCheckDataSet.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("Failed to add a row! Check your input data!", "Action result");
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            String checkId, checkDate, inventoryId, inventoryName, employeeId, employeeName;
            if (cbInventory.SelectedValue == null || cbEmployee.SelectedIndex == null)
            {
                MessageBox.Show("Please input all the fields first!");
                return;
            }
            checkId = tbCheckId.Text;
            checkDate = dtpCheckDate.Value.ToString("MM/dd/yyyy");
            inventoryId = cbInventory.SelectedValue.ToString();
            employeeId = cbEmployee.SelectedValue.ToString();
            if (InventoryCheckBL.updateInventoryCheck(checkId, employeeId, inventoryId, checkDate))
            {
                MessageBox.Show("Updated a new row successfully!", "Action result");
                DataSet inventoryCheckDataSet = InventoryCheckBL.getAllInventoryCheckFromView();
                dgvInventoryCheck.DataSource = inventoryCheckDataSet.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("Failed to update a row! Check your input data!", "Action result");
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            String checkId;
            checkId = tbCheckId.Text;
            if (MessageBox.Show("Are you sure you want to delete inventory check " + tbCheckId.Text + " (id: " + checkId + ")?", "Delete Confirmation",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
           MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                if (InventoryCheckBL.deleteInventoryCheck(checkId))
                {
                    MessageBox.Show("Deleted a row successfully!", "Action result");
                    DataSet inventoryCheckDataSet = InventoryCheckBL.getAllInventoryCheckFromView();
                    dgvInventoryCheck.DataSource = inventoryCheckDataSet.Tables[0].DefaultView;
                }
                else
                    MessageBox.Show("Failed to delete a row! Check your input data!", "Action result");
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            DataSet inventoryCheckDataSet = InventoryCheckBL.getAllInventoryCheckFromView();
            if (inventoryCheckDataSet.Tables.Count > 0)
            {
                dgvInventoryCheck.DataSource = inventoryCheckDataSet.Tables[0].DefaultView;
            }
        }

        

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (tbCheckId.Text.Length > 0)
            {
                inventoryCheckDetailsForm = new ShopInventoryCheckDetailsForm(tbCheckId.Text);
                inventoryCheckDetailsForm.Show();
            }
        }

        private void dgvInventoryCheck_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvInventoryCheck.Rows[e.RowIndex];
                tbCheckId.Text = row.Cells["checkIdDataGridViewTextBoxColumn"].Value.ToString();
                dtpCheckDate.Value = DateTime.Parse(row.Cells["checkDateDataGridViewTextBoxColumn"].Value.ToString());
                cbInventory.SelectedValue = row.Cells["inventoryNameDataGridViewTextBoxColumn"].Value.ToString();
                cbEmployee.SelectedValue = row.Cells["employeeNameDataGridViewTextBoxColumn"].Value.ToString();
            }
        }
    }
}
