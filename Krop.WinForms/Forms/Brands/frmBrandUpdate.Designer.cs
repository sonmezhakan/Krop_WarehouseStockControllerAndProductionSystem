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
            cmbBoxBrandSelect = new ComboBox();
            label4 = new Label();
            txtEmail = new TextBox();
            txtPhoneNumber = new TextBox();
            txtBrandName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelBottom = new System.Windows.Forms.Panel();
            bttnBrandUpdate = new Button();
            panelMid.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelMid
            // 
            panelMid.Controls.Add(cmbBoxBrandSelect);
            panelMid.Controls.Add(label4);
            panelMid.Controls.Add(txtEmail);
            panelMid.Controls.Add(txtPhoneNumber);
            panelMid.Controls.Add(txtBrandName);
            panelMid.Controls.Add(label3);
            panelMid.Controls.Add(label2);
            panelMid.Controls.Add(label1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(233, 218);
            panelMid.TabIndex = 3;
            // 
            // cmbBoxBrandSelect
            // 
            cmbBoxBrandSelect.FormattingEnabled = true;
            cmbBoxBrandSelect.Location = new Point(12, 41);
            cmbBoxBrandSelect.Name = "cmbBoxBrandSelect";
            cmbBoxBrandSelect.Size = new Size(206, 23);
            cmbBoxBrandSelect.TabIndex = 7;
            cmbBoxBrandSelect.SelectedIndexChanged += cmbBoxBrandSelect_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 23);
            label4.Name = "label4";
            label4.Size = new Size(126, 15);
            label4.TabIndex = 6;
            label4.Text = "Güncellenecek Marka :";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 173);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(206, 23);
            txtEmail.TabIndex = 5;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(12, 129);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(206, 23);
            txtPhoneNumber.TabIndex = 4;
            // 
            // txtBrandName
            // 
            txtBrandName.Location = new Point(12, 85);
            txtBrandName.Name = "txtBrandName";
            txtBrandName.Size = new Size(206, 23);
            txtBrandName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 155);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Email :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 111);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 1;
            label2.Text = "Telefon Numarası :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 67);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 0;
            label1.Text = "Marka Adı :";
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
        private ComboBox cmbBoxBrandSelect;
        private Label label4;
        private TextBox txtEmail;
        private TextBox txtPhoneNumber;
        private TextBox txtBrandName;
        private Label label3;
        private Label label2;
        private Label label1;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnBrandUpdate;
    }
}