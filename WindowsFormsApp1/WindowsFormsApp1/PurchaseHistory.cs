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
    public partial class PurchaseHistory : Form
    {
        public PurchaseHistory()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            /*this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);*/

            // set the form border style to ensure it has a standard window look
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // optionally, set startposition to centerscreen if you want centered loading
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        

        private void PurchaseHistory_Load(object sender, EventArgs e)
        {
            dgv_PurchaseHis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadPurchaseData();
        }
        private void LoadPurchaseData()
        {

            // SQL query to fetch data
            string query = "SELECT * FROM PurchaseHistory";

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
                    dgv_PurchaseHis.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Handle any errors that may occur
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPuchase main = new AddPuchase();
            main.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadPurchaseData();
        }

        private void dgv_PurchaseHis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked row is valid
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgv_PurchaseHis.Rows[e.RowIndex];

                // Retrieve data from each cell in the selected row
                var CustomerID = selectedRow.Cells["CustomerID"].Value.ToString();
                var PurchaseID = selectedRow.Cells["PurchaseID"].Value.ToString();
                var Code = selectedRow.Cells["Code"].Value.ToString();
                var PurchaseDate = int.Parse(selectedRow.Cells["PurchaseDate"].Value.ToString());
                var Quantity = int.Parse(selectedRow.Cells["Quantity"].Value.ToString());
                var status = int.Parse(selectedRow.Cells["status"].Value.ToString());

                // Display data in textboxes or labels, or use it as needed
                /*  txtID.Text = id.ToString();
                  txtName.Text = name;
                  txtAge.Text = age.ToString();*/

                // MessageBox.Show($"Code  : {code}, Name: {name}, Price: {price},  Quantity: {quantity}");


                UpdatePurchase updateProduct = new UpdatePurchase(CustomerID, PurchaseID, PurchaseDate, Code, Quantity, status);
                updateProduct.ShowDialog();

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
            SearchProduct(txt_search.Text);
        }

        private void SearchProduct(string searchText)
        {
            // Nếu textbox tìm kiếm rỗng, hiển thị tất cả dữ liệu
            if (string.IsNullOrEmpty(searchText))
            {
                LoadPurchaseData(); // Gọi lại hàm load dữ liệu ban đầu
            }
            else
            {
                // Viết câu lệnh SQL tìm kiếm sản phẩm theo mã hoặc tên
                string query = "SELECT * FROM Product WHERE Code LIKE @searchText OR Name LIKE @searchText";

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
                        dgv_PurchaseHis.DataSource = dt;
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
