namespace Krop.WinForms.Brands
{
    partial class frmBrandCart
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
            panelMid = new System.Windows.Forms.Panel();
            brandComboBoxControl = new UserControllers.Brands.BrandComboBoxControl();
            txtEmail = new TextBox();
            txtPhoneNumber = new TextBox();
            label3 = new Label();
            label2 = new Label();
            panelBottom = new System.Windows.Forms.Panel();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelMid
            // 
            panelMid.Controls.Add(brandComboBoxControl);
            panelMid.Controls.Add(txtEmail);
            panelMid.Controls.Add(txtPhoneNumber);
            panelMid.Controls.Add(label3);
            panelMid.Controls.Add(label2);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(248, 172);
            panelMid.TabIndex = 5;
            // 
            // brandComboBoxControl
            // 
            brandComboBoxControl.Location = new Point(0, 3);
            brandComboBoxControl.Name = "brandComboBoxControl";
            brandComboBoxControl.Size = new Size(224, 65);
            brandComboBoxControl.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(15, 129);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(206, 23);
            txtEmail.TabIndex = 5;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Enabled = false;
            txtPhoneNumber.Location = new Point(15, 85);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.ReadOnly = true;
            txtPhoneNumber.Size = new Size(206, 23);
            txtPhoneNumber.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 111);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Email :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 67);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 1;
            label2.Text = "Telefon Numarası :";
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 172);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(248, 41);
            panelBottom.TabIndex = 4;
            // 
            // frmBrandCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(248, 213);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmBrandCart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marka Kartı";
            Load += frmBrandCart_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMid;
        private TextBox txtEmail;
        private TextBox txtPhoneNumber;
        private Label label3;
        private Label label2;
        private System.Windows.Forms.Panel panelBottom;
        private UserControllers.Brands.BrandComboBoxControl brandComboBoxControl;
    }
}