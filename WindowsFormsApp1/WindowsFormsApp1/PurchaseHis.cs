﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class PurchaseHis : Form
    {
        string[] items = { "All", "Cancle", "Pending", "Finish" };
        static int selectID = 0;
        public PurchaseHis()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.FormBorderStyle = FormBorderStyle.Sizable;

            // Optionally, set StartPosition to CenterScreen if you want centered loading
            this.StartPosition = FormStartPosition.CenterScreen;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // this.LoadData();
            LoadPurchaseHistoryWithDetails(dataGridView1, 0);

            comboBox1.Items.AddRange(items);
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            if (PasswordHasher.roleID == 4)
            {

                button2.Visible = false;
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddPurchaseHistory addPurchaseHistory = new AddPurchaseHistory(); ;
            addPurchaseHistory.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked row is valid and that the roleID is not 4 (for restricting access)
            if (e.RowIndex >= 0 && PasswordHasher.roleID != 4)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Retrieve data from each cell in the selected row
                var purchaseID = selectedRow.Cells["PurchaseID"].Value.ToString();
                var customerID = selectedRow.Cells["CustomerID"].Value.ToString();
                var productCode = selectedRow.Cells["Code"].Value.ToString();
                var purchaseDate = Convert.ToDateTime(selectedRow.Cells["PurchaseDate"].Value).ToString("dd/MM/yyyy");
                var quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
                var status = selectedRow.Cells["status"].Value.ToString();
                var active = Convert.ToInt32(selectedRow.Cells["active"].Value);

                // Open the update form and pass the necessary data
                UpdatePurchaseHistory updateForm = new UpdatePurchaseHistory(purchaseID, customerID, productCode, purchaseDate, quantity, status, active);
                updateForm.ShowDialog();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;

            selectID = selectedIndex;
            // Passing selectedIndex to LoadPurchaseHistoryWithDetails
            LoadPurchaseHistoryWithDetails(dataGridView1, selectedIndex);

            if (selectedIndex != -1)
            {
                MessageBox.Show($"Selected Status: {items[selectedIndex]}");
            }
        }

        private void LoadPurchaseHistoryWithDetails(DataGridView dataGridView, int statusIndex)
        {
            // SQL query to join tables and retrieve data based on status
            string query = @"
        SELECT 
            ph.PurchaseID,
            ph.CustomerID,
            c.CustomerName,
            ph.Code,
            p.name,
            ph.PurchaseDate,
            ph.Quantity,
            ph.[status],
            ph.active
        FROM 
            PurchaseHistory ph
        INNER JOIN 
            Product p ON ph.Code = p.code
        INNER JOIN 
            Customer c ON ph.CustomerID = c.CustomerID
        WHERE 
            ph.[status] = @status";  // The query to filter by status

            // Query for "All" status (to retrieve all records)
            string queryAll = @"
        SELECT 
            ph.PurchaseID,
            ph.CustomerID,
            c.CustomerName,
            ph.Code,
            p.name,
            ph.PurchaseDate,
            ph.Quantity,
            ph.status,
            ph.active
        FROM 
            PurchaseHistory ph
        INNER JOIN 
            Product p ON ph.Code = p.code
        INNER JOIN 
            Customer c ON ph.CustomerID = c.CustomerID";

            // Set the appropriate status filter based on the ComboBox selection
            string selectedStatus = "";
            if (statusIndex == 0) // "All"
            {
                selectedStatus = ""; // Show all records
            }
            else
            {
                selectedStatus = items[statusIndex]; // Get selected status (Cancle, Pending, Finish)
            }

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string queryToExecute = (statusIndex == 0) ? queryAll : query;
                    SqlCommand command = new SqlCommand(queryToExecute, connection);

                    // If it's not "All", add the parameter
                    if (statusIndex != 0)
                    {
                        command.Parameters.AddWithValue("@status", selectedStatus);  // Add the parameter for status
                    }

                    // Execute the command and retrieve data
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the data to the DataGridView
                    dataGridView.DataSource = dataTable;

                    // Adjust DataGridView settings (optional)
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }


        private void LoadData()
        {
            // SQL query để lấy dữ liệu với active = 1
            string query = @"
    SELECT 
        ph.PurchaseID,
        ph.CustomerID,
        c.CustomerName,   
        ph.Code,
        p.name AS ProductName,   
        ph.PurchaseDate,
        ph.Quantity,
        ph.status,
        ph.active
    FROM 
        PurchaseHistory ph
    INNER JOIN 
        Product p ON ph.Code = p.code  
    INNER JOIN 
        Customer c ON ph.CustomerID = c.CustomerID
    WHERE 
        ph.active = 1"; // Thêm điều kiện active = 1

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlDataAdapter để thực thi câu lệnh và đổ dữ liệu vào DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Đổ dữ liệu vào DataTable
                    adapter.Fill(dataTable);

                    // Gắn DataTable vào DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            menu menuForm = new menu();
            menuForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Lấy từ khóa tìm kiếm từ TextBox
            string searchKeyword = textBox1.Text.Trim();

            // Gọi phương thức LoadPurchaseHistoryWithDetails để thực hiện tìm kiếm
            LoadPurchaseHistoryWithDetails(dataGridView1, selectID, searchKeyword);
        }

        private void LoadPurchaseHistoryWithDetails(DataGridView dataGridView, int statusIndex, string searchKeyword = "")
        {
            // SQL query để lọc kết quả theo trạng thái, từ khóa tìm kiếm và active = 1
            string query = @"
    SELECT 
        ph.PurchaseID,
        ph.CustomerID,
        c.CustomerName,
        ph.Code,
        p.name AS ProductName,
        ph.PurchaseDate,
        ph.Quantity,
        ph.[status],
        ph.active
    FROM 
        PurchaseHistory ph
    INNER JOIN 
        Product p ON ph.Code = p.code
    INNER JOIN 
        Customer c ON ph.CustomerID = c.CustomerID
    WHERE 
        ph.[status] = @status
        AND ph.active = 1
        AND (ph.PurchaseID LIKE @searchKeyword 
             OR c.CustomerName LIKE @searchKeyword 
             OR p.name LIKE @searchKeyword)";

            // Query cho "All" trạng thái (hiển thị tất cả các bản ghi có active = 1)
            string queryAll = @"
    SELECT 
        ph.PurchaseID,
        ph.CustomerID,
        c.CustomerName,
        ph.Code,
        p.name AS ProductName,
        ph.PurchaseDate,
        ph.Quantity,
        ph.status,
        ph.active
    FROM 
        PurchaseHistory ph
    INNER JOIN 
        Product p ON ph.Code = p.code
    INNER JOIN 
        Customer c ON ph.CustomerID = c.CustomerID
    WHERE 
        ph.active = 1
        AND (ph.PurchaseID LIKE @searchKeyword 
             OR c.CustomerName LIKE @searchKeyword 
             OR p.name LIKE @searchKeyword)";

            // Nếu trạng thái là "All", hiển thị tất cả các bản ghi với active = 1
            string selectedStatus = "";
            if (statusIndex == 0) // "All"
            {
                selectedStatus = ""; // Hiển thị tất cả các bản ghi
            }
            else
            {
                selectedStatus = items[statusIndex]; // Lấy trạng thái đã chọn (Cancle, Pending, Finish)
            }

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                try
                {
                    connection.Open();

                    // Chọn câu lệnh SQL phù hợp
                    string queryToExecute = (statusIndex == 0) ? queryAll : query;
                    SqlCommand command = new SqlCommand(queryToExecute, connection);

                    // Thêm tham số vào câu lệnh SQL
                    if (statusIndex != 0)
                    {
                        command.Parameters.AddWithValue("@status", selectedStatus); // Thêm tham số trạng thái
                    }
                    command.Parameters.AddWithValue("@searchKeyword", "%" + searchKeyword + "%"); // Thêm tham số tìm kiếm

                    // Thực thi câu lệnh và lấy dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Gắn dữ liệu vào DataGridView
                    dataGridView.DataSource = dataTable;

                    // Tùy chỉnh DataGridView
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }



        private void PurchaseHis_Load(object sender, EventArgs e)
        {

        }
    }
}
