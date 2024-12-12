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
    public partial class Addcustomer : Form
    {
        public Addcustomer()
        {
            InitializeComponent();

            // Set the form to start in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;


            // Disable the maximize/restore button
            this.MaximizeBox = false;

            // Optional: Set a fixed border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void InsertData(string CustomerID, string CustomerName, string PhoneNumber, string Address)
        {
            // Connection string to your database

            // SQL query to insert data
            string query = "INSERT INTO Customer (CustomerID, CustomerName, PhoneNumber, Address) VALUES (@CustomerID, @CustomerName, @PhoneNumber, @Address)";

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
                        command.Parameters.AddWithValue("@CustomerName", CustomerName);

                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        command.Parameters.AddWithValue("@Address", Address);

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

        private void button1_Click(object sender, EventArgs e)
        {
            string ID = txb_id.Text.ToString();
            string Ten = txb_name.Text.ToString();
            string Sodt = txb_phone.Text.ToString();
            string diachi = txb_address.Text.ToString();

            InsertData(ID, Ten, Sodt, diachi);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Clear the text in all TextBoxes
            txb_id.Text = string.Empty;
            txb_name.Text = string.Empty;
            txb_phone.Text = string.Empty;
            txb_address.Text = string.Empty;
        }

        // Override the FormClosing event to prevent the application from exiting
        private void Addcustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancel the close event and hide the form instead
            e.Cancel = true;
            this.Hide();
        }

        private void Addcustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
