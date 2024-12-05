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
    public partial class AddPuchase : Form
    {
        public AddPuchase()
        {
            InitializeComponent();
            // Set the form to start in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;


            // Disable the maximize/restore button
            this.MaximizeBox = false;

            // Optional: Set a fixed border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void InsertData(string PurchaseID, string CustomerID, string Code, int PurchaseDate, int Quantity, int status)
        {
            // Connection string to your database

            // SQL query to insert data
            string query = "INSERT INTO PurchaseHistory (PurchaseID, CustomerID, Code, PurchaseDate, Quantity, status) VALUES (@PurchaseID, @CustomerID, @Code, @PurchaseDate, @Quantity, @status)";

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
                        command.Parameters.AddWithValue("@PurchaseID", PurchaseID);
                        command.Parameters.AddWithValue("@Code", Code);
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        command.Parameters.AddWithValue("@PurchaseDate", PurchaseDate);
                        command.Parameters.AddWithValue("@Quantity", Quantity);
                        command.Parameters.AddWithValue("@status", status);
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Purchase = txb_purchaseid.Text.ToString();
            string Customer = txb_customeid.Text.ToString();
            string masp = txb_code.Text.ToString();
            int ngay = int.Parse(txb_purchasedate.Text.ToString());
            int Soluong = int.Parse(txb_quantity.Text.ToString());
            int status = int.Parse(txb_status.Text.ToString());

            InsertData(Purchase, Customer, masp, ngay, Soluong, status);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Clear the text in all TextBoxes
            txb_purchaseid.Text = string.Empty;
            txb_customeid.Text = string.Empty;
            txb_code.Text = string.Empty;
            txb_purchasedate.Text = string.Empty;
            txb_quantity.Text = string.Empty;
            txb_status.Text = string.Empty;
        }
        // Override the FormClosing event to prevent the application from exiting
        private void AddPuchase_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancel the close event and hide the form instead
            e.Cancel = true;
            this.Hide();
        }
    }
}
