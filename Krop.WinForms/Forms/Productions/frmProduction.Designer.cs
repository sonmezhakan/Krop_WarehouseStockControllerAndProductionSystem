namespace Krop.WinForms.Forms.Productions
{
    partial class frmProduction
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduction));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelBottom = new System.Windows.Forms.Panel();
            dgwProductionList = new DataGridView();
            panel1 = new System.Windows.Forms.Panel();
            txtProductionSearch = new TextBox();
            bttnProductionSearch = new Button();
            panelBottomBottom = new System.Windows.Forms.Panel();
            bttnAdd = new Button();
            bttnUpdate = new Button();
            bttnDelete = new Button();
            panelLeft = new System.Windows.Forms.Panel();
            txtDescription = new TextBox();
            label7 = new Label();
            label6 = new Label();
            productionDateTimePicker = new DateTimePicker();
            label5 = new Label();
            txtProductionQuantity = new TextBox();
            label4 = new Label();
            cmbBoxProductCode = new ComboBox();
            label3 = new Label();
            cmbBoxProductName = new ComboBox();
            label2 = new Label();
            cmbBoxBranch = new ComboBox();
            label1 = new Label();
            panelMid = new System.Windows.Forms.Panel();
            dgwProductReceiptList = new DataGridView();
            panelTop = new System.Windows.Forms.Panel();
            txtProductReceiptSearch = new TextBox();
            bttnProductReceiptSearch = new Button();
            panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwProductionList).BeginInit();
            panel1.SuspendLayout();
            panelBottomBottom.SuspendLayout();
            panelLeft.SuspendLayout();
            panelMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwProductReceiptList).BeginInit();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(dgwProductionList);
            panelBottom.Controls.Add(panel1);
            panelBottom.Controls.Add(panelBottomBottom);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 383);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(10, 10, 10, 0);
            panelBottom.Size = new Size(1264, 298);
            panelBottom.TabIndex = 0;
            // 
            // dgwProductionList
            // 
            dgwProductionList.AllowUserToAddRows = false;
            dgwProductionList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwProductionList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwProductionList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwProductionList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwProductionList.BackgroundColor = SystemColors.Control;
            dgwProductionList.BorderStyle = BorderStyle.None;
            dgwProductionList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductionList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwProductionList.Dock = DockStyle.Fill;
            dgwProductionList.Location = new Point(10, 48);
            dgwProductionList.Name = "dgwProductionList";
            dgwProductionList.ReadOnly = true;
            dgwProductionList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductionList.RowTemplate.Height = 25;
            dgwProductionList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwProductionList.Size = new Size(1244, 209);
            dgwProductionList.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtProductionSearch);
            panel1.Controls.Add(bttnProductionSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(1244, 38);
            panel1.TabIndex = 6;
            // 
            // txtProductionSearch
            // 
            txtProductionSearch.Dock = DockStyle.Fill;
            txtProductionSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtProductionSearch.Location = new Point(5, 5);
            txtProductionSearch.Name = "txtProductionSearch";
            txtProductionSearch.PlaceholderText = "Arama...";
            txtProductionSearch.Size = new Size(1159, 27);
            txtProductionSearch.TabIndex = 2;
            // 
            // bttnProductionSearch
            // 
            bttnProductionSearch.Dock = DockStyle.Right;
            bttnProductionSearch.Location = new Point(1164, 5);
            bttnProductionSearch.Name = "bttnProductionSearch";
            bttnProductionSearch.Size = new Size(75, 28);
            bttnProductionSearch.TabIndex = 1;
            bttnProductionSearch.Text = "Ara...";
            bttnProductionSearch.UseVisualStyleBackColor = true;
            // 
            // panelBottomBottom
            // 
            panelBottomBottom.Controls.Add(bttnAdd);
            panelBottomBottom.Controls.Add(bttnUpdate);
            panelBottomBottom.Controls.Add(bttnDelete);
            panelBottomBottom.Dock = DockStyle.Bottom;
            panelBottomBottom.Location = new Point(10, 257);
            panelBottomBottom.Name = "panelBottomBottom";
            panelBottomBottom.Size = new Size(1244, 41);
            panelBottomBottom.TabIndex = 1;
            // 
            // bttnAdd
            // 
            bttnAdd.Dock = DockStyle.Right;
            bttnAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAdd.Image = (Image)resources.GetObject("bttnAdd.Image");
            bttnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            bttnAdd.Location = new Point(943, 0);
            bttnAdd.Name = "bttnAdd";
            bttnAdd.Size = new Size(90, 41);
            bttnAdd.TabIndex = 5;
            bttnAdd.Text = "Ekle";
            bttnAdd.UseVisualStyleBackColor = true;
            bttnAdd.Click += bttnAdd_Click;
            // 
            // bttnUpdate
            // 
            bttnUpdate.Dock = DockStyle.Right;
            bttnUpdate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnUpdate.Image = (Image)resources.GetObject("bttnUpdate.Image");
            bttnUpdate.ImageAlign = ContentAlignment.MiddleLeft;
            bttnUpdate.Location = new Point(1033, 0);
            bttnUpdate.Name = "bttnUpdate";
            bttnUpdate.Size = new Size(121, 41);
            bttnUpdate.TabIndex = 4;
            bttnUpdate.Text = "Güncelle";
            bttnUpdate.UseVisualStyleBackColor = true;
            // 
            // bttnDelete
            // 
            bttnDelete.Dock = DockStyle.Right;
            bttnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnDelete.Image = (Image)resources.GetObject("bttnDelete.Image");
            bttnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            bttnDelete.Location = new Point(1154, 0);
            bttnDelete.Name = "bttnDelete";
            bttnDelete.Size = new Size(90, 41);
            bttnDelete.TabIndex = 3;
            bttnDelete.Text = "Sil";
            bttnDelete.UseVisualStyleBackColor = true;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(txtDescription);
            panelLeft.Controls.Add(label7);
            panelLeft.Controls.Add(label6);
            panelLeft.Controls.Add(productionDateTimePicker);
            panelLeft.Controls.Add(label5);
            panelLeft.Controls.Add(txtProductionQuantity);
            panelLeft.Controls.Add(label4);
            panelLeft.Controls.Add(cmbBoxProductCode);
            panelLeft.Controls.Add(label3);
            panelLeft.Controls.Add(cmbBoxProductName);
            panelLeft.Controls.Add(label2);
            panelLeft.Controls.Add(cmbBoxBranch);
            panelLeft.Controls.Add(label1);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(10);
            panelLeft.Size = new Size(262, 383);
            panelLeft.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(13, 261);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Açıklama...";
            txtDescription.Size = new Size(219, 109);
            txtDescription.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 243);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 10;
            label7.Text = "Açıklama :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 199);
            label6.Name = "label6";
            label6.Size = new Size(80, 15);
            label6.TabIndex = 9;
            label6.Text = "Üretim Tarihi :";
            // 
            // productionDateTimePicker
            // 
            productionDateTimePicker.Location = new Point(12, 217);
            productionDateTimePicker.Name = "productionDateTimePicker";
            productionDateTimePicker.Size = new Size(200, 23);
            productionDateTimePicker.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(200, 176);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 7;
            label5.Text = "Adet";
            // 
            // txtProductionQuantity
            // 
            txtProductionQuantity.Location = new Point(12, 173);
            txtProductionQuantity.Name = "txtProductionQuantity";
            txtProductionQuantity.PlaceholderText = "Üretilecek Miktar...";
            txtProductionQuantity.Size = new Size(174, 23);
            txtProductionQuantity.TabIndex = 7;
            txtProductionQuantity.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 155);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 6;
            label4.Text = "Üretilecek Miktar :";
            // 
            // cmbBoxProductCode
            // 
            cmbBoxProductCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxProductCode.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxProductCode.FormattingEnabled = true;
            cmbBoxProductCode.Location = new Point(12, 129);
            cmbBoxProductCode.Name = "cmbBoxProductCode";
            cmbBoxProductCode.Size = new Size(219, 23);
            cmbBoxProductCode.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 111);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 4;
            label3.Text = "Ürün Kodu :";
            // 
            // cmbBoxProductName
            // 
            cmbBoxProductName.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxProductName.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxProductName.FormattingEnabled = true;
            cmbBoxProductName.Location = new Point(13, 81);
            cmbBoxProductName.Name = "cmbBoxProductName";
            cmbBoxProductName.Size = new Size(219, 23);
            cmbBoxProductName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 63);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 2;
            label2.Text = "Ürün Adı :";
            // 
            // cmbBoxBranch
            // 
            cmbBoxBranch.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxBranch.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxBranch.FormattingEnabled = true;
            cmbBoxBranch.Location = new Point(12, 33);
            cmbBoxBranch.Name = "cmbBoxBranch";
            cmbBoxBranch.Size = new Size(219, 23);
            cmbBoxBranch.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 0;
            label1.Text = "Üretim Yapılacak Şube :";
            // 
            // panelMid
            // 
            panelMid.Controls.Add(dgwProductReceiptList);
            panelMid.Controls.Add(panelTop);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(262, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(1002, 383);
            panelMid.TabIndex = 2;
            // 
            // dgwProductReceiptList
            // 
            dgwProductReceiptList.AllowUserToAddRows = false;
            dgwProductReceiptList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = SystemColors.GradientInactiveCaption;
            dgwProductReceiptList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            dgwProductReceiptList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwProductReceiptList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwProductReceiptList.BackgroundColor = SystemColors.Control;
            dgwProductReceiptList.BorderStyle = BorderStyle.None;
            dgwProductReceiptList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductReceiptList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwProductReceiptList.Dock = DockStyle.Fill;
            dgwProductReceiptList.Location = new Point(10, 48);
            dgwProductReceiptList.Name = "dgwProductReceiptList";
            dgwProductReceiptList.ReadOnly = true;
            dgwProductReceiptList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductReceiptList.RowTemplate.Height = 25;
            dgwProductReceiptList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwProductReceiptList.Size = new Size(982, 325);
            dgwProductReceiptList.TabIndex = 10;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(txtProductReceiptSearch);
            panelTop.Controls.Add(bttnProductReceiptSearch);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(10, 10);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(5);
            panelTop.Size = new Size(982, 38);
            panelTop.TabIndex = 6;
            // 
            // txtProductReceiptSearch
            // 
            txtProductReceiptSearch.Dock = DockStyle.Fill;
            txtProductReceiptSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtProductReceiptSearch.Location = new Point(5, 5);
            txtProductReceiptSearch.Name = "txtProductReceiptSearch";
            txtProductReceiptSearch.PlaceholderText = "Arama...";
            txtProductReceiptSearch.Size = new Size(897, 27);
            txtProductReceiptSearch.TabIndex = 2;
            // 
            // bttnProductReceiptSearch
            // 
            bttnProductReceiptSearch.Dock = DockStyle.Right;
            bttnProductReceiptSearch.Location = new Point(902, 5);
            bttnProductReceiptSearch.Name = "bttnProductReceiptSearch";
            bttnProductReceiptSearch.Size = new Size(75, 28);
            bttnProductReceiptSearch.TabIndex = 1;
            bttnProductReceiptSearch.Text = "Ara...";
            bttnProductReceiptSearch.UseVisualStyleBackColor = true;
            // 
            // frmProduction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(panelMid);
            Controls.Add(panelLeft);
            Controls.Add(panelBottom);
            Name = "frmProduction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Üretim";
            Load += frmProduction_Load;
            panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwProductionList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelBottomBottom.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwProductReceiptList).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelBottomBottom;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panel1;
        private TextBox txtProductionSearch;
        private Button bttnProductionSearch;
        private System.Windows.Forms.Panel panelTop;
        private TextBox txtProductReceiptSearch;
        private Button bttnProductReceiptSearch;
        private TextBox txtDescription;
        private Label label7;
        private Label label6;
        private DateTimePicker productionDateTimePicker;
        private Label label5;
        private TextBox txtProductionQuantity;
        private Label label4;
        private ComboBox cmbBoxProductCode;
        private Label label3;
        private ComboBox cmbBoxProductName;
        private Label label2;
        private ComboBox cmbBoxBranch;
        private Label label1;
        private DataGridView dgwProductReceiptList;
        private DataGridView dgwProductionList;
        private Button bttnAdd;
        private Button bttnUpdate;
        private Button bttnDelete;
    }
}