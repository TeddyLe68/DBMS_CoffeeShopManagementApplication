using CoffeeShopApplication.DB;
using CoffeeShopApplication.UC;
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
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadUserControl(new HomeControl());

        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadUserControl(UserControl userControl)
        {
            pnlMainContent.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(userControl);
        }
       
        public void UpdateWindowTitle(string newTitle)
        {
            this.Text = newTitle; // Đổi tiêu đề trên thanh tiêu đề của cửa sổ
        }
    }
}
