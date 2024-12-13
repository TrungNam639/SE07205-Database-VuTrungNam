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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            // set the form border style to ensure it has a standard window look
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // optionally, set startposition to centerscreen if you want centered loading
            this.StartPosition = FormStartPosition.CenterScreen;

            if (PasswordHasher.roleID == 4)
            {

                button1.Visible = false;
            }
        }
        

        private void Mainform_Load(object sender, EventArgs e)
        {
            dgv_product.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadProductData();

        }
        private void LoadProductData()
        {
            // Cập nhật câu lệnh SQL để lọc dữ liệu theo điều kiện active = 1
            string query = "SELECT * FROM Product WHERE active = 1";

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                try
                {
                    // Mở kết nối với cơ sở dữ liệu
                    connection.Open();

                    // Tạo SqlDataAdapter để thực thi truy vấn và điền dữ liệu vào DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Điền dữ liệu vào DataTable từ kết quả truy vấn
                    adapter.Fill(dataTable);

                    // Liên kết DataTable với DataGridView
                    dgv_product.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AddProductForm main = new AddProductForm();
            main.ShowDialog();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadProductData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchProduct(txt_search.Text);
        }

        private void SearchProduct(string searchText)
        {
            // Nếu textbox tìm kiếm rỗng, hiển thị tất cả dữ liệu với active = 1
            if (string.IsNullOrEmpty(searchText))
            {
                LoadProductData(); // Gọi lại hàm load dữ liệu ban đầu với active = 1
            }
            else
            {
                // Cập nhật câu lệnh SQL để lọc dữ liệu theo active = 1 và tìm kiếm theo mã hoặc tên
                string query = "SELECT * FROM Product WHERE (Code LIKE @searchText OR Name LIKE @searchText) AND active = 1";

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
                        dgv_product.DataSource = dt;
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
