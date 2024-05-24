namespace Krop.WinForms.Suppliers
{
    partial class frmSupplierCart
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
            cmbBoxSupplierSelect = new ComboBox();
            label10 = new Label();
            panelBottom = new System.Windows.Forms.Panel();
            txtWebSiteUrl = new TextBox();
            label9 = new Label();
            txtAddress = new TextBox();
            label5 = new Label();
            txtCity = new TextBox();
            txtCountry = new TextBox();
            txtEmail = new TextBox();
            label6 = new Label();
            panelMid = new System.Windows.Forms.Panel();
            label7 = new Label();
            label8 = new Label();
            txtPhoneNumber = new TextBox();
            label4 = new Label();
            txtContactTitle = new TextBox();
            txtContactName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // cmbBoxSupplierSelect
            // 
            cmbBoxSupplierSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxSupplierSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxSupplierSelect.FormattingEnabled = true;
            cmbBoxSupplierSelect.Location = new Point(21, 37);
            cmbBoxSupplierSelect.Name = "cmbBoxSupplierSelect";
            cmbBoxSupplierSelect.Size = new Size(234, 23);
            cmbBoxSupplierSelect.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(21, 19);
            label10.Name = "label10";
            label10.Size = new Size(160, 15);
            label10.TabIndex = 18;
            label10.Text = "Güncellenecek Tedarikçi Adı :";
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 500);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(274, 41);
            panelBottom.TabIndex = 8;
            // 
            // txtWebSiteUrl
            // 
            txtWebSiteUrl.Location = new Point(21, 469);
            txtWebSiteUrl.Name = "txtWebSiteUrl";
            txtWebSiteUrl.Size = new Size(234, 23);
            txtWebSiteUrl.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 451);
            label9.Name = "label9";
            label9.Size = new Size(79, 15);
            label9.TabIndex = 16;
            label9.Text = "Website URL :";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(21, 347);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(234, 97);
            txtAddress.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 329);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 14;
            label5.Text = "Adres :";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(21, 303);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(234, 23);
            txtCity.TabIndex = 13;
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(21, 259);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(234, 23);
            txtCountry.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(21, 215);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(234, 23);
            txtEmail.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 285);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 10;
            label6.Text = "Şehir :";
            // 
            // panelMid
            // 
            panelMid.Controls.Add(cmbBoxSupplierSelect);
            panelMid.Controls.Add(label10);
            panelMid.Controls.Add(txtWebSiteUrl);
            panelMid.Controls.Add(label9);
            panelMid.Controls.Add(txtAddress);
            panelMid.Controls.Add(label5);
            panelMid.Controls.Add(txtCity);
            panelMid.Controls.Add(txtCountry);
            panelMid.Controls.Add(txtEmail);
            panelMid.Controls.Add(label6);
            panelMid.Controls.Add(label7);
            panelMid.Controls.Add(label8);
            panelMid.Controls.Add(txtPhoneNumber);
            panelMid.Controls.Add(label4);
            panelMid.Controls.Add(txtContactTitle);
            panelMid.Controls.Add(txtContactName);
            panelMid.Controls.Add(label3);
            panelMid.Controls.Add(label2);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(274, 541);
            panelMid.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 241);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 9;
            label7.Text = "Ülke :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 197);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 8;
            label8.Text = "Email :";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(21, 169);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(234, 23);
            txtPhoneNumber.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 151);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 6;
            label4.Text = "Telefon Numarası :";
            // 
            // txtContactTitle
            // 
            txtContactTitle.Location = new Point(21, 125);
            txtContactTitle.Name = "txtContactTitle";
            txtContactTitle.Size = new Size(234, 23);
            txtContactTitle.TabIndex = 5;
            // 
            // txtContactName
            // 
            txtContactName.Location = new Point(21, 81);
            txtContactName.Name = "txtContactName";
            txtContactName.Size = new Size(234, 23);
            txtContactName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 107);
            label3.Name = "label3";
            label3.Size = new Size(213, 15);
            label3.TabIndex = 2;
            label3.Text = "İletişime Geçilecek Kişinin Departmanı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 63);
            label2.Name = "label2";
            label2.Size = new Size(131, 15);
            label2.TabIndex = 1;
            label2.Text = "İletişime Geçilecek Kişi :";
            // 
            // frmSupplierCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(274, 541);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmSupplierCart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tedarikçi Kartı";
            Load += frmSupplierCart_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbBoxSupplierSelect;
        private Label label10;
        private System.Windows.Forms.Panel panelBottom;
        private TextBox txtWebSiteUrl;
        private Label label9;
        private TextBox txtAddress;
        private Label label5;
        private TextBox txtCity;
        private TextBox txtCountry;
        private TextBox txtEmail;
        private Label label6;
        private System.Windows.Forms.Panel panelMid;
        private Label label7;
        private Label label8;
        private TextBox txtPhoneNumber;
        private Label label4;
        private TextBox txtContactTitle;
        private TextBox txtContactName;
        private Label label3;
        private Label label2;
    }
}