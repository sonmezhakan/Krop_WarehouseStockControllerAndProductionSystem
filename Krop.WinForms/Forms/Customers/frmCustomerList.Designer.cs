namespace Krop.WinForms.Customers
{
    partial class frmCustomerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerList));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            bttnSearch = new Button();
            panel1 = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            Column5 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            stockNotificationToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            stockTransferToolStripMenuItem = new ToolStripMenuItem();
            stockReceiptToolStripMenuItem = new ToolStripMenuItem();
            productionListToolStripMenuItem = new ToolStripMenuItem();
            produuctListRefreshToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            productDeleteToolStripMenuItem = new ToolStripMenuItem();
            productUpdateToolStripMenuItem = new ToolStripMenuItem();
            productAddToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            productCartToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripSeparator3 = new ToolStripSeparator();
            panelDgwFooter = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            dgwCustomerList = new DataGridView();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwCustomerList).BeginInit();
            SuspendLayout();
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(945, 5);
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
            panel1.Size = new Size(1025, 38);
            panel1.TabIndex = 12;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(940, 27);
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
            // stockNotificationToolStripMenuItem
            // 
            stockNotificationToolStripMenuItem.Name = "stockNotificationToolStripMenuItem";
            stockNotificationToolStripMenuItem.Size = new Size(157, 22);
            stockNotificationToolStripMenuItem.Text = "Stok Bildirimi";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(154, 6);
            // 
            // stockTransferToolStripMenuItem
            // 
            stockTransferToolStripMenuItem.Image = (Image)resources.GetObject("stockTransferToolStripMenuItem.Image");
            stockTransferToolStripMenuItem.Name = "stockTransferToolStripMenuItem";
            stockTransferToolStripMenuItem.Size = new Size(157, 22);
            stockTransferToolStripMenuItem.Text = "Stok Transferleri";
            // 
            // stockReceiptToolStripMenuItem
            // 
            stockReceiptToolStripMenuItem.Image = (Image)resources.GetObject("stockReceiptToolStripMenuItem.Image");
            stockReceiptToolStripMenuItem.Name = "stockReceiptToolStripMenuItem";
            stockReceiptToolStripMenuItem.Size = new Size(157, 22);
            stockReceiptToolStripMenuItem.Text = "Stock Girişleri";
            // 
            // productionListToolStripMenuItem
            // 
            productionListToolStripMenuItem.Image = (Image)resources.GetObject("productionListToolStripMenuItem.Image");
            productionListToolStripMenuItem.Name = "productionListToolStripMenuItem";
            productionListToolStripMenuItem.Size = new Size(157, 22);
            productionListToolStripMenuItem.Text = "Üretim Listesi";
            // 
            // produuctListRefreshToolStripMenuItem
            // 
            produuctListRefreshToolStripMenuItem.Name = "produuctListRefreshToolStripMenuItem";
            produuctListRefreshToolStripMenuItem.Size = new Size(157, 22);
            produuctListRefreshToolStripMenuItem.Text = "Yenile";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(154, 6);
            // 
            // productDeleteToolStripMenuItem
            // 
            productDeleteToolStripMenuItem.Image = (Image)resources.GetObject("productDeleteToolStripMenuItem.Image");
            productDeleteToolStripMenuItem.Name = "productDeleteToolStripMenuItem";
            productDeleteToolStripMenuItem.Size = new Size(157, 22);
            productDeleteToolStripMenuItem.Text = "Sil";
            // 
            // productUpdateToolStripMenuItem
            // 
            productUpdateToolStripMenuItem.Image = (Image)resources.GetObject("productUpdateToolStripMenuItem.Image");
            productUpdateToolStripMenuItem.Name = "productUpdateToolStripMenuItem";
            productUpdateToolStripMenuItem.Size = new Size(157, 22);
            productUpdateToolStripMenuItem.Text = "Güncelle";
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
            // productCartToolStripMenuItem
            // 
            productCartToolStripMenuItem.Image = (Image)resources.GetObject("productCartToolStripMenuItem.Image");
            productCartToolStripMenuItem.Name = "productCartToolStripMenuItem";
            productCartToolStripMenuItem.Size = new Size(157, 22);
            productCartToolStripMenuItem.Text = "Kart";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { productCartToolStripMenuItem, toolStripSeparator1, productAddToolStripMenuItem, productUpdateToolStripMenuItem, productDeleteToolStripMenuItem, toolStripSeparator2, produuctListRefreshToolStripMenuItem, toolStripSeparator3, productionListToolStripMenuItem, stockReceiptToolStripMenuItem, stockTransferToolStripMenuItem, toolStripSeparator4, stockNotificationToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(158, 226);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(154, 6);
            // 
            // panelDgwFooter
            // 
            panelDgwFooter.Dock = DockStyle.Bottom;
            panelDgwFooter.Location = new Point(0, 465);
            panelDgwFooter.Name = "panelDgwFooter";
            panelDgwFooter.Size = new Size(1025, 26);
            panelDgwFooter.TabIndex = 10;
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 491);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1025, 32);
            panelBottom.TabIndex = 9;
            // 
            // dgwCustomerList
            // 
            dgwCustomerList.AllowUserToAddRows = false;
            dgwCustomerList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwCustomerList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwCustomerList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwCustomerList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwCustomerList.BackgroundColor = SystemColors.Control;
            dgwCustomerList.BorderStyle = BorderStyle.None;
            dgwCustomerList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwCustomerList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwCustomerList.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dgwCustomerList.ContextMenuStrip = contextMenuStrip1;
            dgwCustomerList.Dock = DockStyle.Fill;
            dgwCustomerList.Location = new Point(0, 0);
            dgwCustomerList.Name = "dgwCustomerList";
            dgwCustomerList.ReadOnly = true;
            dgwCustomerList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwCustomerList.RowTemplate.Height = 25;
            dgwCustomerList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwCustomerList.Size = new Size(1025, 523);
            dgwCustomerList.TabIndex = 11;
            // 
            // frmCustomerList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 523);
            Controls.Add(panel1);
            Controls.Add(panelDgwFooter);
            Controls.Add(panelBottom);
            Controls.Add(dgwCustomerList);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCustomerList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Müşteri Listesi";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwCustomerList).EndInit();
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
        private ToolStripMenuItem stockNotificationToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem stockTransferToolStripMenuItem;
        private ToolStripMenuItem stockReceiptToolStripMenuItem;
        private ToolStripMenuItem productionListToolStripMenuItem;
        private ToolStripMenuItem produuctListRefreshToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem productDeleteToolStripMenuItem;
        private ToolStripMenuItem productUpdateToolStripMenuItem;
        private ToolStripMenuItem productAddToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem productCartToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panelDgwFooter;
        private System.Windows.Forms.Panel panelBottom;
        private DataGridView dgwCustomerList;
    }
}