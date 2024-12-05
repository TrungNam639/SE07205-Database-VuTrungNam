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
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();

            // Set the form to start in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;


            // Disable the maximize/restore button
            this.MaximizeBox = false;

            // Optional: Set a fixed border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        

        private void AddProductForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MaSP = txb_code.Text.ToString();
            string TenSP = txb_name.Text.ToString();
            int SoLuong = int.Parse(txb_quantity.Text.ToString());
            int Gia = int.Parse(txb_price.Text.ToString());

            InsertData(MaSP, TenSP, SoLuong, Gia);

        }
        private void InsertData(string code, string name, int Quantity, int price)
        {
            // Connection string to your database

            // SQL query to insert data
            string query = "INSERT INTO Product (Code, Name, Quantity, Price) VALUES (@Code, @Name, @Quantity, @Price)";

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
                        command.Parameters.AddWithValue("@Name", name);

                        command.Parameters.AddWithValue("@Code", code);
                        command.Parameters.AddWithValue("@Quantity", Quantity);
                        command.Parameters.AddWithValue("@Price", price);

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

        private void button2_Click(object sender, EventArgs e)
        {
            // Clear the text in all TextBoxes
            txb_code.Text = string.Empty;
            txb_name.Text = string.Empty;
            txb_quantity.Text = string.Empty;
            txb_price.Text = string.Empty;
        }
        // Override the FormClosing event to prevent the application from exiting
        private void AddProductForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancel the close event and hide the form instead
            e.Cancel = true;
            this.Hide();
        }
    }
}
