﻿namespace Krop.WinForms.Customers
{
    partial class frmCustomerCart
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
            radioBttnCompany = new RadioButton();
            radioBttnPerson = new RadioButton();
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
            label3 = new Label();
            label2 = new Label();
            panelBottom = new System.Windows.Forms.Panel();
            panelMid = new System.Windows.Forms.Panel();
            customerComboBoxControl = new UserControllers.Customers.CustomerComboBoxControl();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // radioBttnCompany
            // 
            radioBttnCompany.AutoSize = true;
            radioBttnCompany.Location = new Point(154, 12);
            radioBttnCompany.Name = "radioBttnCompany";
            radioBttnCompany.Size = new Size(75, 19);
            radioBttnCompany.TabIndex = 17;
            radioBttnCompany.Text = "Kurumsal";
            radioBttnCompany.UseVisualStyleBackColor = true;
            // 
            // radioBttnPerson
            // 
            radioBttnPerson.AutoSize = true;
            radioBttnPerson.Checked = true;
            radioBttnPerson.Location = new Point(23, 12);
            radioBttnPerson.Name = "radioBttnPerson";
            radioBttnPerson.Size = new Size(65, 19);
            radioBttnPerson.TabIndex = 16;
            radioBttnPerson.TabStop = true;
            radioBttnPerson.Text = "Bireysel";
            radioBttnPerson.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            txtAddress.Enabled = false;
            txtAddress.Location = new Point(15, 369);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(206, 97);
            txtAddress.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 351);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 14;
            label5.Text = "Adres :";
            // 
            // txtCity
            // 
            txtCity.Enabled = false;
            txtCity.Location = new Point(15, 325);
            txtCity.Name = "txtCity";
            txtCity.ReadOnly = true;
            txtCity.Size = new Size(206, 23);
            txtCity.TabIndex = 13;
            // 
            // txtCountry
            // 
            txtCountry.Enabled = false;
            txtCountry.Location = new Point(15, 281);
            txtCountry.Name = "txtCountry";
            txtCountry.ReadOnly = true;
            txtCountry.Size = new Size(206, 23);
            txtCountry.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(15, 237);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(206, 23);
            txtEmail.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 307);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 10;
            label6.Text = "Şehir :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 263);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 9;
            label7.Text = "Ülke :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 219);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 8;
            label8.Text = "Email :";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Enabled = false;
            txtPhoneNumber.Location = new Point(15, 191);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.ReadOnly = true;
            txtPhoneNumber.Size = new Size(206, 23);
            txtPhoneNumber.TabIndex = 7;
            txtPhoneNumber.KeyPress += txtPhoneNumber_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 173);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 6;
            label4.Text = "Telefon Numarası :";
            // 
            // txtContactTitle
            // 
            txtContactTitle.Enabled = false;
            txtContactTitle.Location = new Point(15, 147);
            txtContactTitle.Name = "txtContactTitle";
            txtContactTitle.ReadOnly = true;
            txtContactTitle.Size = new Size(206, 23);
            txtContactTitle.TabIndex = 5;
            // 
            // txtContactName
            // 
            txtContactName.Enabled = false;
            txtContactName.Location = new Point(15, 103);
            txtContactName.Name = "txtContactName";
            txtContactName.ReadOnly = true;
            txtContactName.Size = new Size(206, 23);
            txtContactName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 129);
            label3.Name = "label3";
            label3.Size = new Size(213, 15);
            label3.TabIndex = 2;
            label3.Text = "İletişime Geçilecek Kişinin Departmanı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 85);
            label2.Name = "label2";
            label2.Size = new Size(131, 15);
            label2.TabIndex = 1;
            label2.Text = "İletişime Geçilecek Kişi :";
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 490);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(236, 41);
            panelBottom.TabIndex = 4;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(customerComboBoxControl);
            panelMid.Controls.Add(radioBttnCompany);
            panelMid.Controls.Add(radioBttnPerson);
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
            panelMid.Size = new Size(236, 531);
            panelMid.TabIndex = 5;
            // 
            // customerComboBoxControl
            // 
            customerComboBoxControl.Location = new Point(0, 33);
            customerComboBoxControl.Name = "customerComboBoxControl";
            customerComboBoxControl.Size = new Size(240, 51);
            customerComboBoxControl.TabIndex = 18;
            // 
            // frmCustomerCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(236, 531);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCustomerCart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Müşteri Kartı";
            Load += frmCustomerCart_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RadioButton radioBttnCompany;
        private RadioButton radioBttnPerson;
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
        private Label label3;
        private Label label2;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMid;
        private UserControllers.Customers.CustomerComboBoxControl customerComboBoxControl;
    }
}