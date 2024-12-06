using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // set the form to start in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // disable the maximize/ restore button
            this.MaximizeBox = false;

            // Optional: set a fixed border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Đặt TextBox mật khẩu để ẩn ký tự nhập
            txb_password.PasswordChar = '•';
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txb_username.Text;
            string password = txb_password.Text;

            // Băm mật khẩu nhập vào
            string hashedPassword = PasswordHasher.HashPassword(password);

            // Kiểm tra đăng nhập
            if (CheckEmployeeLogin(username, hashedPassword))
            {
                // Chuyển hướng tới form tương ứng với vai trò Employee
                string role = GetEmployeeRole(username);
                NavigateToEmployeeForm(role);
            }
            else if (CheckCustomerAccountLogin(username, hashedPassword))
            {
                // Chuyển hướng tới form Trang chủ cho Customer
                Customer customerHomeForm = new Customer();
                customerHomeForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect !");
            }

        }
        private bool CheckLogin(string username, string hashedPassword)
        {
            string query = "SELECT password FROM Employee WHERE username = @username";

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string storedHash = result.ToString(); // Retrieved hashed password
                        return storedHash == hashedPassword;  // Compare the hashes
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            return false; // Return false if username not found or any error occurs
        }
        private bool CheckEmployeeLogin(string username, string hashedPassword)
        {
            bool isValid = false;
            string query = "SELECT COUNT(*) FROM Employee WHERE Username = @username AND Password = @password";

            using (SqlConnection conn = new SqlConnection(connectionString.sqlconnection))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        isValid = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
            return isValid;
        }

        // Kiểm tra đăng nhập với bảng CustomerAccount
        private bool CheckCustomerAccountLogin(string username, string hashedPassword)
        {
            bool isValid = false;
            string query = "SELECT COUNT(*) FROM CustomerAccount WHERE Username = @username AND Password = @password";

            using (SqlConnection conn = new SqlConnection(connectionString.sqlconnection))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        isValid = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
            return isValid;
        }

        // Lấy vai trò của Employee sau khi đăng nhập
        private string GetEmployeeRole(string username)
        {
            string role = "";
            string query = "SELECT RoleID FROM Employee WHERE Username = @username";

            using (SqlConnection conn = new SqlConnection(connectionString.sqlconnection))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                try
                {
                    conn.Open();
                    role = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }

            return role;
        }

        // Chuyển hướng đến form Employee tương ứng
        private void NavigateToEmployeeForm(string role)
        {
            Form EmployeeManagement = null;

            switch (role)
            {
                case "1": // Admin
                    EmployeeManagement = new menu();
                    break;
                case "2": // Sale
                    EmployeeManagement = new Saleform();
                    break;
                case "3": // Warehouse
                    EmployeeManagement = new WarehouseForm();
                    break;
                default:
                    MessageBox.Show("Vai trò không hợp lệ.");
                    return;
            }

            if (EmployeeManagement != null)
            {
                EmployeeManagement.Show();
                this.Hide();
            }
        }


    }
}
