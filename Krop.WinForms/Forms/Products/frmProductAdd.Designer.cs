namespace Krop.WinForms.Products
{
    partial class frmProductAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductAdd));
            panelBottom = new System.Windows.Forms.Panel();
            bttnProductAdd = new Button();
            panelMid = new System.Windows.Forms.Panel();
            panelMidMid = new System.Windows.Forms.Panel();
            brandComboBoxControl1 = new UserControllers.Brands.BrandComboBoxControl();
            categoryComboBoxControl1 = new UserControllers.Categories.CategoryComboBoxControl();
            label9 = new Label();
            label8 = new Label();
            txtDescription = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label1 = new Label();
            txtCriticalQuantity = new TextBox();
            txtUnitPrice = new TextBox();
            txtProductCode = new TextBox();
            txtProductName = new TextBox();
            panelMidLeft = new System.Windows.Forms.Panel();
            pBoxProductImage = new PictureBox();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            panelMidMid.SuspendLayout();
            panelMidLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pBoxProductImage).BeginInit();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnProductAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 479);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 15, 0);
            panelBottom.Size = new Size(457, 41);
            panelBottom.TabIndex = 0;
            // 
            // bttnProductAdd
            // 
            bttnProductAdd.Dock = DockStyle.Right;
            bttnProductAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnProductAdd.Image = (Image)resources.GetObject("bttnProductAdd.Image");
            bttnProductAdd.Location = new Point(348, 0);
            bttnProductAdd.Name = "bttnProductAdd";
            bttnProductAdd.Size = new Size(92, 39);
            bttnProductAdd.TabIndex = 0;
            bttnProductAdd.Text = "Ekle";
            bttnProductAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnProductAdd.UseVisualStyleBackColor = true;
            bttnProductAdd.Click += bttnProductAdd_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(panelMidMid);
            panelMid.Controls.Add(panelMidLeft);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(457, 479);
            panelMid.TabIndex = 1;
            // 
            // panelMidMid
            // 
            panelMidMid.Controls.Add(brandComboBoxControl1);
            panelMidMid.Controls.Add(categoryComboBoxControl1);
            panelMidMid.Controls.Add(label9);
            panelMidMid.Controls.Add(label8);
            panelMidMid.Controls.Add(txtDescription);
            panelMidMid.Controls.Add(label7);
            panelMidMid.Controls.Add(label6);
            panelMidMid.Controls.Add(label5);
            panelMidMid.Controls.Add(label3);
            panelMidMid.Controls.Add(label1);
            panelMidMid.Controls.Add(txtCriticalQuantity);
            panelMidMid.Controls.Add(txtUnitPrice);
            panelMidMid.Controls.Add(txtProductCode);
            panelMidMid.Controls.Add(txtProductName);
            panelMidMid.Dock = DockStyle.Fill;
            panelMidMid.Location = new Point(221, 0);
            panelMidMid.Name = "panelMidMid";
            panelMidMid.Size = new Size(236, 479);
            panelMidMid.TabIndex = 1;
            // 
            // brandComboBoxControl1
            // 
            brandComboBoxControl1.Location = new Point(0, 152);
            brandComboBoxControl1.Name = "brandComboBoxControl1";
            brandComboBoxControl1.Size = new Size(224, 51);
            brandComboBoxControl1.TabIndex = 35;
            // 
            // categoryComboBoxControl1
            // 
            categoryComboBoxControl1.Location = new Point(0, 104);
            categoryComboBoxControl1.Name = "categoryComboBoxControl1";
            categoryComboBoxControl1.Size = new Size(225, 48);
            categoryComboBoxControl1.TabIndex = 34;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(180, 271);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 33;
            label9.Text = "Adet";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(180, 227);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 32;
            label8.Text = "₺";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(15, 307);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Açıklama...";
            txtDescription.Size = new Size(200, 136);
            txtDescription.TabIndex = 29;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 289);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 26;
            label7.Text = "Açıklama :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 201);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 25;
            label6.Text = "Ürün Fiyatı :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 245);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 24;
            label5.Text = "Kritik Miktar :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 62);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 22;
            label3.Text = "Ürün Kodu :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 18);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 20;
            label1.Text = "Ürün Adı :";
            // 
            // txtCriticalQuantity
            // 
            txtCriticalQuantity.Location = new Point(15, 263);
            txtCriticalQuantity.Name = "txtCriticalQuantity";
            txtCriticalQuantity.PlaceholderText = "0";
            txtCriticalQuantity.Size = new Size(159, 23);
            txtCriticalQuantity.TabIndex = 19;
            txtCriticalQuantity.Text = "0";
            txtCriticalQuantity.KeyPress += txtCriticalQuantity_KeyPress;
            txtCriticalQuantity.Validating += txtCriticalQuantity_Validating;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(15, 219);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.PlaceholderText = "0.00";
            txtUnitPrice.Size = new Size(159, 23);
            txtUnitPrice.TabIndex = 18;
            txtUnitPrice.Text = "0";
            txtUnitPrice.KeyPress += txtUnitPrice_KeyPress;
            txtUnitPrice.Validating += txtUnitPrice_Validating;
            // 
            // txtProductCode
            // 
            txtProductCode.Location = new Point(15, 80);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.PlaceholderText = "Ürün Kodu...";
            txtProductCode.Size = new Size(200, 23);
            txtProductCode.TabIndex = 15;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(15, 36);
            txtProductName.Name = "txtProductName";
            txtProductName.PlaceholderText = "Ürün Adı...";
            txtProductName.Size = new Size(200, 23);
            txtProductName.TabIndex = 14;
            // 
            // panelMidLeft
            // 
            panelMidLeft.Controls.Add(pBoxProductImage);
            panelMidLeft.Dock = DockStyle.Left;
            panelMidLeft.Location = new Point(0, 0);
            panelMidLeft.Name = "panelMidLeft";
            panelMidLeft.Padding = new Padding(5, 20, 5, 5);
            panelMidLeft.Size = new Size(221, 479);
            panelMidLeft.TabIndex = 0;
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
            // frmProductAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 520);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmProductAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ürün Ekle";
            Load += frmProductAdd_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMidMid.ResumeLayout(false);
            panelMidMid.PerformLayout();
            panelMidLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pBoxProductImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panelMidMid;
        private System.Windows.Forms.Panel panelMidLeft;
        private Button bttnProductAdd;
        private TextBox txtCriticalQuantity;
        private TextBox txtUnitPrice;
        private TextBox txtProductCode;
        private TextBox txtProductName;
        private PictureBox pBoxProductImage;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label1;
        private TextBox txtDescription;
        private Label label7;
        private Label label9;
        private Label label8;
        private UserControllers.Brands.BrandComboBoxControl brandComboBoxControl1;
        private UserControllers.Categories.CategoryComboBoxControl categoryComboBoxControl1;
    }
}