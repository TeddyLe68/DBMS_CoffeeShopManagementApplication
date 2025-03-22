using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopApplication.Interfaces;

namespace CoffeeShopApplication.UC
{
    public partial class Navigator: UserControl
    {
        private String topLevelForm;
        public Navigator()
        {
            InitializeComponent();

        }
        private void Navigator_Load(object sender, EventArgs e)
        {
          
        }
       
        private void LoadSection(UserControl newControl, string title)
        {
            if (this.TopLevelControl is MainForm mainForm)
            {
                mainForm.LoadUserControl(newControl);
                mainForm.UpdateWindowTitle(title);
            }
        }
        private void pbAppIcon_Click(object sender, EventArgs e) => LoadSection(new HomeControl(), "Home");
        private void pbCustomer_Click(object sender, EventArgs e) => LoadSection(new ShopCustomersControl(), "Shop Customers");
        private void pbIngredient_Click(object sender, EventArgs e) => LoadSection(new ShopIngredientsControl(), "Shop Ingredients");
        private void pbProduct_Click(object sender, EventArgs e) => LoadSection(new ShopProductsControl(), "Shop Products");
        private void pbEmployee_Click(object sender, EventArgs e) => LoadSection(new ShopEmployeesControl(), "Shop Employees");
        private void pbOrder_Click(object sender, EventArgs e) => LoadSection(new ShopOrderBillControl(), "Shop Order Bills");
        private void pbRestockOrder_Click(object sender, EventArgs e) => LoadSection(new ShopRestockBillsControl(), "Shop Restock Bills");
        private void pbInventoryCheck_Click(object sender, EventArgs e) => LoadSection(new ShopInventoryCheckControl(), "Shop Inventory Check");
        private void pbInventory_Click(object sender, EventArgs e) => LoadSection(new ShopInventoryControl(), "Shop Inventory");

        private void pbAppIcon_MouseHover(object sender, EventArgs e)
        {
            
                pbAppIcon.BackColor = Color.White;
                pbAppIcon.BorderStyle = BorderStyle.FixedSingle;
            
        }

        private void pbAppIcon_MouseLeave(object sender, EventArgs e)
        {
            
                pbAppIcon.BackColor = Color.Transparent;
                pbAppIcon.BorderStyle = BorderStyle.None;
            
        }

        private void pbCustomer_MouseHover(object sender, EventArgs e)
        {
            
                pbCustomer.BackColor = Color.White;
                pbCustomer.BorderStyle = BorderStyle.FixedSingle;
            
        }

        private void pbCustomer_MouseLeave(object sender, EventArgs e)
        {
           
                pbCustomer.BackColor = Color.Transparent;
                pbCustomer.BorderStyle = BorderStyle.None;
            
        }

        private void pbInventoryCheck_MouseHover(object sender, EventArgs e)
        {
            
                pbInventoryCheck.BackColor = Color.White;
                pbInventoryCheck.BorderStyle = BorderStyle.FixedSingle;
            
        }

        private void pbInventoryCheck_MouseLeave(object sender, EventArgs e)
        {
            
                pbInventoryCheck.BackColor = Color.Transparent;
                pbInventoryCheck.BorderStyle = BorderStyle.None;
            
        }

        private void pbIngredient_MouseHover(object sender, EventArgs e)
        {
            
                pbIngredient.BackColor = Color.White;
                pbIngredient.BorderStyle = BorderStyle.FixedSingle;
            
        }

        private void pbIngredient_MouseLeave(object sender, EventArgs e)
        {
           
                pbIngredient.BackColor = Color.Transparent;
                pbIngredient.BorderStyle = BorderStyle.None;
            
        }

        private void pbProduct_MouseHover(object sender, EventArgs e)
        {
            
                pbProduct.BackColor = Color.White;
                pbProduct.BorderStyle = BorderStyle.FixedSingle;
            
        }

        private void pbProduct_MouseLeave(object sender, EventArgs e)
        {
            
                pbProduct.BackColor = Color.Transparent;
                pbProduct.BorderStyle = BorderStyle.None;
            
        }

        private void pbEmployee_MouseHover(object sender, EventArgs e)
        {
            
                pbEmployee.BackColor = Color.White;
                pbEmployee.BorderStyle = BorderStyle.FixedSingle;

            
        }

        private void pbEmployee_MouseLeave(object sender, EventArgs e)
        {
            
                pbEmployee.BackColor = Color.Transparent;
                pbEmployee.BorderStyle = BorderStyle.None;
            
        }

        private void pbOrder_MouseHover(object sender, EventArgs e)
        {
            
                pbOrder.BackColor = Color.White;
                pbOrder.BorderStyle = BorderStyle.FixedSingle;
            
        }

        private void pbOrder_MouseLeave(object sender, EventArgs e)
        {
            
                pbOrder.BackColor = Color.Transparent;
                pbOrder.BorderStyle = BorderStyle.None;
            
        }

        private void pbRestockOrder_MouseHover(object sender, EventArgs e)
        {
            
                pbRestockOrder.BackColor = Color.White;
                pbRestockOrder.BorderStyle = BorderStyle.FixedSingle;
            
        }

        private void pbRestockOrder_MouseLeave(object sender, EventArgs e)
        {
            
                pbRestockOrder.BackColor = Color.Transparent;
                pbRestockOrder.BorderStyle = BorderStyle.None;
            
        }

        private void pbInventory_MouseHover(object sender, EventArgs e)
        {
            
                pbInventory.BackColor = Color.White;
                pbInventory.BorderStyle = BorderStyle.FixedSingle;
            
        }

        private void pbInventory_MouseLeave(object sender, EventArgs e)
        {
           
                pbInventory.BackColor = Color.Transparent;
                pbInventory.BorderStyle = BorderStyle.None;
            
        }
    }
}
