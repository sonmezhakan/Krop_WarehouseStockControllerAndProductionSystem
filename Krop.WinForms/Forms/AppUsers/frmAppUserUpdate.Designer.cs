namespace Krop.WinForms.Forms.AppUsers
{
    partial class frmAppUserUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppUserUpdate));
            bttnAppUserUpdate = new Button();
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
            txtPhoneNumber = new TextBox();
            label5 = new Label();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label3 = new Label();
            txtPassword = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panelBottom = new System.Windows.Forms.Panel();
            label4 = new Label();
            panelMid = new System.Windows.Forms.Panel();
            checkBoxPasswordReset = new CheckBox();
            cmbBoxAppUserSelect = new ComboBox();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // bttnAppUserUpdate
            // 
            bttnAppUserUpdate.Dock = DockStyle.Right;
            bttnAppUserUpdate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAppUserUpdate.Image = (Image)resources.GetObject("bttnAppUserUpdate.Image");
            bttnAppUserUpdate.ImageAlign = ContentAlignment.MiddleLeft;
            bttnAppUserUpdate.Location = new Point(111, 0);
            bttnAppUserUpdate.Name = "bttnAppUserUpdate";
            bttnAppUserUpdate.Size = new Size(123, 41);
            bttnAppUserUpdate.TabIndex = 0;
            bttnAppUserUpdate.Text = "Güncelle";
            bttnAppUserUpdate.UseVisualStyleBackColor = true;
            bttnAppUserUpdate.Click += bttnAppUserUpdate_Click;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(13, 423);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(214, 23);
            txtCity.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(13, 405);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 16;
            label10.Text = "Şehir :";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(13, 466);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(214, 136);
            txtAddress.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 449);
            label9.Name = "label9";
            label9.Size = new Size(43, 15);
            label9.TabIndex = 16;
            label9.Text = "Adres :";
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(13, 378);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(214, 23);
            txtCountry.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(13, 360);
            label8.Name = "label8";
            label8.Size = new Size(36, 15);
            label8.TabIndex = 14;
            label8.Text = "Ülke :";
            // 
            // txtNationalNumber
            // 
            txtNationalNumber.Location = new Point(13, 329);
            txtNationalNumber.Name = "txtNationalNumber";
            txtNationalNumber.Size = new Size(214, 23);
            txtNationalNumber.TabIndex = 13;
            txtNationalNumber.KeyPress += txtNationalNumber_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 311);
            label7.Name = "label7";
            label7.Size = new Size(52, 15);
            label7.TabIndex = 12;
            label7.Text = "T.C. No :";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(13, 280);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(214, 23);
            txtEmail.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 262);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 10;
            label6.Text = "Email :";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(13, 230);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(214, 23);
            txtPhoneNumber.TabIndex = 9;
            txtPhoneNumber.KeyPress += txtPhoneNumber_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 212);
            label5.Name = "label5";
            label5.Size = new Size(105, 15);
            label5.TabIndex = 8;
            label5.Text = "Telefon Numarası :";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(13, 182);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(214, 23);
            txtLastName.TabIndex = 7;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(13, 134);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(214, 23);
            txtFirstName.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 116);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 4;
            label3.Text = "Ad :";
            // 
            // txtPassword
            // 
            txtPassword.Enabled = false;
            txtPassword.Location = new Point(13, 87);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(214, 23);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 69);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 2;
            label2.Text = "Şifre :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 21);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Kullanıcı Adı :";
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnAppUserUpdate);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 617);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(244, 41);
            panelBottom.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 164);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 6;
            label4.Text = "Soyad :";
            // 
            // panelMid
            // 
            panelMid.Controls.Add(checkBoxPasswordReset);
            panelMid.Controls.Add(cmbBoxAppUserSelect);
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
            panelMid.Controls.Add(txtPassword);
            panelMid.Controls.Add(label2);
            panelMid.Controls.Add(label1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(244, 658);
            panelMid.TabIndex = 3;
            // 
            // checkBoxPasswordReset
            // 
            checkBoxPasswordReset.AutoSize = true;
            checkBoxPasswordReset.Location = new Point(129, 68);
            checkBoxPasswordReset.Name = "checkBoxPasswordReset";
            checkBoxPasswordReset.Size = new Size(98, 19);
            checkBoxPasswordReset.TabIndex = 19;
            checkBoxPasswordReset.Text = "Şifre Güncelle";
            checkBoxPasswordReset.UseVisualStyleBackColor = true;
            checkBoxPasswordReset.CheckedChanged += checkBoxPasswordReset_CheckedChanged;
            // 
            // cmbBoxAppUserSelect
            // 
            cmbBoxAppUserSelect.FormattingEnabled = true;
            cmbBoxAppUserSelect.Location = new Point(13, 39);
            cmbBoxAppUserSelect.Name = "cmbBoxAppUserSelect";
            cmbBoxAppUserSelect.Size = new Size(214, 23);
            cmbBoxAppUserSelect.TabIndex = 18;
            // 
            // frmAppUserUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(244, 658);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmAppUserUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kullanıcı Güncelle";
            Load += frmAppUserUpdate_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button bttnAppUserUpdate;
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
        private TextBox txtPhoneNumber;
        private Label label5;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label3;
        private TextBox txtPassword;
        private Label label2;
        private Label label1;
        private System.Windows.Forms.Panel panelBottom;
        private Label label4;
        private System.Windows.Forms.Panel panelMid;
        private ComboBox cmbBoxAppUserSelect;
        private CheckBox checkBoxPasswordReset;
    }
}