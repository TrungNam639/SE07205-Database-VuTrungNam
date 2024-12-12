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
    public partial class UpdatePurchaseHistory : Form
    {
        private string purchaseID, customerID, productCode, purchaseDate, status;
        private int quantity, active;

        private void button2_Click(object sender, EventArgs e)
        {
            // Xác nhận trước khi xóa bản ghi
            var confirmResult = MessageBox.Show("Are you sure you want to delete this purchase history?",
                                                 "Confirm Delete",
                                                 MessageBoxButtons.YesNo);

            // Nếu người dùng xác nhận xóa
            if (confirmResult == DialogResult.Yes)
            {
                // Lấy PurchaseID từ TextBox
                string purchaseID = tBx_purchaseID.Text.Trim();

                // Gọi phương thức xóa bản ghi khỏi cơ sở dữ liệu
                DeletePurchaseHistoryFromDatabase(purchaseID);
            }
        }
        private void DeletePurchaseHistoryFromDatabase(string purchaseID)
        {
            // Câu lệnh SQL để xóa bản ghi trong bảng PurchaseHistory
            string query = "DELETE FROM PurchaseHistory WHERE PurchaseID = @PurchaseID";

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                try
                {
                    // Mở kết nối với cơ sở dữ liệu
                    connection.Open();

                    // Tạo câu lệnh SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số vào câu lệnh SQL
                        command.Parameters.AddWithValue("@PurchaseID", purchaseID);

                        // Thực thi câu lệnh và nhận số lượng dòng bị ảnh hưởng
                        int rowsAffected = command.ExecuteNonQuery();

                        // Hiển thị thông báo nếu xóa thành công
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Purchase history deleted successfully.");
                            this.Close();  // Đóng form sau khi xóa
                        }
                        else
                        {
                            MessageBox.Show("Purchase history not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        public UpdatePurchaseHistory(string purchaseID, string customerID, string productCode, string purchaseDate, int quantity, string status, int active)
        {
            InitializeComponent();
            // Set the form to start in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;


            // Disable the maximize/restore button
            this.MaximizeBox = false;

            // Optional: Set a fixed border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.purchaseID = purchaseID;
            this.customerID = customerID;
            this.productCode = productCode;
            this.purchaseDate = purchaseDate;
            this.quantity = quantity;
            this.status = status;
            this.active = active;

            // Gọi hàm để hiển thị thông tin lên form
            PopulateForm();
        }

        private void PopulateForm()
        {
            // Điền thông tin vào các trường TextBox và ComboBox
            tBx_purchaseID.Text = purchaseID;
            tBx_customerID.Text = customerID;
            tBx_productID.Text = productCode;
            tBx_quantity.Text = quantity.ToString();
            dtp_datetime.Value = DateTime.Parse(purchaseDate);  // Convert chuỗi ngày thành DateTime
            cbx_status.SelectedItem = status;  // Set giá trị của ComboBox là status
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox, ComboBox, và DateTimePicker
            string updatedPurchaseID = tBx_purchaseID.Text;
            string updatedCustomerID = tBx_customerID.Text;
            string updatedProductCode = tBx_productID.Text;
            int updatedQuantity = int.Parse(tBx_quantity.Text);
            DateTime updatedPurchaseDate = dtp_datetime.Value;
            string updatedStatus = cbx_status.SelectedItem.ToString();

            // Gọi phương thức cập nhật dữ liệu
            UpdatePurchaseHistoryInDatabase(updatedPurchaseID, updatedCustomerID, updatedProductCode, updatedPurchaseDate, updatedQuantity, updatedStatus);
        }
        private void UpdatePurchaseHistoryInDatabase(string purchaseID, string customerID, string productCode, DateTime purchaseDate, int quantity, string status)
        {
            // SQL query để cập nhật dữ liệu vào bảng PurchaseHistory
            string query = "UPDATE PurchaseHistory SET " +
                           "CustomerID = @CustomerID, " +
                           "Code = @Code, " +
                           "PurchaseDate = @PurchaseDate, " +
                           "Quantity = @Quantity, " +
                           "status = @status, " +
                           "active = @active " +
                           "WHERE PurchaseID = @PurchaseID";

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                try
                {
                    // Mở kết nối với cơ sở dữ liệu
                    connection.Open();

                    // Tạo câu lệnh SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số vào câu lệnh SQL để ngăn chặn SQL injection
                        command.Parameters.AddWithValue("@PurchaseID", purchaseID);
                        command.Parameters.AddWithValue("@CustomerID", customerID);
                        command.Parameters.AddWithValue("@Code", productCode);
                        command.Parameters.AddWithValue("@PurchaseDate", purchaseDate);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@status", status);

                        // Thực thi câu lệnh và nhận số lượng dòng bị ảnh hưởng
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} row(s) updated successfully.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
