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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // set the form to start in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // disable the maximize/ restore button
            this.MaximizeBox = false;

            // Optional: set a fixed border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Đặt TextBox mật khẩu để ẩn ký tự nhập
            txb_password.PasswordChar = '•';
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txb_username.Text;
            string password = txb_password.Text;

            // Băm mật khẩu nhập vào
            string hashedPassword = PasswordHasher.HashPassword(password);

            bool checkLogin = CheckLogin(username, hashedPassword);

            if (checkLogin)
            {
                menu main = new menu();
                main.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Username or password is incorrect !");
            }

        }

        private bool CheckLogin(string username, string hashedPassword)
        {
            string query = "SELECT password, roleid FROM Employee WHERE username = @username";

            using (SqlConnection connection = new SqlConnection(connectionString.sqlconnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["password"].ToString(); // Retrieved hashed password
                            int roleid = Convert.ToInt32(reader["roleid"]); // Retrieved roleId


                            PasswordHasher.roleID = roleid; // Assign the roleId to your global variable or utility class

                            return storedHash == hashedPassword; // Compare the hashes
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            return false; // Return false if username not found or any error occurs
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Close the application
            }
        }
    }


}
