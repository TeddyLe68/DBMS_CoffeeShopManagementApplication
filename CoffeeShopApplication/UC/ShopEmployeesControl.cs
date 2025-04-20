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
    public partial class ShopEmployeesControl: UserControl
    {
        private Point[] componentLocations;
        public ShopEmployeesControl()
        {   
            InitializeComponent();
            componentLocations = new Point[5];
            string userRole = Program.loggedInUserRole; // Access the role  
            // If the user is not a manager, disable the add, save, delete buttons
            if (userRole != "Manager")
            {
                pbAdd.Enabled = false;
                pbSave.Enabled = false;
                pbDelete.Enabled = false;
            }else {
                pbAdd.Enabled = true;
                pbSave.Enabled = true;
                pbDelete.Enabled = true;
            }

            
        }

        private void ShopEmployeesControl_Load(object sender, EventArgs e)
        {
            DataSet employeetDataSet = EmployeeBL.getAllEmployee();
            if (employeetDataSet.Tables.Count > 0)
            {
                dgvEmployee.DataSource = employeetDataSet.Tables[0].DefaultView;
            }
            componentLocations[0] = pbSearch.Location;
            componentLocations[1] = pbAdd.Location;
            componentLocations[2] = pbSave.Location;
            componentLocations[3] = pbDelete.Location;
            componentLocations[4] = pbRefresh.Location;
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            // Search by name
            String searchName = tbSearch.Text;
            DataSet employeetDataSet = EmployeeBL.findEmployeeByName(searchName);
            if (employeetDataSet.Tables.Count > 0)
            {
                dgvEmployee.DataSource = employeetDataSet.Tables[0].DefaultView;
            }
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            String fullName, phoneNumber, address, email, isWorking;
            fullName = tbName.Text;
            phoneNumber = tbPhoneNumber.Text;
            address = tbAddress.Text;
            isWorking = cbWorking.Text;
            email = tbEmail.Text;
            if (EmployeeBL.addEmployee(fullName, phoneNumber, address, email, isWorking))
            {
                MessageBox.Show("Added a new row successfully!", "Action result");
                DataSet employeetDataSet = EmployeeBL.getAllEmployee();
                dgvEmployee.DataSource = employeetDataSet.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("Failed to add a row! Check your input data!", "Action result");
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ form
            string id = tbId.Text.Trim();
            string fullName = tbName.Text.Trim();
            string phoneNumber = tbPhoneNumber.Text.Trim();
            string address = tbAddress.Text.Trim();
            string email = tbEmail.Text.Trim();
            string isWorking = cbWorking.Text.Trim();
            string isDeleted = cbDeleted.Text.Trim();

            // Kiểm tra đầu vào rỗng
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thiếu dữ liệu");
                return;
            }

            // Chuyển đổi giá trị chuỗi "Yes"/"No" thành bool
            bool isDeletedBool = isDeleted.Equals("Yes", StringComparison.OrdinalIgnoreCase);

            // Nếu bị xóa, thì tự động không còn làm việc
            if (isDeletedBool)
            {
                isWorking = "No";
            }

            // Gọi hàm cập nhật
            bool result = EmployeeBL.updateEmployee(
                id, fullName, phoneNumber, address, email, isWorking, "update", isDeletedBool);

            if (result)
            {
                MessageBox.Show("Updated a row successfully!", "Action result");
                DataSet employeeDataSet = EmployeeBL.getAllEmployee();
                dgvEmployee.DataSource = employeeDataSet.Tables[0].DefaultView;
            }
            else
            {
                MessageBox.Show("Failed to update a row! Check your input data!", "Action result");
            }
        }




        private void pbRefresh_Click(object sender, EventArgs e)
        {
            // Reset all textboxes
            tbSearch.Text = "";
            tbId.Text = "";
            tbName.Text = "";
            tbPhoneNumber.Text = "";
            tbAddress.Text = "";
            tbEmail.Text = "";

            DataSet employeetDataSet = EmployeeBL.getAllEmployee();
            if (employeetDataSet.Tables.Count > 0)
            {
                dgvEmployee.DataSource = employeetDataSet.Tables[0].DefaultView;
            }
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvEmployee.Rows[e.RowIndex];
                tbId.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                tbPhoneNumber.Text = row.Cells[2].Value.ToString();
                tbAddress.Text = row.Cells[3].Value.ToString();
                tbEmail.Text = row.Cells[4].Value.ToString();

                switch (row.Cells[5].Value)
                {
                    case true:
                        cbWorking.SelectedIndex = 0;
                        break;
                    case false:
                        cbWorking.SelectedIndex = 1;
                        break;
                    default:
                        break;
                }


                switch (row.Cells[8].Value)
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

        private void pbDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
