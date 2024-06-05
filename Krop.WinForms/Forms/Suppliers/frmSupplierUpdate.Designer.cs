namespace Krop.WinForms.Suppliers
{
    partial class frmSupplierUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierUpdate));
            bttnSupplierUpdate = new Button();
            panelMid = new System.Windows.Forms.Panel();
            supplierComboBoxControl = new UserControllers.Suppliers.SupplierComboBoxControl();
            txtWebSiteUrl = new TextBox();
            label9 = new Label();
            txtAddress = new TextBox();
            label5 = new Label();
            txtCity = new TextBox();
            txtCountry = new TextBox();
            txtEmail = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtPhoneNumber = new TextBox();
            label4 = new Label();
            txtContactTitle = new TextBox();
            txtContactName = new TextBox();
            txtCompanyName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelBottom = new System.Windows.Forms.Panel();
            panelMid.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // bttnSupplierUpdate
            // 
            bttnSupplierUpdate.Dock = DockStyle.Right;
            bttnSupplierUpdate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnSupplierUpdate.Image = (Image)resources.GetObject("bttnSupplierUpdate.Image");
            bttnSupplierUpdate.Location = new Point(126, 0);
            bttnSupplierUpdate.Name = "bttnSupplierUpdate";
            bttnSupplierUpdate.Size = new Size(99, 39);
            bttnSupplierUpdate.TabIndex = 1;
            bttnSupplierUpdate.Text = "Güncelle";
            bttnSupplierUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnSupplierUpdate.UseVisualStyleBackColor = true;
            bttnSupplierUpdate.Click += bttnSupplierUpdate_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(supplierComboBoxControl);
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
            panelMid.Controls.Add(txtCompanyName);
            panelMid.Controls.Add(label3);
            panelMid.Controls.Add(label2);
            panelMid.Controls.Add(label1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(237, 546);
            panelMid.TabIndex = 7;
            // 
            // supplierComboBoxControl
            // 
            supplierComboBoxControl.Location = new Point(0, 14);
            supplierComboBoxControl.Name = "supplierComboBoxControl";
            supplierComboBoxControl.Size = new Size(228, 51);
            supplierComboBoxControl.TabIndex = 38;
            // 
            // txtWebSiteUrl
            // 
            txtWebSiteUrl.Location = new Point(15, 511);
            txtWebSiteUrl.Name = "txtWebSiteUrl";
            txtWebSiteUrl.PlaceholderText = "Website Url...";
            txtWebSiteUrl.Size = new Size(200, 23);
            txtWebSiteUrl.TabIndex = 37;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(15, 493);
            label9.Name = "label9";
            label9.Size = new Size(79, 15);
            label9.TabIndex = 36;
            label9.Text = "Website URL :";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(15, 391);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Adres...";
            txtAddress.Size = new Size(200, 97);
            txtAddress.TabIndex = 35;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 373);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 34;
            label5.Text = "Adres :";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(15, 347);
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "Şehir...";
            txtCity.Size = new Size(200, 23);
            txtCity.TabIndex = 33;
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(15, 303);
            txtCountry.Name = "txtCountry";
            txtCountry.PlaceholderText = "Ülke...";
            txtCountry.Size = new Size(200, 23);
            txtCountry.TabIndex = 32;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(15, 259);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email...";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 329);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 30;
            label6.Text = "Şehir :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 285);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 29;
            label7.Text = "Ülke :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 241);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 28;
            label8.Text = "Email :";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(15, 213);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "Telefon Numarası...";
            txtPhoneNumber.Size = new Size(200, 23);
            txtPhoneNumber.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 195);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 26;
            label4.Text = "Telefon Numarası :";
            // 
            // txtContactTitle
            // 
            txtContactTitle.Location = new Point(15, 169);
            txtContactTitle.Name = "txtContactTitle";
            txtContactTitle.PlaceholderText = "İletişime Geçilecek Kişinin Departmenı...";
            txtContactTitle.Size = new Size(200, 23);
            txtContactTitle.TabIndex = 25;
            // 
            // txtContactName
            // 
            txtContactName.Location = new Point(15, 125);
            txtContactName.Name = "txtContactName";
            txtContactName.PlaceholderText = "İletişime Geçilecek Kişi...";
            txtContactName.Size = new Size(200, 23);
            txtContactName.TabIndex = 24;
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new Point(15, 81);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.PlaceholderText = "Tedarikçi Adı...";
            txtCompanyName.Size = new Size(200, 23);
            txtCompanyName.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 151);
            label3.Name = "label3";
            label3.Size = new Size(213, 15);
            label3.TabIndex = 22;
            label3.Text = "İletişime Geçilecek Kişinin Departmanı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 107);
            label2.Name = "label2";
            label2.Size = new Size(131, 15);
            label2.TabIndex = 21;
            label2.Text = "İletişime Geçilecek Kişi :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 63);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 20;
            label1.Text = "Tedarikçi Adı :";
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnSupplierUpdate);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 546);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(237, 41);
            panelBottom.TabIndex = 6;
            // 
            // frmSupplierUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(237, 587);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            MaximizeBox = false;
            Name = "frmSupplierUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tedarikçi Güncelle";
            Load += frmSupplierUpdate_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button bttnSupplierUpdate;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panelBottom;
        private TextBox txtWebSiteUrl;
        private Label label9;
        private TextBox txtAddress;
        private Label label5;
        private TextBox txtCity;
        private TextBox txtCountry;
        private TextBox txtEmail;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtPhoneNumber;
        private Label label4;
        private TextBox txtContactTitle;
        private TextBox txtContactName;
        private TextBox txtCompanyName;
        private Label label3;
        private Label label2;
        private Label label1;
        private UserControllers.Suppliers.SupplierComboBoxControl supplierComboBoxControl;
    }
}