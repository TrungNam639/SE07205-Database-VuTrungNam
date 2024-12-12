using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            // set the form to start in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // disable the maximize/ restore button
            this.MaximizeBox = false;

            // Optional: set a fixed border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (PasswordHasher.roleID == 2)
            {

                button5.Visible = false;
            }
            else if (PasswordHasher.roleID == 3)
            {
                button5.Visible = false;
                button2.Visible = false;
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product main = new Product();
            main.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer main = new Customer();
            main.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PurchaseHis main = new PurchaseHis();
            main.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmployeeManagement main = new EmployeeManagement();
            main.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
            this.Hide();
        }
    }
}
