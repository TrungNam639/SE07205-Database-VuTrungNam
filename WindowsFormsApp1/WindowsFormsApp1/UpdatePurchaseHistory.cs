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
        string[] items = { "Cancle", "Pending", "Finish" };
        static int selectID = 0;

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

        private void cbx_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbx_status.SelectedIndex; // Lấy chỉ số của item đã chọn trong ComboBox
            if (selectedIndex != -1) // Kiểm tra nếu người dùng đã chọn một giá trị
            {
                // Hiển thị thông tin về trạng thái đã chọn
                MessageBox.Show($"Selected Status: {cbx_status.SelectedItem.ToString()}");

                // Nếu cần, bạn có thể cập nhật trạng thái vào các TextBox hoặc thực hiện hành động nào đó
                // Ví dụ: cập nhật giá trị của `status` trong cơ sở dữ liệu hoặc thay đổi giao diện

                string selectedStatus = cbx_status.SelectedItem.ToString();
                // Thực hiện hành động tương ứng với trạng thái đã chọn
                if (selectedStatus == "Cancle")
                {
                    // Ví dụ: cập nhật một số thông tin liên quan đến trạng thái "Cancle"
                }
                else if (selectedStatus == "Pending")
                {
                    // Ví dụ: xử lý trạng thái "Pending"
                }
                else if (selectedStatus == "Finish")
                {
                    // Ví dụ: xử lý trạng thái "Finish"
                }
            }
            else
            {
                MessageBox.Show("No item selected.");
            }
        }

        private void DeletePurchaseHistoryFromDatabase(string purchaseID)
        {
            // Câu lệnh SQL để cập nhật active = 0 thay vì xóa bản ghi
            string query = "UPDATE PurchaseHistory SET active = 0 WHERE PurchaseID = @PurchaseID";

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

                        // Hiển thị thông báo nếu cập nhật thành công
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Purchase history marked as inactive successfully.");
                            this.Close();  // Đóng form sau khi cập nhật
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
            /// Set the form to start in the center of the screen
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

            // Call the function to populate ComboBox and other controls
            PopulateForm();
        }

        private void PopulateForm()
        {
            // Populate ComboBox with status options
            cbx_status.Items.Clear();  // Clear any existing items
            cbx_status.Items.AddRange(items);  // Add predefined items to ComboBox

            // Set the selected item from the status variable
            cbx_status.SelectedItem = status;

            // Fill other fields
            tBx_purchaseID.Text = purchaseID;
            tBx_customerID.Text = customerID;
            tBx_productID.Text = productCode;
            tBx_quantity.Text = quantity.ToString();
            dtp_datetime.Value = DateTime.Parse(purchaseDate);  // Convert the date string to DateTime
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
