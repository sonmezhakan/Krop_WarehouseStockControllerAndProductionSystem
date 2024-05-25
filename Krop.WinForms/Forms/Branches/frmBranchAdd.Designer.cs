namespace Krop.WinForms.Forms.Branches
{
    partial class frmBranchAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBranchAdd));
            panelBottom = new System.Windows.Forms.Panel();
            bttnBranchAdd = new Button();
            panelMid = new System.Windows.Forms.Panel();
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
            label1 = new Label();
            txtBranchName = new TextBox();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnBranchAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 412);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(259, 41);
            panelBottom.TabIndex = 0;
            // 
            // bttnBranchAdd
            // 
            bttnBranchAdd.Dock = DockStyle.Right;
            bttnBranchAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnBranchAdd.Image = (Image)resources.GetObject("bttnBranchAdd.Image");
            bttnBranchAdd.Location = new Point(157, 0);
            bttnBranchAdd.Name = "bttnBranchAdd";
            bttnBranchAdd.Size = new Size(92, 41);
            bttnBranchAdd.TabIndex = 2;
            bttnBranchAdd.Text = "Ekle";
            bttnBranchAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnBranchAdd.UseVisualStyleBackColor = true;
            bttnBranchAdd.Click += bttnBranchAdd_Click;
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
            panelMid.Controls.Add(label1);
            panelMid.Controls.Add(txtBranchName);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(259, 412);
            panelMid.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 249);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 11;
            label6.Text = "Adres :";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(12, 267);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Adres...";
            txtAddress.Size = new Size(228, 139);
            txtAddress.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 202);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 9;
            label5.Text = "Şehir :";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(12, 220);
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "Şehir...";
            txtCity.Size = new Size(228, 23);
            txtCity.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 156);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 7;
            label4.Text = "Ülke :";
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(12, 174);
            txtCountry.Name = "txtCountry";
            txtCountry.PlaceholderText = "Ülke...";
            txtCountry.Size = new Size(228, 23);
            txtCountry.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 112);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 5;
            label3.Text = "Email :";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 130);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email...";
            txtEmail.Size = new Size(228, 23);
            txtEmail.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 3;
            label2.Text = "Telefon Numarası :";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(12, 82);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "Telefon Numarası...";
            txtPhoneNumber.Size = new Size(228, 23);
            txtPhoneNumber.TabIndex = 2;
            txtPhoneNumber.KeyPress += txtPhoneNumber_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 18);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 1;
            label1.Text = "Şube Adı :";
            // 
            // txtBranchName
            // 
            txtBranchName.Location = new Point(13, 36);
            txtBranchName.Name = "txtBranchName";
            txtBranchName.PlaceholderText = "Şube Adı...";
            txtBranchName.Size = new Size(228, 23);
            txtBranchName.TabIndex = 0;
            // 
            // frmBranchAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(259, 453);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmBranchAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Şube Ekle";
            Load += frmBranchAdd_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMid;
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
        private Label label1;
        private TextBox txtBranchName;
        private Button bttnBranchAdd;
    }
}