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
    public partial class ShopIngredientsControl: UserControl
    {
        private Point[] componentLocations;
        private Size pbSize;
        public ShopIngredientsControl()
        {
            InitializeComponent();
            componentLocations = new Point[5];
        }

        private void ShopIngredientsControl_Load(object sender, EventArgs e)
        {
            DataSet ingredientDataSet = IngredientBL.getAllIngredients();
            dgvIngredients.DataSource = ingredientDataSet.Tables[0].DefaultView;
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
                DataSet ingredientDataSet = IngredientBL.findIngredientsByName(tbSearch.Text);
                dgvIngredients.DataSource = ingredientDataSet.Tables[0].DefaultView;
            }
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            String ingredientName, manufacturername;
            ingredientName = tbName.Text;
            manufacturername = tbManufacturerName.Text;
            if (IngredientBL.addIngredient(ingredientName, manufacturername))
            {
                MessageBox.Show("Added a new row successfully!", "Action result");
                DataSet productDataSet = IngredientBL.getAllIngredients();
                dgvIngredients.DataSource = productDataSet.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("Failed to add a row! Check your input data!", "Action result");

            // clear all textboxes
            tbSearch.Text = "";
            tbId.Text = "";
            tbName.Text = "";
            tbManufacturerName.Text = "";

        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            String ingredientId, ingredientName, manufacturername, isDeleted;
            ingredientId = tbId.Text;
            ingredientName = tbName.Text;
            manufacturername = tbManufacturerName.Text;
            isDeleted = cbDeleted.Text;
            if (IngredientBL.updateIngredient(ingredientId, ingredientName, manufacturername, isDeleted == "Yes"))
            {
                MessageBox.Show("Updated a row successfully!", "Action result");
                DataSet productDataSet = IngredientBL.getAllIngredients();
                dgvIngredients.DataSource = productDataSet.Tables[0].DefaultView;
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
            tbManufacturerName.Text = "";

            DataSet ingredientDataSet = IngredientBL.getAllIngredients();
            dgvIngredients.DataSource = ingredientDataSet.Tables[0].DefaultView;
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            String ingredientId;
            ingredientId = tbId.Text;

            if (MessageBox.Show("Are you sure you want to delete ingredient " + tbName.Text + " (id: " + ingredientId + ")?", "Delete Confirmation",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                if (IngredientBL.deleteIngredient(ingredientId))
                {
                    MessageBox.Show("Deleted a row successfully!", "Action result");
                    DataSet productDataSet = IngredientBL.getAllIngredients();
                    dgvIngredients.DataSource = productDataSet.Tables[0].DefaultView;
                }
                else
                    MessageBox.Show("Failed to delete a row! Check your input data!", "Action result");
            }
        }

        private void dgvIngredients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvIngredients.Rows[e.RowIndex];
                tbId.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                tbManufacturerName.Text = row.Cells[2].Value.ToString();

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
