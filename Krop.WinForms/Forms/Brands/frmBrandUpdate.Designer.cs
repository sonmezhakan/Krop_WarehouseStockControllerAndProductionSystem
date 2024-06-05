namespace Krop.WinForms.Brands
{
    partial class frmBrandUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrandUpdate));
            panelMid = new System.Windows.Forms.Panel();
            brandComboBoxControl = new UserControllers.Brands.BrandComboBoxControl();
            panelBottom = new System.Windows.Forms.Panel();
            bttnBrandUpdate = new Button();
            txtEmail = new TextBox();
            txtPhoneNumber = new TextBox();
            txtBrandName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelMid.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelMid
            // 
            panelMid.Controls.Add(txtEmail);
            panelMid.Controls.Add(txtPhoneNumber);
            panelMid.Controls.Add(txtBrandName);
            panelMid.Controls.Add(label3);
            panelMid.Controls.Add(label2);
            panelMid.Controls.Add(label1);
            panelMid.Controls.Add(brandComboBoxControl);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(233, 218);
            panelMid.TabIndex = 3;
            // 
            // brandComboBoxControl
            // 
            brandComboBoxControl.Location = new Point(0, 3);
            brandComboBoxControl.Name = "brandComboBoxControl";
            brandComboBoxControl.Size = new Size(224, 65);
            brandComboBoxControl.TabIndex = 7;
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnBrandUpdate);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 218);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(233, 41);
            panelBottom.TabIndex = 2;
            // 
            // bttnBrandUpdate
            // 
            bttnBrandUpdate.Dock = DockStyle.Right;
            bttnBrandUpdate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnBrandUpdate.Image = (Image)resources.GetObject("bttnBrandUpdate.Image");
            bttnBrandUpdate.Location = new Point(116, 0);
            bttnBrandUpdate.Name = "bttnBrandUpdate";
            bttnBrandUpdate.Size = new Size(105, 39);
            bttnBrandUpdate.TabIndex = 1;
            bttnBrandUpdate.Text = "Güncelle";
            bttnBrandUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnBrandUpdate.UseVisualStyleBackColor = true;
            bttnBrandUpdate.Click += bttnBrandUpdate_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(15, 166);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email...";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 13;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(15, 122);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "Telefon Numarası...";
            txtPhoneNumber.Size = new Size(200, 23);
            txtPhoneNumber.TabIndex = 12;
            // 
            // txtBrandName
            // 
            txtBrandName.Location = new Point(15, 78);
            txtBrandName.Name = "txtBrandName";
            txtBrandName.PlaceholderText = "Marka Adı...";
            txtBrandName.Size = new Size(200, 23);
            txtBrandName.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 148);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 10;
            label3.Text = "Email :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 104);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 9;
            label2.Text = "Telefon Numarası :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 60);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 8;
            label1.Text = "Marka Adı :";
            // 
            // frmBrandUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(233, 259);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmBrandUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marka Güncelle";
            Load += frmBrandUpdate_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnBrandUpdate;
        private UserControllers.Brands.BrandComboBoxControl brandComboBoxControl;
        private TextBox txtEmail;
        private TextBox txtPhoneNumber;
        private TextBox txtBrandName;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}