namespace Krop.WinForms.Products
{
    partial class frmProductCart
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
            pBoxProductImage = new PictureBox();
            panelMidLeft = new System.Windows.Forms.Panel();
            label9 = new Label();
            label8 = new Label();
            txtDescription = new TextBox();
            label7 = new Label();
            label6 = new Label();
            panelMid = new System.Windows.Forms.Panel();
            panelMidMid = new System.Windows.Forms.Panel();
            cmbBoxProductCodeSelect = new ComboBox();
            label11 = new Label();
            cmbBoxProductNameSelect = new ComboBox();
            label10 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            txtCriticalQuantity = new TextBox();
            txtUnitPrice = new TextBox();
            panelBottom = new System.Windows.Forms.Panel();
            txtCategoryName = new TextBox();
            txtBrandName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pBoxProductImage).BeginInit();
            panelMidLeft.SuspendLayout();
            panelMid.SuspendLayout();
            panelMidMid.SuspendLayout();
            SuspendLayout();
            // 
            // pBoxProductImage
            // 
            pBoxProductImage.Dock = DockStyle.Top;
            pBoxProductImage.Location = new Point(5, 20);
            pBoxProductImage.Name = "pBoxProductImage";
            pBoxProductImage.Padding = new Padding(5, 20, 5, 5);
            pBoxProductImage.Size = new Size(211, 193);
            pBoxProductImage.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxProductImage.TabIndex = 20;
            pBoxProductImage.TabStop = false;
            // 
            // panelMidLeft
            // 
            panelMidLeft.Controls.Add(pBoxProductImage);
            panelMidLeft.Dock = DockStyle.Left;
            panelMidLeft.Location = new Point(0, 0);
            panelMidLeft.Name = "panelMidLeft";
            panelMidLeft.Padding = new Padding(5, 20, 5, 5);
            panelMidLeft.Size = new Size(221, 460);
            panelMidLeft.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(202, 263);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 33;
            label9.Text = "Adet";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(205, 219);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 32;
            label8.Text = "₺";
            // 
            // txtDescription
            // 
            txtDescription.Enabled = false;
            txtDescription.Location = new Point(17, 304);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(217, 136);
            txtDescription.TabIndex = 29;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 286);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 26;
            label7.Text = "Açıklama :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 198);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 25;
            label6.Text = "Ürün Fiyatı :";
            // 
            // panelMid
            // 
            panelMid.Controls.Add(panelMidMid);
            panelMid.Controls.Add(panelMidLeft);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(474, 460);
            panelMid.TabIndex = 3;
            // 
            // panelMidMid
            // 
            panelMidMid.Controls.Add(txtBrandName);
            panelMidMid.Controls.Add(txtCategoryName);
            panelMidMid.Controls.Add(cmbBoxProductCodeSelect);
            panelMidMid.Controls.Add(label11);
            panelMidMid.Controls.Add(cmbBoxProductNameSelect);
            panelMidMid.Controls.Add(label10);
            panelMidMid.Controls.Add(label9);
            panelMidMid.Controls.Add(label8);
            panelMidMid.Controls.Add(txtDescription);
            panelMidMid.Controls.Add(label7);
            panelMidMid.Controls.Add(label6);
            panelMidMid.Controls.Add(label5);
            panelMidMid.Controls.Add(label4);
            panelMidMid.Controls.Add(label2);
            panelMidMid.Controls.Add(txtCriticalQuantity);
            panelMidMid.Controls.Add(txtUnitPrice);
            panelMidMid.Dock = DockStyle.Fill;
            panelMidMid.Location = new Point(221, 0);
            panelMidMid.Name = "panelMidMid";
            panelMidMid.Size = new Size(253, 460);
            panelMidMid.TabIndex = 1;
            // 
            // cmbBoxProductCodeSelect
            // 
            cmbBoxProductCodeSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxProductCodeSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxProductCodeSelect.FormattingEnabled = true;
            cmbBoxProductCodeSelect.Location = new Point(17, 83);
            cmbBoxProductCodeSelect.Name = "cmbBoxProductCodeSelect";
            cmbBoxProductCodeSelect.Size = new Size(217, 23);
            cmbBoxProductCodeSelect.TabIndex = 41;
            cmbBoxProductCodeSelect.SelectedIndexChanged += cmbBoxProductCodeSelect_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(17, 65);
            label11.Name = "label11";
            label11.Size = new Size(70, 15);
            label11.TabIndex = 40;
            label11.Text = "Ürün Kodu :";
            // 
            // cmbBoxProductNameSelect
            // 
            cmbBoxProductNameSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxProductNameSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxProductNameSelect.FormattingEnabled = true;
            cmbBoxProductNameSelect.Location = new Point(17, 38);
            cmbBoxProductNameSelect.Name = "cmbBoxProductNameSelect";
            cmbBoxProductNameSelect.Size = new Size(217, 23);
            cmbBoxProductNameSelect.TabIndex = 39;
            cmbBoxProductNameSelect.SelectedIndexChanged += cmbBoxProductNameSelect_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(17, 20);
            label10.Name = "label10";
            label10.Size = new Size(60, 15);
            label10.TabIndex = 38;
            label10.Text = "Ürün Adı :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 242);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 24;
            label5.Text = "Kritik Miktar :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 152);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 23;
            label4.Text = "Marka :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 106);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 21;
            label2.Text = "Kategori :";
            // 
            // txtCriticalQuantity
            // 
            txtCriticalQuantity.Enabled = false;
            txtCriticalQuantity.Location = new Point(17, 260);
            txtCriticalQuantity.Name = "txtCriticalQuantity";
            txtCriticalQuantity.ReadOnly = true;
            txtCriticalQuantity.Size = new Size(182, 23);
            txtCriticalQuantity.TabIndex = 19;
            txtCriticalQuantity.Text = "0";
            txtCriticalQuantity.KeyPress += txtCriticalQuantity_KeyPress;
            txtCriticalQuantity.Validating += txtCriticalQuantity_Validating;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Enabled = false;
            txtUnitPrice.Location = new Point(17, 216);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.ReadOnly = true;
            txtUnitPrice.Size = new Size(182, 23);
            txtUnitPrice.TabIndex = 18;
            txtUnitPrice.Text = "0";
            txtUnitPrice.KeyPress += txtUnitPrice_KeyPress;
            txtUnitPrice.Validating += txtUnitPrice_Validating;
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 460);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 15, 0);
            panelBottom.Size = new Size(474, 41);
            panelBottom.TabIndex = 2;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Enabled = false;
            txtCategoryName.Location = new Point(17, 124);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.ReadOnly = true;
            txtCategoryName.Size = new Size(217, 23);
            txtCategoryName.TabIndex = 42;
            // 
            // txtBrandName
            // 
            txtBrandName.Enabled = false;
            txtBrandName.Location = new Point(17, 170);
            txtBrandName.Name = "txtBrandName";
            txtBrandName.ReadOnly = true;
            txtBrandName.Size = new Size(217, 23);
            txtBrandName.TabIndex = 43;
            // 
            // frmProductCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 501);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmProductCart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ürün Kartı";
            Load += frmProductCart_Load;
            ((System.ComponentModel.ISupportInitialize)pBoxProductImage).EndInit();
            panelMidLeft.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMidMid.ResumeLayout(false);
            panelMidMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pBoxProductImage;
        private System.Windows.Forms.Panel panelMidLeft;
        private Label label9;
        private Label label8;
        private TextBox txtDescription;
        private Label label7;
        private Label label6;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panelMidMid;
        private Label label5;
        private Label label4;
        private Label label2;
        private TextBox txtCriticalQuantity;
        private TextBox txtUnitPrice;
        private System.Windows.Forms.Panel panelBottom;
        private ComboBox cmbBoxProductCodeSelect;
        private Label label11;
        private ComboBox cmbBoxProductNameSelect;
        private Label label10;
        private TextBox txtBrandName;
        private TextBox txtCategoryName;
    }
}