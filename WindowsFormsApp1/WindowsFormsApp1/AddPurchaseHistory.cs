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
    public partial class AddPurchaseHistory : Form
    {
        string[] items = { "Cancle", "Pending", "Finish" };
        static int selectID = 0;

        public AddPurchaseHistory()
        {
            InitializeComponent();
            // Set the form to start in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;


            // Disable the maximize/restore button
            this.MaximizeBox = false;

            // Optional: Set a fixed border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            cbx_status.Items.AddRange(items);
            cbx_status.SelectedIndexChanged += cbx_status_SelectedIndexChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int purchaseID = int.Parse(tBx_purchaseID.Text.ToString());
            string productID = tBx_productID.Text.ToString();
            string customerID = tBx_customerID.Text.ToString();
            int quantity = int.Parse(tBx_quantity.Text.ToString());
            DateTime selectedDate = dtp_datetime.Value.Date;

            // Get the selected status as a string from the combo box
            string status = cbx_status.SelectedItem.ToString();  // Get the string value ("Cancle", "Pending", or "Finish")

            InsertDataToPurchaseHistory(purchaseID, customerID, productID, selectedDate, quantity, status, 1);
        }

        private void cbx_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbx_status.SelectedIndex; // Gets the selected index
            if (selectedIndex != -1) // Check if an item is selected
            {
                MessageBox.Show($"Selected Index: {selectedIndex}");
            }
            else
            {
                MessageBox.Show("No item selected.");
            }
        }
        private void InsertDataToPurchaseHistory(int purchaseID, string customerCode,
            string productCode, DateTime purchaseDate, int quantity, string status, int active)
        {
            // SQL query to insert data into PurchaseHistory
            string query = "INSERT INTO PurchaseHistory " +
                           "(PurchaseID, CustomerID, Code, PurchaseDate, Quantity, status, active) " +
                           "VALUES (@PurchaseID, @CustomerID, @Code, @PurchaseDate, @Quantity, @status, @active)";

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create the SQL command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@PurchaseID", purchaseID);
                        command.Parameters.AddWithValue("@CustomerID", customerCode ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Code", productCode ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PurchaseDate", purchaseDate);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@status", status);  // Pass the status as a string
                        command.Parameters.AddWithValue("@active", active);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} row(s) inserted successfully.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void dtp_datetime_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
