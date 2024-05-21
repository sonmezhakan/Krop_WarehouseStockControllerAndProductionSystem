namespace Krop.WinForms.Customers
{
    partial class frmCustomerUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerUpdate));
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
            txtCompanyName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            panelBottom = new System.Windows.Forms.Panel();
            bttnCustomerAdd = new Button();
            panelMid = new System.Windows.Forms.Panel();
            label1 = new Label();
            label9 = new Label();
            cmbBoxCustomerSelect = new ComboBox();
            bttnSelect = new Button();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // radioBttnCompany
            // 
            radioBttnCompany.AutoSize = true;
            radioBttnCompany.Location = new Point(181, 67);
            radioBttnCompany.Name = "radioBttnCompany";
            radioBttnCompany.Size = new Size(75, 19);
            radioBttnCompany.TabIndex = 17;
            radioBttnCompany.TabStop = true;
            radioBttnCompany.Text = "Kurumsal";
            radioBttnCompany.UseVisualStyleBackColor = true;
            // 
            // radioBttnPerson
            // 
            radioBttnPerson.AutoSize = true;
            radioBttnPerson.Location = new Point(32, 67);
            radioBttnPerson.Name = "radioBttnPerson";
            radioBttnPerson.Size = new Size(65, 19);
            radioBttnPerson.TabIndex = 16;
            radioBttnPerson.TabStop = true;
            radioBttnPerson.Text = "Bireysel";
            radioBttnPerson.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(23, 424);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(245, 97);
            txtAddress.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 406);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 14;
            label5.Text = "Adres :";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(23, 380);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(245, 23);
            txtCity.TabIndex = 13;
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(23, 336);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(245, 23);
            txtCountry.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(23, 292);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(245, 23);
            txtEmail.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 362);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 10;
            label6.Text = "Şehir :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 318);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 9;
            label7.Text = "Ülke :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 274);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 8;
            label8.Text = "Email :";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(23, 246);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(245, 23);
            txtPhoneNumber.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 228);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 6;
            label4.Text = "Telefon Numarası :";
            // 
            // txtContactTitle
            // 
            txtContactTitle.Location = new Point(23, 202);
            txtContactTitle.Name = "txtContactTitle";
            txtContactTitle.Size = new Size(245, 23);
            txtContactTitle.TabIndex = 5;
            // 
            // txtContactName
            // 
            txtContactName.Location = new Point(23, 158);
            txtContactName.Name = "txtContactName";
            txtContactName.Size = new Size(245, 23);
            txtContactName.TabIndex = 4;
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new Point(23, 114);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(245, 23);
            txtCompanyName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 184);
            label3.Name = "label3";
            label3.Size = new Size(213, 15);
            label3.TabIndex = 2;
            label3.Text = "İletişime Geçilecek Kişinin Departmanı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 140);
            label2.Name = "label2";
            label2.Size = new Size(131, 15);
            label2.TabIndex = 1;
            label2.Text = "İletişime Geçilecek Kişi :";
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnCustomerAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 544);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(318, 41);
            panelBottom.TabIndex = 4;
            // 
            // bttnCustomerAdd
            // 
            bttnCustomerAdd.Dock = DockStyle.Right;
            bttnCustomerAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnCustomerAdd.Image = (Image)resources.GetObject("bttnCustomerAdd.Image");
            bttnCustomerAdd.Location = new Point(197, 0);
            bttnCustomerAdd.Name = "bttnCustomerAdd";
            bttnCustomerAdd.Size = new Size(109, 39);
            bttnCustomerAdd.TabIndex = 1;
            bttnCustomerAdd.Text = "Güncelle";
            bttnCustomerAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnCustomerAdd.UseVisualStyleBackColor = true;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(bttnSelect);
            panelMid.Controls.Add(cmbBoxCustomerSelect);
            panelMid.Controls.Add(label9);
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
            panelMid.Size = new Size(318, 585);
            panelMid.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 96);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 0;
            label1.Text = "Müşteri Adı :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 20);
            label9.Name = "label9";
            label9.Size = new Size(245, 15);
            label9.TabIndex = 18;
            label9.Text = "Güncellenecek Müşterinin Telefon Numarası :";
            // 
            // cmbBoxCustomerSelect
            // 
            cmbBoxCustomerSelect.FormattingEnabled = true;
            cmbBoxCustomerSelect.Location = new Point(21, 38);
            cmbBoxCustomerSelect.Name = "cmbBoxCustomerSelect";
            cmbBoxCustomerSelect.Size = new Size(245, 23);
            cmbBoxCustomerSelect.TabIndex = 19;
            // 
            // bttnSelect
            // 
            bttnSelect.Location = new Point(272, 38);
            bttnSelect.Name = "bttnSelect";
            bttnSelect.Size = new Size(31, 23);
            bttnSelect.TabIndex = 21;
            bttnSelect.Text = "...";
            bttnSelect.UseVisualStyleBackColor = true;
            // 
            // frmCustomerUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 585);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCustomerUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Müşteri Güncelle";
            panelBottom.ResumeLayout(false);
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
        private TextBox txtCompanyName;
        private Label label3;
        private Label label2;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnCustomerAdd;
        private System.Windows.Forms.Panel panelMid;
        private ComboBox cmbBoxCustomerSelect;
        private Label label9;
        private Label label1;
        private Button bttnSelect;
    }
}