namespace Krop.WinForms.Forms.AppUsers
{
    partial class frmAppUserCart
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
            txtCity = new TextBox();
            label10 = new Label();
            txtAddress = new TextBox();
            label9 = new Label();
            txtCountry = new TextBox();
            label8 = new Label();
            txtNationalNumber = new TextBox();
            label7 = new Label();
            txtEmail = new TextBox();
            label6 = new Label();
            panelBottom = new System.Windows.Forms.Panel();
            bttnActivasyonMailSender = new Button();
            bttnPasswordResetMailSender = new Button();
            panelMid = new System.Windows.Forms.Panel();
            appUserComboBoxControl = new UserControllers.AppUsers.AppUserComboBoxControl();
            txtPhoneNumber = new TextBox();
            label5 = new Label();
            txtLastName = new TextBox();
            label4 = new Label();
            txtFirstName = new TextBox();
            label3 = new Label();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // txtCity
            // 
            txtCity.Enabled = false;
            txtCity.Location = new Point(15, 372);
            txtCity.Name = "txtCity";
            txtCity.ReadOnly = true;
            txtCity.Size = new Size(200, 23);
            txtCity.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(15, 354);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 16;
            label10.Text = "Şehir :";
            // 
            // txtAddress
            // 
            txtAddress.Enabled = false;
            txtAddress.Location = new Point(15, 415);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(200, 136);
            txtAddress.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(15, 398);
            label9.Name = "label9";
            label9.Size = new Size(43, 15);
            label9.TabIndex = 16;
            label9.Text = "Adres :";
            // 
            // txtCountry
            // 
            txtCountry.Enabled = false;
            txtCountry.Location = new Point(15, 327);
            txtCountry.Name = "txtCountry";
            txtCountry.ReadOnly = true;
            txtCountry.Size = new Size(200, 23);
            txtCountry.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 309);
            label8.Name = "label8";
            label8.Size = new Size(36, 15);
            label8.TabIndex = 14;
            label8.Text = "Ülke :";
            // 
            // txtNationalNumber
            // 
            txtNationalNumber.Enabled = false;
            txtNationalNumber.Location = new Point(15, 278);
            txtNationalNumber.Name = "txtNationalNumber";
            txtNationalNumber.ReadOnly = true;
            txtNationalNumber.Size = new Size(200, 23);
            txtNationalNumber.TabIndex = 13;
            txtNationalNumber.KeyPress += txtNationalNumber_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 260);
            label7.Name = "label7";
            label7.Size = new Size(52, 15);
            label7.TabIndex = 12;
            label7.Text = "T.C. No :";
            // 
            // txtEmail
            // 
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(15, 229);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 211);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 10;
            label6.Text = "Email :";
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnActivasyonMailSender);
            panelBottom.Controls.Add(bttnPasswordResetMailSender);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 572);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(230, 41);
            panelBottom.TabIndex = 4;
            // 
            // bttnActivasyonMailSender
            // 
            bttnActivasyonMailSender.Dock = DockStyle.Left;
            bttnActivasyonMailSender.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            bttnActivasyonMailSender.ImageAlign = ContentAlignment.MiddleLeft;
            bttnActivasyonMailSender.Location = new Point(0, 0);
            bttnActivasyonMailSender.Name = "bttnActivasyonMailSender";
            bttnActivasyonMailSender.Size = new Size(128, 41);
            bttnActivasyonMailSender.TabIndex = 1;
            bttnActivasyonMailSender.Text = "Aktivasyon Sıfırlama Maili Gönder";
            bttnActivasyonMailSender.UseVisualStyleBackColor = true;
            bttnActivasyonMailSender.Click += bttnActivasyonMailSender_Click;
            // 
            // bttnPasswordResetMailSender
            // 
            bttnPasswordResetMailSender.Dock = DockStyle.Right;
            bttnPasswordResetMailSender.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            bttnPasswordResetMailSender.ImageAlign = ContentAlignment.MiddleLeft;
            bttnPasswordResetMailSender.Location = new Point(128, 0);
            bttnPasswordResetMailSender.Name = "bttnPasswordResetMailSender";
            bttnPasswordResetMailSender.Size = new Size(102, 41);
            bttnPasswordResetMailSender.TabIndex = 0;
            bttnPasswordResetMailSender.Text = "Şifre Sıfırlama Maili Gönder";
            bttnPasswordResetMailSender.UseVisualStyleBackColor = true;
            bttnPasswordResetMailSender.Click += bttnPasswordResetMailSender_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(appUserComboBoxControl);
            panelMid.Controls.Add(txtCity);
            panelMid.Controls.Add(label10);
            panelMid.Controls.Add(txtAddress);
            panelMid.Controls.Add(label9);
            panelMid.Controls.Add(txtCountry);
            panelMid.Controls.Add(label8);
            panelMid.Controls.Add(txtNationalNumber);
            panelMid.Controls.Add(label7);
            panelMid.Controls.Add(txtEmail);
            panelMid.Controls.Add(label6);
            panelMid.Controls.Add(txtPhoneNumber);
            panelMid.Controls.Add(label5);
            panelMid.Controls.Add(txtLastName);
            panelMid.Controls.Add(label4);
            panelMid.Controls.Add(txtFirstName);
            panelMid.Controls.Add(label3);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(230, 613);
            panelMid.TabIndex = 5;
            // 
            // appUserComboBoxControl
            // 
            appUserComboBoxControl.Location = new Point(0, 13);
            appUserComboBoxControl.Name = "appUserComboBoxControl";
            appUserComboBoxControl.Size = new Size(248, 50);
            appUserComboBoxControl.TabIndex = 18;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Enabled = false;
            txtPhoneNumber.Location = new Point(15, 179);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.ReadOnly = true;
            txtPhoneNumber.Size = new Size(200, 23);
            txtPhoneNumber.TabIndex = 9;
            txtPhoneNumber.KeyPress += txtPhoneNumber_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 161);
            label5.Name = "label5";
            label5.Size = new Size(105, 15);
            label5.TabIndex = 8;
            label5.Text = "Telefon Numarası :";
            // 
            // txtLastName
            // 
            txtLastName.Enabled = false;
            txtLastName.Location = new Point(15, 131);
            txtLastName.Name = "txtLastName";
            txtLastName.ReadOnly = true;
            txtLastName.Size = new Size(200, 23);
            txtLastName.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 113);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 6;
            label4.Text = "Soyad :";
            // 
            // txtFirstName
            // 
            txtFirstName.Enabled = false;
            txtFirstName.Location = new Point(15, 83);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.ReadOnly = true;
            txtFirstName.Size = new Size(200, 23);
            txtFirstName.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 65);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 4;
            label3.Text = "Ad :";
            // 
            // frmAppUserCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(230, 613);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmAppUserCart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kullanıcı Kartı";
            Load += frmAppUserCart_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtCity;
        private Label label10;
        private TextBox txtAddress;
        private Label label9;
        private TextBox txtCountry;
        private Label label8;
        private TextBox txtNationalNumber;
        private Label label7;
        private TextBox txtEmail;
        private Label label6;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnActivasyonMailSender;
        private Button bttnPasswordResetMailSender;
        private System.Windows.Forms.Panel panelMid;
        private TextBox txtPhoneNumber;
        private Label label5;
        private TextBox txtLastName;
        private Label label4;
        private TextBox txtFirstName;
        private Label label3;
        private UserControllers.AppUsers.AppUserComboBoxControl appUserComboBoxControl;
    }
}