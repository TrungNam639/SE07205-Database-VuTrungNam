namespace WindowsFormsApp1
{
    partial class UpdatePurchaseHistory
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
            this.cbx_status = new System.Windows.Forms.ComboBox();
            this.dtp_datetime = new System.Windows.Forms.DateTimePicker();
            this.tBx_quantity = new System.Windows.Forms.TextBox();
            this.tBx_customerID = new System.Windows.Forms.TextBox();
            this.tBx_productID = new System.Windows.Forms.TextBox();
            this.tBx_purchaseID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 437);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 55);
            this.button1.TabIndex = 38;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbx_status
            // 
            this.cbx_status.FormattingEnabled = true;
            this.cbx_status.Location = new System.Drawing.Point(209, 383);
            this.cbx_status.Name = "cbx_status";
            this.cbx_status.Size = new System.Drawing.Size(284, 24);
            this.cbx_status.TabIndex = 37;
            // 
            // dtp_datetime
            // 
            this.dtp_datetime.Location = new System.Drawing.Point(209, 318);
            this.dtp_datetime.Name = "dtp_datetime";
            this.dtp_datetime.Size = new System.Drawing.Size(285, 22);
            this.dtp_datetime.TabIndex = 36;
            // 
            // tBx_quantity
            // 
            this.tBx_quantity.Location = new System.Drawing.Point(209, 258);
            this.tBx_quantity.Name = "tBx_quantity";
            this.tBx_quantity.Size = new System.Drawing.Size(285, 22);
            this.tBx_quantity.TabIndex = 35;
            // 
            // tBx_customerID
            // 
            this.tBx_customerID.Location = new System.Drawing.Point(211, 185);
            this.tBx_customerID.Name = "tBx_customerID";
            this.tBx_customerID.Size = new System.Drawing.Size(283, 22);
            this.tBx_customerID.TabIndex = 34;
            // 
            // tBx_productID
            // 
            this.tBx_productID.Location = new System.Drawing.Point(211, 103);
            this.tBx_productID.Name = "tBx_productID";
            this.tBx_productID.Size = new System.Drawing.Size(283, 22);
            this.tBx_productID.TabIndex = 33;
            // 
            // tBx_purchaseID
            // 
            this.tBx_purchaseID.Location = new System.Drawing.Point(208, 43);
            this.tBx_purchaseID.Name = "tBx_purchaseID";
            this.tBx_purchaseID.Size = new System.Drawing.Size(286, 22);
            this.tBx_purchaseID.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "PurchaseDate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "PurchaseID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "CustomerID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Code";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(357, 437);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 55);
            this.button2.TabIndex = 39;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UpdatePurchaseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 559);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbx_status);
            this.Controls.Add(this.dtp_datetime);
            this.Controls.Add(this.tBx_quantity);
            this.Controls.Add(this.tBx_customerID);
            this.Controls.Add(this.tBx_productID);
            this.Controls.Add(this.tBx_purchaseID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UpdatePurchaseHistory";
            this.Text = "UpdatePurchaseHistory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbx_status;
        private System.Windows.Forms.DateTimePicker dtp_datetime;
        private System.Windows.Forms.TextBox tBx_quantity;
        private System.Windows.Forms.TextBox tBx_customerID;
        private System.Windows.Forms.TextBox tBx_productID;
        private System.Windows.Forms.TextBox tBx_purchaseID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}