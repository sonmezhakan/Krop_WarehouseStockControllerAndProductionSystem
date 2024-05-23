namespace Krop.WinForms.Products
{
    partial class frmProductList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductList));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelBottom = new System.Windows.Forms.Panel();
            panelDgwFooter = new System.Windows.Forms.Panel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            productCartToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            productAddToolStripMenuItem = new ToolStripMenuItem();
            productUpdateToolStripMenuItem = new ToolStripMenuItem();
            productDeleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            produuctListRefreshToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            productionListToolStripMenuItem = new ToolStripMenuItem();
            stockReceiptToolStripMenuItem = new ToolStripMenuItem();
            stockTransferToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            stockNotificationToolStripMenuItem = new ToolStripMenuItem();
            dgwProductList = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            panel1 = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            bttnSearch = new Button();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwProductList).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 649);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1254, 32);
            panelBottom.TabIndex = 0;
            // 
            // panelDgwFooter
            // 
            panelDgwFooter.Dock = DockStyle.Bottom;
            panelDgwFooter.Location = new Point(0, 623);
            panelDgwFooter.Name = "panelDgwFooter";
            panelDgwFooter.Size = new Size(1254, 26);
            panelDgwFooter.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { productCartToolStripMenuItem, toolStripSeparator1, productAddToolStripMenuItem, productUpdateToolStripMenuItem, productDeleteToolStripMenuItem, toolStripSeparator2, produuctListRefreshToolStripMenuItem, toolStripSeparator3, productionListToolStripMenuItem, stockReceiptToolStripMenuItem, stockTransferToolStripMenuItem, toolStripSeparator4, stockNotificationToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(158, 226);
            // 
            // productCartToolStripMenuItem
            // 
            productCartToolStripMenuItem.Image = (Image)resources.GetObject("productCartToolStripMenuItem.Image");
            productCartToolStripMenuItem.Name = "productCartToolStripMenuItem";
            productCartToolStripMenuItem.Size = new Size(157, 22);
            productCartToolStripMenuItem.Text = "Kart";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(154, 6);
            // 
            // productAddToolStripMenuItem
            // 
            productAddToolStripMenuItem.Image = (Image)resources.GetObject("productAddToolStripMenuItem.Image");
            productAddToolStripMenuItem.Name = "productAddToolStripMenuItem";
            productAddToolStripMenuItem.Size = new Size(157, 22);
            productAddToolStripMenuItem.Text = "Ekle";
            // 
            // productUpdateToolStripMenuItem
            // 
            productUpdateToolStripMenuItem.Image = (Image)resources.GetObject("productUpdateToolStripMenuItem.Image");
            productUpdateToolStripMenuItem.Name = "productUpdateToolStripMenuItem";
            productUpdateToolStripMenuItem.Size = new Size(157, 22);
            productUpdateToolStripMenuItem.Text = "Güncelle";
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
            // produuctListRefreshToolStripMenuItem
            // 
            produuctListRefreshToolStripMenuItem.Name = "produuctListRefreshToolStripMenuItem";
            produuctListRefreshToolStripMenuItem.Size = new Size(157, 22);
            produuctListRefreshToolStripMenuItem.Text = "Yenile";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(154, 6);
            // 
            // productionListToolStripMenuItem
            // 
            productionListToolStripMenuItem.Image = (Image)resources.GetObject("productionListToolStripMenuItem.Image");
            productionListToolStripMenuItem.Name = "productionListToolStripMenuItem";
            productionListToolStripMenuItem.Size = new Size(157, 22);
            productionListToolStripMenuItem.Text = "Üretim Listesi";
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
            // dgwProductList
            // 
            dgwProductList.AllowUserToAddRows = false;
            dgwProductList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwProductList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwProductList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwProductList.BackgroundColor = SystemColors.Control;
            dgwProductList.BorderStyle = BorderStyle.None;
            dgwProductList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwProductList.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dgwProductList.ContextMenuStrip = contextMenuStrip1;
            dgwProductList.Dock = DockStyle.Fill;
            dgwProductList.Location = new Point(0, 38);
            dgwProductList.Name = "dgwProductList";
            dgwProductList.ReadOnly = true;
            dgwProductList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductList.RowTemplate.Height = 25;
            dgwProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwProductList.Size = new Size(1254, 585);
            dgwProductList.TabIndex = 7;
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
            // panel1
            // 
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(bttnSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(1254, 38);
            panel1.TabIndex = 8;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(1169, 27);
            txtSearch.TabIndex = 2;
            txtSearch.Text = "Arama....";
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(1174, 5);
            bttnSearch.Name = "bttnSearch";
            bttnSearch.Size = new Size(75, 28);
            bttnSearch.TabIndex = 1;
            bttnSearch.Text = "Ara...";
            bttnSearch.UseVisualStyleBackColor = true;
            // 
            // frmProductList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1254, 681);
            Controls.Add(dgwProductList);
            Controls.Add(panel1);
            Controls.Add(panelDgwFooter);
            Controls.Add(panelBottom);
            Name = "frmProductList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ürün Listesi";
            Load += frmProductList_Load;
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwProductList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelDgwFooter;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem productCartToolStripMenuItem;
        private ToolStripMenuItem productAddToolStripMenuItem;
        private ToolStripMenuItem productUpdateToolStripMenuItem;
        private ToolStripMenuItem productDeleteToolStripMenuItem;
        private ToolStripMenuItem produuctListRefreshToolStripMenuItem;
        private ToolStripMenuItem productionListToolStripMenuItem;
        private ToolStripMenuItem stockReceiptToolStripMenuItem;
        private ToolStripMenuItem stockTransferToolStripMenuItem;
        private ToolStripMenuItem stockNotificationToolStripMenuItem;
        private DataGridView dgwProductList;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Panel panel1;
        private TextBox txtSearch;
        private Button bttnSearch;
    }
}