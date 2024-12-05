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
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
            // Set the form to start in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;


            // Disable the maximize/restore button
            this.MaximizeBox = false;

            // Optional: Set a fixed border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void InsertData(string code, string name, string position, int roleId, string username, string password)
        {
            // Connection string to your database

            // SQL query to insert data
            string query = "INSERT INTO Employee (code, name, position, roleId, username, password) VALUES (@code, @name, @position, @roleId, @username, @password)";

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
                        command.Parameters.AddWithValue("@code", code);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@position", position);
                        command.Parameters.AddWithValue("@roleId", roleId);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
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
            string code = txb_code.Text.ToString();
            string name = txb_name.Text.ToString();
            string position = txb_position.Text.ToString();
            int roleId = int.Parse(txb_roleId.Text.ToString());
            string username = txb_username.Text.ToString();
            string password = txb_password.Text.ToString();
            string hashPassword = PasswordHasher.HashPassword(password);

            InsertData(code, name, position, roleId, username, hashPassword);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Clear the text in all TextBoxes
            txb_code.Text = string.Empty;
            txb_name.Text = string.Empty;
            txb_position.Text = string.Empty;
            txb_roleId.Text = string.Empty;
            txb_username.Text = string.Empty;
            txb_password.Text = string.Empty;
        }

        private void AddEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancel the close event and hide the form instead
            e.Cancel = true;
            this.Hide();
        }
    }
}
