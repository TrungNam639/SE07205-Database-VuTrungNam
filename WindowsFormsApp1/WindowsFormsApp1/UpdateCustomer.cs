using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer(string CustomerID, string CustomerName, int PhoneNumber, string Address)
        {
            InitializeComponent();
            // Set the form to start in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;


            // Disable the maximize/restore button
            this.MaximizeBox = false;

            // Optional: Set a fixed border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            txb_phone.Text = PhoneNumber + "";
            txb_address.Text = Address + "";
            txb_id.Text = CustomerID;
            txb_name.Text = CustomerName;
        }

        private void UpdateCustomerInDatabase(string CustomerID, string CustomerName, int PhoneNumber, string Address)
        {
            string query = "UPDATE Customer SET CustomerName = @CustomerName, Address = @Address, PhoneNumber = @PhoneNumber WHERE CustomerID = @CustomerID";

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        command.Parameters.AddWithValue("@CustomerName", CustomerName);
                        command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        command.Parameters.AddWithValue("@Address", Address);

                        // Execute the update command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No customer found with the specified code.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void DeleteCustomerFromDatabase(string CustomerID)
        {
            string query = "DELETE FROM Customer WHERE CustomerID = @CustomerID";

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);

                        // Execute the delete command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No customer found with the specified code.");
                        }
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
            // Get updated values from textboxes
            string CustomerID = txb_id.Text;
            string CustomerName = txb_name.Text;
            int PhoneNumber = int.Parse(txb_phone.Text.ToString().Trim());
            string Address = txb_address.Text;


            UpdateCustomerInDatabase(CustomerID, CustomerName, PhoneNumber, Address);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get the product code from the textbox
            string code = txb_id.Text.Trim();

            // Confirm before deleting
            var confirmResult = MessageBox.Show("Are you sure you want to delete this Customer?",
                                                 "Confirm Delete",
                                                 MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                // Call method to delete the product from the database
                DeleteCustomerFromDatabase(code);
            }
        }
    }
}
