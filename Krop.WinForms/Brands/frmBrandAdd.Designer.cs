namespace Krop.WinForms.Brands
{
    partial class frmBrandAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrandAdd));
            panelBottom = new System.Windows.Forms.Panel();
            panelMid = new System.Windows.Forms.Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtBrandName = new TextBox();
            txtPhoneNumber = new TextBox();
            txtEmail = new TextBox();
            bttnBrandAdd = new Button();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnBrandAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 181);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(240, 41);
            panelBottom.TabIndex = 0;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(txtEmail);
            panelMid.Controls.Add(txtPhoneNumber);
            panelMid.Controls.Add(txtBrandName);
            panelMid.Controls.Add(label3);
            panelMid.Controls.Add(label2);
            panelMid.Controls.Add(label1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(240, 181);
            panelMid.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 0;
            label1.Text = "Marka Adı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 1;
            label2.Text = "Telefon Numarası :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 106);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Email :";
            // 
            // txtBrandName
            // 
            txtBrandName.Location = new Point(12, 36);
            txtBrandName.Name = "txtBrandName";
            txtBrandName.Size = new Size(206, 23);
            txtBrandName.TabIndex = 3;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(12, 80);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(206, 23);
            txtPhoneNumber.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 124);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(206, 23);
            txtEmail.TabIndex = 5;
            // 
            // bttnBrandAdd
            // 
            bttnBrandAdd.Dock = DockStyle.Right;
            bttnBrandAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnBrandAdd.Image = (Image)resources.GetObject("bttnBrandAdd.Image");
            bttnBrandAdd.Location = new Point(138, 0);
            bttnBrandAdd.Name = "bttnBrandAdd";
            bttnBrandAdd.Size = new Size(92, 41);
            bttnBrandAdd.TabIndex = 1;
            bttnBrandAdd.Text = "Ekle";
            bttnBrandAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnBrandAdd.UseVisualStyleBackColor = true;
            // 
            // frmBrandAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(240, 222);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmBrandAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marka Ekle";
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMid;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtEmail;
        private TextBox txtPhoneNumber;
        private TextBox txtBrandName;
        private Button bttnBrandAdd;
    }
}