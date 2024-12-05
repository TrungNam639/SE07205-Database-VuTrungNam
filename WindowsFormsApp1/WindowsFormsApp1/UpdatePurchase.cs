using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class UpdatePurchase : Form
    {
        public UpdatePurchase(string CustomerID, string PurchaseID, int PurchaseDate, string Code, int Quantity, int status)
        {
            InitializeComponent();
            // Set the form to start in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;


            // Disable the maximize/restore button
            this.MaximizeBox = false;

            // Optional: Set a fixed border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            txb_customeid.Text = CustomerID + "";
            txb_purchaseid.Text = PurchaseID + "";
            txb_code.Text = Code + "";
            txb_purchasedate.Text = PurchaseDate + "" ;
            txb_quantity.Text = Quantity + "";
            txb_status.Text = status + "";

        }

        private void UpdatePurchaseInDatabase(string CustomerID, string PurchaseID, string Code, int PurchaseDate, int Quantity, int status)
        {
            string query = "UPDATE PurchaseHistory SET CustomerID = @CustomerID, PurchaseID = @PurchaseID, PurchaseDate = @PurchaseDate, Quantity = @Quantity, status = @status WHERE Code = @Code";

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        command.Parameters.AddWithValue("@PurchaseID", PurchaseID);
                        command.Parameters.AddWithValue("@PurchaseDate", PurchaseDate);
                        command.Parameters.AddWithValue("@Code", Code);
                        command.Parameters.AddWithValue("@Quantity", Quantity);
                        command.Parameters.AddWithValue("@status", status);

                        // Execute the update command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Purchase updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No purchase found with the specified code.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void DeletePurchaseFromDatabase(string PurchaseID)
        {
            string query = "DELETE FROM Purchase WHERE PurchaseID = @PurchaseID";

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@PurchaseID", PurchaseID);

                        // Execute the delete command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Purchase deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No Purchase found with the specified code.");
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
            string CustomerID = txb_customeid.Text;
            string PurchaseID = txb_purchaseid.Text;
            string Code = txb_code.Text;
            int PurchaseDate = int.Parse(txb_purchasedate.Text.ToString().Trim());
            int Quantity = int.Parse(txb_quantity.Text.ToString().Trim());
            int status = int.Parse(txb_status.Text.ToString().Trim());


            UpdatePurchaseInDatabase(CustomerID, PurchaseID, Code, PurchaseDate, Quantity, status);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get the product code from the textbox
            string PurchaseID = txb_purchaseid.Text.Trim();

            // Confirm before deleting
            var confirmResult = MessageBox.Show("Are you sure you want to delete this PurchaseHistory?",
                                                 "Confirm Delete",
                                                 MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                // Call method to delete the product from the database
                DeletePurchaseFromDatabase(PurchaseID);
            }
        }
    }
}
