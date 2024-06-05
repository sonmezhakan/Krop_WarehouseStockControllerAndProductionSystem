namespace Krop.WinForms.Forms.Branches
{
    partial class frmBranchCart
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
            panelBottom = new System.Windows.Forms.Panel();
            panelMid = new System.Windows.Forms.Panel();
            branchComboBoxControl = new UserControllers.Branches.BranchComboBoxControl();
            label6 = new Label();
            txtAddress = new TextBox();
            label5 = new Label();
            txtCity = new TextBox();
            label4 = new Label();
            txtCountry = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            txtPhoneNumber = new TextBox();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 428);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(237, 41);
            panelBottom.TabIndex = 4;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(label6);
            panelMid.Controls.Add(txtAddress);
            panelMid.Controls.Add(label5);
            panelMid.Controls.Add(txtCity);
            panelMid.Controls.Add(label4);
            panelMid.Controls.Add(txtCountry);
            panelMid.Controls.Add(label3);
            panelMid.Controls.Add(txtEmail);
            panelMid.Controls.Add(label2);
            panelMid.Controls.Add(txtPhoneNumber);
            panelMid.Controls.Add(branchComboBoxControl);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(237, 469);
            panelMid.TabIndex = 5;
            // 
            // branchComboBoxControl
            // 
            branchComboBoxControl.Location = new Point(0, 6);
            branchComboBoxControl.Name = "branchComboBoxControl";
            branchComboBoxControl.Size = new Size(248, 54);
            branchComboBoxControl.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 244);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 34;
            label6.Text = "Adres :";
            // 
            // txtAddress
            // 
            txtAddress.Enabled = false;
            txtAddress.Location = new Point(15, 262);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Adres...";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(200, 139);
            txtAddress.TabIndex = 33;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 197);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 32;
            label5.Text = "Şehir :";
            // 
            // txtCity
            // 
            txtCity.Enabled = false;
            txtCity.Location = new Point(15, 215);
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "Şehir...";
            txtCity.ReadOnly = true;
            txtCity.Size = new Size(200, 23);
            txtCity.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 151);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 30;
            label4.Text = "Ülke :";
            // 
            // txtCountry
            // 
            txtCountry.Enabled = false;
            txtCountry.Location = new Point(15, 169);
            txtCountry.Name = "txtCountry";
            txtCountry.PlaceholderText = "Ülke...";
            txtCountry.ReadOnly = true;
            txtCountry.Size = new Size(200, 23);
            txtCountry.TabIndex = 29;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 107);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 28;
            label3.Text = "Email :";
            // 
            // txtEmail
            // 
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(15, 125);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email...";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 59);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 26;
            label2.Text = "Telefon Numarası :";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Enabled = false;
            txtPhoneNumber.Location = new Point(15, 77);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "Telefon Numarası...";
            txtPhoneNumber.ReadOnly = true;
            txtPhoneNumber.Size = new Size(200, 23);
            txtPhoneNumber.TabIndex = 25;
            // 
            // frmBranchCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(237, 469);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmBranchCart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Şube Kartı";
            Load += frmBranchCart_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMid;
        private UserControllers.Branches.BranchComboBoxControl branchComboBoxControl;
        private Label label6;
        private TextBox txtAddress;
        private Label label5;
        private TextBox txtCity;
        private Label label4;
        private TextBox txtCountry;
        private Label label3;
        private TextBox txtEmail;
        private Label label2;
        private TextBox txtPhoneNumber;
    }
}