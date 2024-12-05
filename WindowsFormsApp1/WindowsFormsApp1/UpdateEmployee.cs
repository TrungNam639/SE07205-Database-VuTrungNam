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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class UpdateEmployee : Form
    {
        public UpdateEmployee(string code, string name, string position, int roleId, string username, string password)
        {
            InitializeComponent();
            // Set the form to start in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;


            // Disable the maximize/restore button
            this.MaximizeBox = false;

            // Optional: Set a fixed border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            txb_code.Text = code + "";
            txb_name.Text = name + "";
            txb_position.Text = position + "";
            txb_roleId.Text = roleId + "";
            txb_username.Text = username + "";
            txb_password.Text = password + "";
        }

        private void UpdateEmployeeInDatabase(string code, string name, string position, int roleId, string username, string password)
        {
            string query = "UPDATE Employee SET code = @code, name = @name, position = @position, roleId = @roleId, username = @username WHERE password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@code", code);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@position", position);
                        command.Parameters.AddWithValue("@roleId", roleId);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        // Execute the update command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No Employee found with the specified code.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void DeleteEmployeeFromDatabase(string code)
        {
            string query = "DELETE FROM Employee WHERE code = @code";

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@code", code);

                        // Execute the delete command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No Employee found with the specified code.");
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
            string code = txb_code.Text;
            string name = txb_name.Text;
            string position = txb_position.Text;
            int roleId = int.Parse(txb_roleId.Text.ToString().Trim());
            string username = txb_username.Text;
            string password = txb_password.Text;


            UpdateEmployeeInDatabase(code, name, position, roleId, username, password);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get the product code from the textbox
            string code = txb_code.Text.Trim();

            // Confirm before deleting
            var confirmResult = MessageBox.Show("Are you sure you want to delete this Employee?",
                                                 "Confirm Delete",
                                                 MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                // Call method to delete the product from the database
                DeleteEmployeeFromDatabase(code);
            }
        }
    }
}
