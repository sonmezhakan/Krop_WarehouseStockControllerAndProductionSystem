namespace Krop.WinForms.Forms.StockTransfers
{
    partial class frmStockTransfer
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockTransfer));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            productCartToolStripMenuItem = new ToolStripMenuItem();
            productAddToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            bttnNewBranch = new Button();
            bttnNewSupplier = new Button();
            productDeleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            label11 = new Label();
            txtDescription = new TextBox();
            label10 = new Label();
            label9 = new Label();
            txtQuantity = new TextBox();
            label8 = new Label();
            produuctListRefreshToolStripMenuItem = new ToolStripMenuItem();
            productUpdateToolStripMenuItem = new ToolStripMenuItem();
            productionListToolStripMenuItem = new ToolStripMenuItem();
            label5 = new Label();
            cmbBoxProductCode = new ComboBox();
            label4 = new Label();
            cmbBoxProductName = new ComboBox();
            toolStripSeparator3 = new ToolStripSeparator();
            contextMenuStrip1 = new ContextMenuStrip(components);
            stockReceiptToolStripMenuItem = new ToolStripMenuItem();
            stockTransferToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            stockNotificationToolStripMenuItem = new ToolStripMenuItem();
            panelMid = new System.Windows.Forms.Panel();
            dgwStockTransferList = new DataGridView();
            panel1 = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            bttnSearch = new Button();
            txtInvoiceNumber = new TextBox();
            label3 = new Label();
            label2 = new Label();
            cmbBoxSenderBranch = new ComboBox();
            label1 = new Label();
            panelLeft = new System.Windows.Forms.Panel();
            transferDateTimePicker = new DateTimePicker();
            cmbBoxSentBranch = new ComboBox();
            bttnAdd = new Button();
            bttnUpdate = new Button();
            bttnDelete = new Button();
            panelBottom = new System.Windows.Forms.Panel();
            contextMenuStrip1.SuspendLayout();
            panelMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwStockTransferList).BeginInit();
            panel1.SuspendLayout();
            panelLeft.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // productCartToolStripMenuItem
            // 
            productCartToolStripMenuItem.Image = (Image)resources.GetObject("productCartToolStripMenuItem.Image");
            productCartToolStripMenuItem.Name = "productCartToolStripMenuItem";
            productCartToolStripMenuItem.Size = new Size(157, 22);
            productCartToolStripMenuItem.Text = "Kart";
            // 
            // productAddToolStripMenuItem
            // 
            productAddToolStripMenuItem.Image = (Image)resources.GetObject("productAddToolStripMenuItem.Image");
            productAddToolStripMenuItem.Name = "productAddToolStripMenuItem";
            productAddToolStripMenuItem.Size = new Size(157, 22);
            productAddToolStripMenuItem.Text = "Ekle";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(154, 6);
            // 
            // bttnNewBranch
            // 
            bttnNewBranch.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            bttnNewBranch.Location = new Point(235, 39);
            bttnNewBranch.Name = "bttnNewBranch";
            bttnNewBranch.Size = new Size(23, 23);
            bttnNewBranch.TabIndex = 22;
            bttnNewBranch.Text = "+";
            bttnNewBranch.UseVisualStyleBackColor = true;
            bttnNewBranch.Click += bttnNewBranch_Click;
            // 
            // bttnNewSupplier
            // 
            bttnNewSupplier.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            bttnNewSupplier.Location = new Point(235, 130);
            bttnNewSupplier.Name = "bttnNewSupplier";
            bttnNewSupplier.Size = new Size(23, 23);
            bttnNewSupplier.TabIndex = 21;
            bttnNewSupplier.Text = "+";
            bttnNewSupplier.UseVisualStyleBackColor = true;
            bttnNewSupplier.Click += bttnNewSupplier_Click;
            // 
            // productDeleteToolStripMenuItem
            // 
            productDeleteToolStripMenuItem.Image = (Image)resources.GetObject("productDeleteToolStripMenuItem.Image");
            productDeleteToolStripMenuItem.Name = "productDeleteToolStripMenuItem";
            productDeleteToolStripMenuItem.Size = new Size(157, 22);
            productDeleteToolStripMenuItem.Text = "Sil";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(154, 6);
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(13, 288);
            label11.Name = "label11";
            label11.Size = new Size(97, 15);
            label11.TabIndex = 18;
            label11.Text = "Gönderim Tarihi :";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(13, 350);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Açıklama...";
            txtDescription.Size = new Size(216, 132);
            txtDescription.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(13, 332);
            label10.Name = "label10";
            label10.Size = new Size(62, 15);
            label10.TabIndex = 16;
            label10.Text = "Açıklama :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(205, 265);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 15;
            label9.Text = "Adet";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(12, 262);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.PlaceholderText = "Giriş Yapılacak Miktar..";
            txtQuantity.Size = new Size(178, 23);
            txtQuantity.TabIndex = 14;
            txtQuantity.Text = "0";
            txtQuantity.KeyPress += txtQuantity_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 244);
            label8.Name = "label8";
            label8.Size = new Size(108, 15);
            label8.TabIndex = 13;
            label8.Text = "Gönderilen Miktar :";
            // 
            // produuctListRefreshToolStripMenuItem
            // 
            produuctListRefreshToolStripMenuItem.Name = "produuctListRefreshToolStripMenuItem";
            produuctListRefreshToolStripMenuItem.Size = new Size(157, 22);
            produuctListRefreshToolStripMenuItem.Text = "Yenile";
            // 
            // productUpdateToolStripMenuItem
            // 
            productUpdateToolStripMenuItem.Image = (Image)resources.GetObject("productUpdateToolStripMenuItem.Image");
            productUpdateToolStripMenuItem.Name = "productUpdateToolStripMenuItem";
            productUpdateToolStripMenuItem.Size = new Size(157, 22);
            productUpdateToolStripMenuItem.Text = "Güncelle";
            // 
            // productionListToolStripMenuItem
            // 
            productionListToolStripMenuItem.Image = (Image)resources.GetObject("productionListToolStripMenuItem.Image");
            productionListToolStripMenuItem.Name = "productionListToolStripMenuItem";
            productionListToolStripMenuItem.Size = new Size(157, 22);
            productionListToolStripMenuItem.Text = "Üretim Listesi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 200);
            label5.Name = "label5";
            label5.Size = new Size(100, 15);
            label5.TabIndex = 8;
            label5.Text = "Fatura Numarası :";
            // 
            // cmbBoxProductCode
            // 
            cmbBoxProductCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxProductCode.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxProductCode.FormattingEnabled = true;
            cmbBoxProductCode.Location = new Point(13, 174);
            cmbBoxProductCode.Name = "cmbBoxProductCode";
            cmbBoxProductCode.Size = new Size(216, 23);
            cmbBoxProductCode.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 156);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 6;
            label4.Text = "Ürün Kodu :";
            // 
            // cmbBoxProductName
            // 
            cmbBoxProductName.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxProductName.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxProductName.FormattingEnabled = true;
            cmbBoxProductName.Location = new Point(13, 130);
            cmbBoxProductName.Name = "cmbBoxProductName";
            cmbBoxProductName.Size = new Size(216, 23);
            cmbBoxProductName.TabIndex = 5;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(154, 6);
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { productCartToolStripMenuItem, toolStripSeparator1, productAddToolStripMenuItem, productUpdateToolStripMenuItem, productDeleteToolStripMenuItem, toolStripSeparator2, produuctListRefreshToolStripMenuItem, toolStripSeparator3, productionListToolStripMenuItem, stockReceiptToolStripMenuItem, stockTransferToolStripMenuItem, toolStripSeparator4, stockNotificationToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(158, 226);
            // 
            // stockReceiptToolStripMenuItem
            // 
            stockReceiptToolStripMenuItem.Image = (Image)resources.GetObject("stockReceiptToolStripMenuItem.Image");
            stockReceiptToolStripMenuItem.Name = "stockReceiptToolStripMenuItem";
            stockReceiptToolStripMenuItem.Size = new Size(157, 22);
            stockReceiptToolStripMenuItem.Text = "Stock Girişleri";
            // 
            // stockTransferToolStripMenuItem
            // 
            stockTransferToolStripMenuItem.Image = (Image)resources.GetObject("stockTransferToolStripMenuItem.Image");
            stockTransferToolStripMenuItem.Name = "stockTransferToolStripMenuItem";
            stockTransferToolStripMenuItem.Size = new Size(157, 22);
            stockTransferToolStripMenuItem.Text = "Stok Transferleri";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(154, 6);
            // 
            // stockNotificationToolStripMenuItem
            // 
            stockNotificationToolStripMenuItem.Name = "stockNotificationToolStripMenuItem";
            stockNotificationToolStripMenuItem.Size = new Size(157, 22);
            stockNotificationToolStripMenuItem.Text = "Stok Bildirimi";
            // 
            // panelMid
            // 
            panelMid.Controls.Add(dgwStockTransferList);
            panelMid.Controls.Add(panel1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(267, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(868, 594);
            panelMid.TabIndex = 5;
            // 
            // dgwStockTransferList
            // 
            dgwStockTransferList.AllowUserToAddRows = false;
            dgwStockTransferList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwStockTransferList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwStockTransferList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwStockTransferList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwStockTransferList.BackgroundColor = SystemColors.Control;
            dgwStockTransferList.BorderStyle = BorderStyle.None;
            dgwStockTransferList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwStockTransferList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwStockTransferList.ContextMenuStrip = contextMenuStrip1;
            dgwStockTransferList.Dock = DockStyle.Fill;
            dgwStockTransferList.Location = new Point(10, 48);
            dgwStockTransferList.MultiSelect = false;
            dgwStockTransferList.Name = "dgwStockTransferList";
            dgwStockTransferList.ReadOnly = true;
            dgwStockTransferList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwStockTransferList.RowTemplate.Height = 25;
            dgwStockTransferList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwStockTransferList.Size = new Size(848, 536);
            dgwStockTransferList.TabIndex = 15;
            dgwStockTransferList.DoubleClick += dgwStockTransferList_DoubleClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(bttnSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(848, 38);
            panel1.TabIndex = 13;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama....";
            txtSearch.Size = new Size(763, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(768, 5);
            bttnSearch.Name = "bttnSearch";
            bttnSearch.Size = new Size(75, 28);
            bttnSearch.TabIndex = 1;
            bttnSearch.Text = "Ara...";
            bttnSearch.UseVisualStyleBackColor = true;
            bttnSearch.Click += bttnSearch_Click;
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Location = new Point(13, 218);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.PlaceholderText = "Fatura Numarası...";
            txtInvoiceNumber.Size = new Size(216, 23);
            txtInvoiceNumber.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 112);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 4;
            label3.Text = "Ürün Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 67);
            label2.Name = "label2";
            label2.Size = new Size(124, 15);
            label2.TabIndex = 2;
            label2.Text = "Transfer Yapılan Şube :";
            // 
            // cmbBoxSenderBranch
            // 
            cmbBoxSenderBranch.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxSenderBranch.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxSenderBranch.FormattingEnabled = true;
            cmbBoxSenderBranch.Location = new Point(13, 39);
            cmbBoxSenderBranch.Name = "cmbBoxSenderBranch";
            cmbBoxSenderBranch.Size = new Size(216, 23);
            cmbBoxSenderBranch.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 21);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 0;
            label1.Text = "Transfer Yapan Şube :";
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(transferDateTimePicker);
            panelLeft.Controls.Add(cmbBoxSentBranch);
            panelLeft.Controls.Add(bttnNewBranch);
            panelLeft.Controls.Add(bttnNewSupplier);
            panelLeft.Controls.Add(label11);
            panelLeft.Controls.Add(txtDescription);
            panelLeft.Controls.Add(label10);
            panelLeft.Controls.Add(label9);
            panelLeft.Controls.Add(txtQuantity);
            panelLeft.Controls.Add(label8);
            panelLeft.Controls.Add(txtInvoiceNumber);
            panelLeft.Controls.Add(label5);
            panelLeft.Controls.Add(cmbBoxProductCode);
            panelLeft.Controls.Add(label4);
            panelLeft.Controls.Add(cmbBoxProductName);
            panelLeft.Controls.Add(label3);
            panelLeft.Controls.Add(label2);
            panelLeft.Controls.Add(cmbBoxSenderBranch);
            panelLeft.Controls.Add(label1);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(10);
            panelLeft.Size = new Size(267, 594);
            panelLeft.TabIndex = 4;
            // 
            // transferDateTimePicker
            // 
            transferDateTimePicker.Location = new Point(13, 306);
            transferDateTimePicker.Name = "transferDateTimePicker";
            transferDateTimePicker.Size = new Size(216, 23);
            transferDateTimePicker.TabIndex = 24;
            // 
            // cmbBoxSentBranch
            // 
            cmbBoxSentBranch.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxSentBranch.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxSentBranch.FormattingEnabled = true;
            cmbBoxSentBranch.Location = new Point(13, 85);
            cmbBoxSentBranch.Name = "cmbBoxSentBranch";
            cmbBoxSentBranch.Size = new Size(216, 23);
            cmbBoxSentBranch.TabIndex = 23;
            // 
            // bttnAdd
            // 
            bttnAdd.Dock = DockStyle.Right;
            bttnAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAdd.Image = (Image)resources.GetObject("bttnAdd.Image");
            bttnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            bttnAdd.Location = new Point(832, 0);
            bttnAdd.Name = "bttnAdd";
            bttnAdd.Size = new Size(90, 39);
            bttnAdd.TabIndex = 2;
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
            bttnUpdate.Location = new Point(922, 0);
            bttnUpdate.Name = "bttnUpdate";
            bttnUpdate.Size = new Size(121, 39);
            bttnUpdate.TabIndex = 1;
            bttnUpdate.Text = "Güncelle";
            bttnUpdate.UseVisualStyleBackColor = true;
            bttnUpdate.Click += bttnUpdate_Click;
            // 
            // bttnDelete
            // 
            bttnDelete.Dock = DockStyle.Right;
            bttnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnDelete.Image = (Image)resources.GetObject("bttnDelete.Image");
            bttnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            bttnDelete.Location = new Point(1043, 0);
            bttnDelete.Name = "bttnDelete";
            bttnDelete.Size = new Size(90, 39);
            bttnDelete.TabIndex = 0;
            bttnDelete.Text = "Sil";
            bttnDelete.UseVisualStyleBackColor = true;
            bttnDelete.Click += bttnDelete_Click;
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnAdd);
            panelBottom.Controls.Add(bttnUpdate);
            panelBottom.Controls.Add(bttnDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 594);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1135, 41);
            panelBottom.TabIndex = 3;
            // 
            // frmStockTransfer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1135, 635);
            Controls.Add(panelMid);
            Controls.Add(panelLeft);
            Controls.Add(panelBottom);
            Name = "frmStockTransfer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stok Transferi";
            Load += frmStockTransfer_Load;
            contextMenuStrip1.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwStockTransferList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ToolStripMenuItem productCartToolStripMenuItem;
        private ToolStripMenuItem productAddToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private Button bttnNewBranch;
        private Button bttnNewSupplier;
        private Button bttnNewProduct;
        private DateTimePicker inputDateTimePicker;
        private ToolStripMenuItem productDeleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private Label label11;
        private TextBox txtDescription;
        private Label label10;
        private Label label9;
        private TextBox txtQuantity;
        private Label label8;
        private ToolStripMenuItem produuctListRefreshToolStripMenuItem;
        private ToolStripMenuItem productUpdateToolStripMenuItem;
        private ToolStripMenuItem productionListToolStripMenuItem;
        private Label label7;
        private TextBox txtUnitPrice;
        private Label label6;
        private Label label5;
        private ComboBox cmbBoxSupplier;
        private Label label4;
        private ComboBox cmbBoxProductCode;
        private ToolStripSeparator toolStripSeparator3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem stockReceiptToolStripMenuItem;
        private ToolStripMenuItem stockTransferToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem stockNotificationToolStripMenuItem;
        private System.Windows.Forms.Panel panelMid;
        private DataGridView dgwStockTransferList;
        private System.Windows.Forms.Panel panel1;
        private TextBox txtSearch;
        private Button bttnSearch;
        private TextBox txtInvoiceNumber;
        private Label label3;
        private ComboBox cmbBoxProductName;
        private Label label2;
        private ComboBox cmbBoxSenderBranch;
        private Label label1;
        private System.Windows.Forms.Panel panelLeft;
        private Button bttnAdd;
        private Button bttnUpdate;
        private Button bttnDelete;
        private System.Windows.Forms.Panel panelBottom;
        private DateTimePicker transferDateTimePicker;
        private ComboBox cmbBoxSentBranch;
    }
}