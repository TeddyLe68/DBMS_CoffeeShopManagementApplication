using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopApplication.BL;

namespace CoffeeShopApplication.Interfaces
{
    public partial class ShopOrderBillDetailForm : Form
    {
        private Point[] componentLocations;

        public ShopOrderBillDetailForm(string billId)
        {
            InitializeComponent();
            componentLocations = new Point[5];
            tbBillId.Text = billId;
        }

        private void ShopOrderBillDetailForm_Load(object sender, EventArgs e)
        {
            //load data to dgvProduct
            DataSet listProductDataSet = ProductBL.getListProducts();
            dgvProduct.DataSource = listProductDataSet.Tables[0].DefaultView;
            DataSet orderBillDetailDataSet = OrderBillDetailBL.getAllOrderBill(tbBillId.Text);
            dgvOrderBillDetail.DataSource = orderBillDetailDataSet.Tables[0].DefaultView;
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
                DataSet ProductDataSet = ProductBL.findProductsViewByName(tbSearch.Text);
                dgvProduct.DataSource = ProductDataSet.Tables[0].DefaultView;
            }
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            String billId, productId, quantity;
            billId = tbBillId.Text;
            productId = tbProductId.Text;
            quantity = tbQuantity.Text;
            if (OrderBillDetailBL.addOrderBillDetails(billId, productId, quantity))
            {
                MessageBox.Show("Added a new row successfully!", "Action result");
                DataSet orderBillDetailDataSet = OrderBillDetailBL.getAllOrderBill(tbBillId.Text);
                dgvOrderBillDetail.DataSource = orderBillDetailDataSet.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("Failed to add a row! Check your input data!", "Action result");
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            String billId, productId, quantity;
            billId = tbBillId.Text;
            productId = tbProductId.Text;
            quantity = tbQuantity.Text;
            if (OrderBillDetailBL.updateOrderBillDetails(billId, productId, quantity, "update"))
            {
                MessageBox.Show("Added a new row successfully!", "Action result");
                DataSet orderBillDetailDataSet = OrderBillDetailBL.getAllOrderBill(tbBillId.Text);
                dgvOrderBillDetail.DataSource = orderBillDetailDataSet.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("Failed to add a row! Check your input data!", "Action result");
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            String billId, productId, quantity;
            billId = tbBillId.Text;
            productId = tbProductId.Text;
            quantity = tbQuantity.Text;
            if (OrderBillDetailBL.updateOrderBillDetails(billId, productId, quantity, "delete"))
            {
                MessageBox.Show("Added a new row successfully!", "Action result");
                DataSet orderBillDetailDataSet = OrderBillDetailBL.getAllOrderBill(tbBillId.Text);
                dgvOrderBillDetail.DataSource = orderBillDetailDataSet.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("Failed to add a row! Check your input data!", "Action result");
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvProduct.Rows[e.RowIndex];
                tbProductId.Text = row.Cells[1].Value.ToString();
            }
        }

        private void pbRefreshProduct_Click(object sender, EventArgs e)
        {
            // clear all textboxes
            tbSearch.Text = "";
            DataSet listProductDataSet = ProductBL.getListProducts();
            dgvProduct.DataSource = listProductDataSet.Tables[0].DefaultView;
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            // clear all textboxes
            tbSearch.Text = "";
            tbProductId.Text = "";
            tbQuantity.Text = "";
            DataSet orderBillDetailDataSet = OrderBillDetailBL.getAllOrderBill(tbBillId.Text);
            dgvOrderBillDetail.DataSource = orderBillDetailDataSet.Tables[0].DefaultView;
        }

        private void dgvOrderBillDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvOrderBillDetail.Rows[e.RowIndex];
                tbProductId.Text = row.Cells[1].Value.ToString();
                tbQuantity.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}
