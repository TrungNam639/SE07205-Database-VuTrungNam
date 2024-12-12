namespace WindowsFormsApp1
{
    partial class AddPurchaseHistory
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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(283, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbx_status
            // 
            this.cbx_status.FormattingEnabled = true;
            this.cbx_status.Location = new System.Drawing.Point(227, 392);
            this.cbx_status.Name = "cbx_status";
            this.cbx_status.Size = new System.Drawing.Size(284, 24);
            this.cbx_status.TabIndex = 24;
            this.cbx_status.SelectedIndexChanged += new System.EventHandler(this.cbx_status_SelectedIndexChanged);
            // 
            // dtp_datetime
            // 
            this.dtp_datetime.Location = new System.Drawing.Point(227, 327);
            this.dtp_datetime.Name = "dtp_datetime";
            this.dtp_datetime.Size = new System.Drawing.Size(285, 22);
            this.dtp_datetime.TabIndex = 23;
            this.dtp_datetime.ValueChanged += new System.EventHandler(this.dtp_datetime_ValueChanged);
            // 
            // tBx_quantity
            // 
            this.tBx_quantity.Location = new System.Drawing.Point(227, 267);
            this.tBx_quantity.Name = "tBx_quantity";
            this.tBx_quantity.Size = new System.Drawing.Size(285, 22);
            this.tBx_quantity.TabIndex = 22;
            // 
            // tBx_customerID
            // 
            this.tBx_customerID.Location = new System.Drawing.Point(229, 194);
            this.tBx_customerID.Name = "tBx_customerID";
            this.tBx_customerID.Size = new System.Drawing.Size(283, 22);
            this.tBx_customerID.TabIndex = 21;
            // 
            // tBx_productID
            // 
            this.tBx_productID.Location = new System.Drawing.Point(229, 112);
            this.tBx_productID.Name = "tBx_productID";
            this.tBx_productID.Size = new System.Drawing.Size(283, 22);
            this.tBx_productID.TabIndex = 20;
            // 
            // tBx_purchaseID
            // 
            this.tBx_purchaseID.Location = new System.Drawing.Point(226, 52);
            this.tBx_purchaseID.Name = "tBx_purchaseID";
            this.tBx_purchaseID.Size = new System.Drawing.Size(286, 22);
            this.tBx_purchaseID.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "PurchaseDate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "PurchaseID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "CustomerID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Code";
            // 
            // AddPurchaseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 565);
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
            this.Name = "AddPurchaseHistory";
            this.Text = "AddPurchaseHistory";
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
    }
}