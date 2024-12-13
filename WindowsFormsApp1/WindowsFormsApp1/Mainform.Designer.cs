using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Product
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dgv_product = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv_product
            // 
            this.dgv_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_product.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_product.Location = new System.Drawing.Point(0, 0);
            this.dgv_product.Name = "dgv_product";
            this.dgv_product.RowHeadersWidth = 51;
            this.dgv_product.RowTemplate.Height = 24;
            this.dgv_product.Size = new System.Drawing.Size(800, 391);
            this.dgv_product.TabIndex = 0;
            this.dgv_product.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_product_CellContentClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txt_search);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_product);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 55;
            this.splitContainer1.TabIndex = 1;
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(245, 4);
            this.txt_search.Multiline = true;
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(413, 45);
            this.txt_search.TabIndex = 3;
            this.txt_search.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(680, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 49);
            this.button3.TabIndex = 2;
            this.button3.Text = "Home";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(129, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 49);
            this.button2.TabIndex = 1;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Product";
            this.Text = "Product";
            this.Load += new System.EventHandler(this.Mainform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dgv_product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked row is valid
            if (e.RowIndex >= 0 & PasswordHasher.roleID != 4)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgv_product.Rows[e.RowIndex];

                // Retrieve data from each cell in the selected row
                var code = selectedRow.Cells["Code"].Value.ToString();
                var name = selectedRow.Cells["Name"].Value.ToString();
                var price = int.Parse(selectedRow.Cells["Price"].Value.ToString());
                var quantity = int.Parse(selectedRow.Cells["Quantity"].Value.ToString());

                // Display data in textboxes or labels, or use it as needed
                /*  txtID.Text = id.ToString();
                  txtName.Text = name;
                  txtAge.Text = age.ToString();*/

                // MessageBox.Show($"Code  : {code}, Name: {name}, Price: {price},  Quantity: {quantity}");


                Updateproduct updateProduct = new Updateproduct(code, name, price, quantity);
                updateProduct.ShowDialog();

            }
        }

        #endregion
        private System.Windows.Forms.Button button1;
        private DataGridView dgv_product;
        private SplitContainer splitContainer1;
        private Button button2;
        private Button button3;
        private TextBox txt_search;
    }
}