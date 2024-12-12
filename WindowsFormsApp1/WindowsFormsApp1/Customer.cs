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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            // set the form border style to ensure it has a standard window look
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // optionally, set startposition to centerscreen if you want centered loading
            this.StartPosition = FormStartPosition.CenterScreen;


        }
        

        private void Customer_Load(object sender, EventArgs e)
        {
            dgv_customer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadCustomerData();
        }
        private void LoadCustomerData()
        {

            // SQL query to fetch data
            string query = "SELECT * FROM Customer";

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {

                try
                {
                    // Open the database connection
                    connection.Open();

                    // Create a SqlDataAdapter to execute the query and fill the DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with query results
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dgv_customer.DataSource = dataTable;

                    
                }
                catch (Exception ex)
                {
                    // Handle any errors that may occur
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadCustomerData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Addcustomer main = new Addcustomer();
            main.ShowDialog();
        }

        private void dgv_customer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked row is valid
            if (e.RowIndex >= 0 & PasswordHasher.roleID != 3 )
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgv_customer.Rows[e.RowIndex];

                // Retrieve data from each cell in the selected row
                var CustomerID = selectedRow.Cells["CustomerID"].Value.ToString();
                var CustomerName = selectedRow.Cells["CustomerName"].Value.ToString();
                var PhoneNumber = int.Parse(selectedRow.Cells["PhoneNumber"].Value.ToString());
                var Address = selectedRow.Cells["Address"].Value.ToString();


                UpdateCustomer updateCustomer= new UpdateCustomer(CustomerID, CustomerName, PhoneNumber, Address);
                updateCustomer.ShowDialog();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer(txt_search.Text);
        }

        private void SearchCustomer(string searchText)
        {
            // Nếu textbox tìm kiếm rỗng, hiển thị tất cả dữ liệu
            if (string.IsNullOrEmpty(searchText))
            {
                LoadCustomerData(); // Gọi lại hàm load dữ liệu ban đầu
            }
            else
            {
                // Viết câu lệnh SQL tìm kiếm theo CustomerID, CustomerName hoặc PhoneNumber
                string query = @"
            SELECT * 
            FROM Customer 
            WHERE 
                CustomerID LIKE @searchText 
                OR CustomerName LIKE @searchText
                OR PhoneNumber LIKE @searchText";  // Tìm kiếm theo CustomerID, CustomerName hoặc PhoneNumber

                // Thực thi truy vấn và cập nhật DataGridView
                using (SqlConnection conn = new SqlConnection(connectionString.sqlconnection))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Gán kết quả tìm kiếm vào DataGridView
                        dgv_customer.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                    }
                }
            }
        }

    }
}
