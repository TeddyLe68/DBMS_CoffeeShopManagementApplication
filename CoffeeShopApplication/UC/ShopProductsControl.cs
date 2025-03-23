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
    public partial class ShopProductsControl: UserControl
    {
        private Point[] componentLocations;
        private Size pbSize;
        public ShopProductsControl()
        {
            InitializeComponent();
            componentLocations = new Point[5];
        }

        private void ShopProductsControl_Load(object sender, EventArgs e)
        {
            DataSet productDataSet = ProductBL.getAllProducts();
            dgvProducts.DataSource = productDataSet.Tables[0].DefaultView;
            componentLocations[0] = pbSearch.Location;
            componentLocations[1] = pbAdd.Location;
            componentLocations[2] = pbSave.Location;
            componentLocations[3] = pbDelete.Location;
            componentLocations[4] = pbRefresh.Location;
            pbSize = pbSearch.Size;
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 0)
            {
                DataSet productDataSet = ProductBL.findProductsByName(tbSearch.Text);
                dgvProducts.DataSource = productDataSet.Tables[0].DefaultView;
            }
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            String productName, productSize, productPrice;
            productName = tbName.Text;
            productSize = cbSize.Text;
            productPrice = tbPrice.Text;
            if (ProductBL.addProduct(productName, productSize, productPrice))
            {
                MessageBox.Show("Added a new row successfully!", "Action result");
                DataSet productDataSet = ProductBL.getAllProducts();
                dgvProducts.DataSource = productDataSet.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("Failed to add a row! Check your input data!", "Action result");
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            String productId, productName, productSize, productPrice, isDeleted;
            productId = tbId.Text;
            productName = tbName.Text;
            productSize = cbSize.Text;
            productPrice = tbPrice.Text;
            isDeleted = cbDeleted.Text;
            if (ProductBL.updateProduct(productId, productName, productSize, productPrice, isDeleted == "Yes"))
            {
                MessageBox.Show("Updated a row successfully!", "Action result");
                DataSet productDataSet = ProductBL.getAllProducts();
                dgvProducts.DataSource = productDataSet.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("Failed to update a row! Check your input data!", "Action result");
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            String productId;
            productId = tbId.Text;

            if (MessageBox.Show("Are you sure you want to delete product " + tbName.Text + " (id: " + productId + ")?", "Delete Confirmation",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                if (ProductBL.deleteProduct(productId))
                {
                    MessageBox.Show("Deleted a row successfully!", "Action result");
                    DataSet productDataSet = ProductBL.getAllProducts();
                    dgvProducts.DataSource = productDataSet.Tables[0].DefaultView;
                }
                else
                    MessageBox.Show("Failed to delete a row! Check your input data!", "Action result");
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            // Reset all textboxes
            tbSearch.Text = "";
            tbId.Text = "";
            tbName.Text = "";
            tbPrice.Text = "";
            // Reset all comboboxes
            cbSize.SelectedIndex = -1;
            cbDeleted.SelectedIndex = -1;
            DataSet productDataSet = ProductBL.getAllProducts();
            dgvProducts.DataSource = productDataSet.Tables[0].DefaultView;
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvProducts.Rows[e.RowIndex];
                tbId.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                tbPrice.Text = row.Cells[3].Value.ToString();
                switch (row.Cells[2].Value.ToString())
                {
                    case "Lớn":
                        cbSize.SelectedIndex = 0;
                        break;
                    case "Vừa":
                        cbSize.SelectedIndex = 1;
                        break;
                    case "Nhỏ":
                        cbSize.SelectedIndex = 2;
                        break;
                    default:
                        break;
                }

                if (row.Cells.Count > 6)
                {
                    switch (row.Cells[6].Value)
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
}
