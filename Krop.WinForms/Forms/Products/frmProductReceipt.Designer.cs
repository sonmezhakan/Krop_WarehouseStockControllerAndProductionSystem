namespace Krop.WinForms.Products
{
    partial class frmProductReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductReceipt));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelBottom = new System.Windows.Forms.Panel();
            bttnAdd = new Button();
            bttnUpdate = new Button();
            bttnDelete = new Button();
            panel2 = new System.Windows.Forms.Panel();
            panelMidMid = new System.Windows.Forms.Panel();
            dgwProductReceiptList = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            panelTop = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            bttnSearch = new Button();
            panelMidLeft = new System.Windows.Forms.Panel();
            bttnSelect = new Button();
            label6 = new Label();
            label5 = new Label();
            txtQuantity = new TextBox();
            cmbBoxProductCodeSelect = new ComboBox();
            label3 = new Label();
            cmbBoxProductNameSelect = new ComboBox();
            label4 = new Label();
            cmbBoxProductCode = new ComboBox();
            label2 = new Label();
            cmbBoxProductName = new ComboBox();
            label1 = new Label();
            panelBottom.SuspendLayout();
            panel2.SuspendLayout();
            panelMidMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwProductReceiptList).BeginInit();
            panelTop.SuspendLayout();
            panelMidLeft.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnAdd);
            panelBottom.Controls.Add(bttnUpdate);
            panelBottom.Controls.Add(bttnDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 502);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1095, 41);
            panelBottom.TabIndex = 0;
            // 
            // bttnAdd
            // 
            bttnAdd.Dock = DockStyle.Right;
            bttnAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAdd.Image = (Image)resources.GetObject("bttnAdd.Image");
            bttnAdd.Location = new Point(803, 0);
            bttnAdd.Name = "bttnAdd";
            bttnAdd.Size = new Size(92, 39);
            bttnAdd.TabIndex = 3;
            bttnAdd.Text = "Ekle";
            bttnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnAdd.UseVisualStyleBackColor = true;
            // 
            // bttnUpdate
            // 
            bttnUpdate.Dock = DockStyle.Right;
            bttnUpdate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnUpdate.Image = (Image)resources.GetObject("bttnUpdate.Image");
            bttnUpdate.Location = new Point(895, 0);
            bttnUpdate.Name = "bttnUpdate";
            bttnUpdate.Size = new Size(106, 39);
            bttnUpdate.TabIndex = 2;
            bttnUpdate.Text = "Güncelle";
            bttnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnUpdate.UseVisualStyleBackColor = true;
            // 
            // bttnDelete
            // 
            bttnDelete.Dock = DockStyle.Right;
            bttnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnDelete.Image = (Image)resources.GetObject("bttnDelete.Image");
            bttnDelete.Location = new Point(1001, 0);
            bttnDelete.Name = "bttnDelete";
            bttnDelete.Size = new Size(92, 39);
            bttnDelete.TabIndex = 1;
            bttnDelete.Text = "Sil";
            bttnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnDelete.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(panelMidMid);
            panel2.Controls.Add(panelTop);
            panel2.Controls.Add(panelMidLeft);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(1095, 502);
            panel2.TabIndex = 1;
            // 
            // panelMidMid
            // 
            panelMidMid.Controls.Add(dgwProductReceiptList);
            panelMidMid.Dock = DockStyle.Fill;
            panelMidMid.Location = new Point(256, 43);
            panelMidMid.Name = "panelMidMid";
            panelMidMid.Padding = new Padding(5);
            panelMidMid.Size = new Size(834, 454);
            panelMidMid.TabIndex = 7;
            // 
            // dgwProductReceiptList
            // 
            dgwProductReceiptList.AllowUserToAddRows = false;
            dgwProductReceiptList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwProductReceiptList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwProductReceiptList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwProductReceiptList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwProductReceiptList.BackgroundColor = SystemColors.Control;
            dgwProductReceiptList.BorderStyle = BorderStyle.None;
            dgwProductReceiptList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductReceiptList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwProductReceiptList.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dgwProductReceiptList.Dock = DockStyle.Fill;
            dgwProductReceiptList.Location = new Point(5, 5);
            dgwProductReceiptList.Name = "dgwProductReceiptList";
            dgwProductReceiptList.ReadOnly = true;
            dgwProductReceiptList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductReceiptList.RowTemplate.Height = 25;
            dgwProductReceiptList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwProductReceiptList.Size = new Size(824, 444);
            dgwProductReceiptList.TabIndex = 9;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Column3";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Column4";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.HeaderText = "Column5";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(bttnSearch);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(256, 5);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(5);
            panelTop.Size = new Size(834, 38);
            panelTop.TabIndex = 6;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(749, 27);
            txtSearch.TabIndex = 2;
            txtSearch.Text = "Arama....";
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(754, 5);
            bttnSearch.Name = "bttnSearch";
            bttnSearch.Size = new Size(75, 28);
            bttnSearch.TabIndex = 1;
            bttnSearch.Text = "Ara...";
            bttnSearch.UseVisualStyleBackColor = true;
            // 
            // panelMidLeft
            // 
            panelMidLeft.Controls.Add(bttnSelect);
            panelMidLeft.Controls.Add(label6);
            panelMidLeft.Controls.Add(label5);
            panelMidLeft.Controls.Add(txtQuantity);
            panelMidLeft.Controls.Add(cmbBoxProductCodeSelect);
            panelMidLeft.Controls.Add(label3);
            panelMidLeft.Controls.Add(cmbBoxProductNameSelect);
            panelMidLeft.Controls.Add(label4);
            panelMidLeft.Controls.Add(cmbBoxProductCode);
            panelMidLeft.Controls.Add(label2);
            panelMidLeft.Controls.Add(cmbBoxProductName);
            panelMidLeft.Controls.Add(label1);
            panelMidLeft.Dock = DockStyle.Left;
            panelMidLeft.Location = new Point(5, 5);
            panelMidLeft.Name = "panelMidLeft";
            panelMidLeft.Padding = new Padding(10);
            panelMidLeft.Size = new Size(251, 492);
            panelMidLeft.TabIndex = 0;
            // 
            // bttnSelect
            // 
            bttnSelect.Location = new Point(208, 38);
            bttnSelect.Name = "bttnSelect";
            bttnSelect.Size = new Size(31, 23);
            bttnSelect.TabIndex = 22;
            bttnSelect.Text = "...";
            bttnSelect.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(170, 230);
            label6.Name = "label6";
            label6.Size = new Size(32, 15);
            label6.TabIndex = 21;
            label6.Text = "Adet";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 209);
            label5.Name = "label5";
            label5.Size = new Size(113, 15);
            label5.TabIndex = 20;
            label5.Text = "Kullanılacak Miktar :";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(13, 227);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(151, 23);
            txtQuantity.TabIndex = 19;
            // 
            // cmbBoxProductCodeSelect
            // 
            cmbBoxProductCodeSelect.FormattingEnabled = true;
            cmbBoxProductCodeSelect.Location = new Point(13, 183);
            cmbBoxProductCodeSelect.Name = "cmbBoxProductCodeSelect";
            cmbBoxProductCodeSelect.Size = new Size(189, 23);
            cmbBoxProductCodeSelect.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 165);
            label3.Name = "label3";
            label3.Size = new Size(175, 15);
            label3.TabIndex = 17;
            label3.Text = "Reçeteye Eklenecek Ürün Kodu :";
            // 
            // cmbBoxProductNameSelect
            // 
            cmbBoxProductNameSelect.FormattingEnabled = true;
            cmbBoxProductNameSelect.Location = new Point(13, 138);
            cmbBoxProductNameSelect.Name = "cmbBoxProductNameSelect";
            cmbBoxProductNameSelect.Size = new Size(189, 23);
            cmbBoxProductNameSelect.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 120);
            label4.Name = "label4";
            label4.Size = new Size(165, 15);
            label4.TabIndex = 15;
            label4.Text = "Reçeteye Eklenecek Ürün Adı :";
            // 
            // cmbBoxProductCode
            // 
            cmbBoxProductCode.FormattingEnabled = true;
            cmbBoxProductCode.Location = new Point(13, 84);
            cmbBoxProductCode.Name = "cmbBoxProductCode";
            cmbBoxProductCode.Size = new Size(189, 23);
            cmbBoxProductCode.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 66);
            label2.Name = "label2";
            label2.Size = new Size(192, 15);
            label2.TabIndex = 13;
            label2.Text = "Reçetesi Düzenlenecek Ürün Kodu :";
            // 
            // cmbBoxProductName
            // 
            cmbBoxProductName.FormattingEnabled = true;
            cmbBoxProductName.Location = new Point(13, 39);
            cmbBoxProductName.Name = "cmbBoxProductName";
            cmbBoxProductName.Size = new Size(189, 23);
            cmbBoxProductName.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 21);
            label1.Name = "label1";
            label1.Size = new Size(182, 15);
            label1.TabIndex = 11;
            label1.Text = "Reçetesi Düzenlenecek Ürün Adı :";
            // 
            // frmProductReceipt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 543);
            Controls.Add(panel2);
            Controls.Add(panelBottom);
            Name = "frmProductReceipt";
            Text = "Ürün Reçetesi";
            panelBottom.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panelMidMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwProductReceiptList).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMidLeft.ResumeLayout(false);
            panelMidLeft.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMidLeft;
        private Label label6;
        private Label label5;
        private TextBox txtQuantity;
        private ComboBox cmbBoxProductCodeSelect;
        private Label label3;
        private ComboBox cmbBoxProductNameSelect;
        private Label label4;
        private ComboBox cmbBoxProductCode;
        private Label label2;
        private ComboBox cmbBoxProductName;
        private Label label1;
        private System.Windows.Forms.Panel panelTop;
        private TextBox txtSearch;
        private Button bttnSearch;
        private Button bttnAdd;
        private Button bttnUpdate;
        private Button bttnDelete;
        private System.Windows.Forms.Panel panelMidMid;
        private DataGridView dgwProductReceiptList;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Button bttnSelect;
    }
}