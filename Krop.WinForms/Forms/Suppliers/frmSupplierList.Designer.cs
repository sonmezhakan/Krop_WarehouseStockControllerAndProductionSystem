namespace Krop.WinForms.Suppliers
{
    partial class frmSupplierList
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierList));
            bttnSearch = new Button();
            panel1 = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            Column5 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            dgwSupplierList = new DataGridView();
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
            panelDgwFooter = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwSupplierList).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(879, 5);
            bttnSearch.Name = "bttnSearch";
            bttnSearch.Size = new Size(75, 28);
            bttnSearch.TabIndex = 1;
            bttnSearch.Text = "Ara...";
            bttnSearch.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(bttnSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(959, 38);
            panel1.TabIndex = 12;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(874, 27);
            txtSearch.TabIndex = 2;
            txtSearch.Text = "Arama....";
            // 
            // Column5
            // 
            Column5.HeaderText = "Column5";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Column4";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Column3";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // dgwSupplierList
            // 
            dgwSupplierList.AllowUserToAddRows = false;
            dgwSupplierList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwSupplierList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwSupplierList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwSupplierList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwSupplierList.BackgroundColor = SystemColors.Control;
            dgwSupplierList.BorderStyle = BorderStyle.None;
            dgwSupplierList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwSupplierList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwSupplierList.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dgwSupplierList.ContextMenuStrip = contextMenuStrip1;
            dgwSupplierList.Dock = DockStyle.Fill;
            dgwSupplierList.Location = new Point(0, 0);
            dgwSupplierList.Name = "dgwSupplierList";
            dgwSupplierList.ReadOnly = true;
            dgwSupplierList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwSupplierList.RowTemplate.Height = 25;
            dgwSupplierList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwSupplierList.Size = new Size(959, 447);
            dgwSupplierList.TabIndex = 11;
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
            // panelDgwFooter
            // 
            panelDgwFooter.Dock = DockStyle.Bottom;
            panelDgwFooter.Location = new Point(0, 447);
            panelDgwFooter.Name = "panelDgwFooter";
            panelDgwFooter.Size = new Size(959, 26);
            panelDgwFooter.TabIndex = 10;
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 473);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(959, 32);
            panelBottom.TabIndex = 9;
            // 
            // frmSupplierList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 505);
            Controls.Add(panel1);
            Controls.Add(dgwSupplierList);
            Controls.Add(panelDgwFooter);
            Controls.Add(panelBottom);
            Name = "frmSupplierList";
            Text = "Tedarikçi Listesi";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgwSupplierList).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button bttnSearch;
        private System.Windows.Forms.Panel panel1;
        private TextBox txtSearch;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridView dgwSupplierList;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem productCartToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem productAddToolStripMenuItem;
        private ToolStripMenuItem productUpdateToolStripMenuItem;
        private ToolStripMenuItem productDeleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem produuctListRefreshToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem productionListToolStripMenuItem;
        private ToolStripMenuItem stockReceiptToolStripMenuItem;
        private ToolStripMenuItem stockTransferToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem stockNotificationToolStripMenuItem;
        private System.Windows.Forms.Panel panelDgwFooter;
        private System.Windows.Forms.Panel panelBottom;
    }
}