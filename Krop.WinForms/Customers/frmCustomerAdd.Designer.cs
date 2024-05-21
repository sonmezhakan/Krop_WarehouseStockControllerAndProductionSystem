namespace Krop.WinForms.Customers
{
    partial class frmCustomerAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerAdd));
            panelBottom = new System.Windows.Forms.Panel();
            bttnCustomerAdd = new Button();
            panelMid = new System.Windows.Forms.Panel();
            txtContactTitle = new TextBox();
            txtContactName = new TextBox();
            txtCompanyName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtPhoneNumber = new TextBox();
            label4 = new Label();
            txtAddress = new TextBox();
            label5 = new Label();
            txtCity = new TextBox();
            txtCountry = new TextBox();
            txtEmail = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            radioBttnPerson = new RadioButton();
            radioBttnCompany = new RadioButton();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnCustomerAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 472);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(251, 41);
            panelBottom.TabIndex = 2;
            // 
            // bttnCustomerAdd
            // 
            bttnCustomerAdd.Dock = DockStyle.Right;
            bttnCustomerAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnCustomerAdd.Image = (Image)resources.GetObject("bttnCustomerAdd.Image");
            bttnCustomerAdd.Location = new Point(147, 0);
            bttnCustomerAdd.Name = "bttnCustomerAdd";
            bttnCustomerAdd.Size = new Size(92, 39);
            bttnCustomerAdd.TabIndex = 1;
            bttnCustomerAdd.Text = "Ekle";
            bttnCustomerAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnCustomerAdd.UseVisualStyleBackColor = true;
            // 
            // panelMid
            // 
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
            panelMid.Controls.Add(txtCompanyName);
            panelMid.Controls.Add(label3);
            panelMid.Controls.Add(label2);
            panelMid.Controls.Add(label1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(251, 513);
            panelMid.TabIndex = 3;
            // 
            // txtContactTitle
            // 
            txtContactTitle.Location = new Point(23, 147);
            txtContactTitle.Name = "txtContactTitle";
            txtContactTitle.Size = new Size(206, 23);
            txtContactTitle.TabIndex = 5;
            // 
            // txtContactName
            // 
            txtContactName.Location = new Point(23, 103);
            txtContactName.Name = "txtContactName";
            txtContactName.Size = new Size(206, 23);
            txtContactName.TabIndex = 4;
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new Point(23, 59);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(206, 23);
            txtCompanyName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 129);
            label3.Name = "label3";
            label3.Size = new Size(213, 15);
            label3.TabIndex = 2;
            label3.Text = "İletişime Geçilecek Kişinin Departmanı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 85);
            label2.Name = "label2";
            label2.Size = new Size(131, 15);
            label2.TabIndex = 1;
            label2.Text = "İletişime Geçilecek Kişi :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 41);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 0;
            label1.Text = "Müşteri Adı :";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(23, 191);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(206, 23);
            txtPhoneNumber.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 173);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 6;
            label4.Text = "Telefon Numarası :";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(23, 369);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(206, 97);
            txtAddress.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 351);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 14;
            label5.Text = "Adres :";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(23, 325);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(206, 23);
            txtCity.TabIndex = 13;
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(23, 281);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(206, 23);
            txtCountry.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(23, 237);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(206, 23);
            txtEmail.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 307);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 10;
            label6.Text = "Şehir :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 263);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 9;
            label7.Text = "Ülke :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 219);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 8;
            label8.Text = "Email :";
            // 
            // radioBttnPerson
            // 
            radioBttnPerson.AutoSize = true;
            radioBttnPerson.Location = new Point(23, 12);
            radioBttnPerson.Name = "radioBttnPerson";
            radioBttnPerson.Size = new Size(65, 19);
            radioBttnPerson.TabIndex = 16;
            radioBttnPerson.TabStop = true;
            radioBttnPerson.Text = "Bireysel";
            radioBttnPerson.UseVisualStyleBackColor = true;
            // 
            // radioBttnCompany
            // 
            radioBttnCompany.AutoSize = true;
            radioBttnCompany.Location = new Point(154, 12);
            radioBttnCompany.Name = "radioBttnCompany";
            radioBttnCompany.Size = new Size(75, 19);
            radioBttnCompany.TabIndex = 17;
            radioBttnCompany.TabStop = true;
            radioBttnCompany.Text = "Kurumsal";
            radioBttnCompany.UseVisualStyleBackColor = true;
            // 
            // frmCustomerAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 513);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCustomerAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Müşteri Ekle";
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private Button bttnCustomerAdd;
        private System.Windows.Forms.Panel panelMid;
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
        private TextBox txtCompanyName;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}