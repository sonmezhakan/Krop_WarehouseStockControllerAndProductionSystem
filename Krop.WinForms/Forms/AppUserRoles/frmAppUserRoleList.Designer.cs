namespace Krop.WinForms.AppUserRoles
{
    partial class frmAppUserRoleList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppUserRoleList));
            Column5 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            dgwAppUserRoleList = new DataGridView();
            Column4 = new DataGridViewTextBoxColumn();
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
            panelBottom = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            bttnSearch = new Button();
            panelDgwFooter = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)dgwAppUserRoleList).BeginInit();
            contextMenuStrip1.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // Column5
            // 
            Column5.HeaderText = "Column5";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
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
            // dgwAppUserRoleList
            // 
            dgwAppUserRoleList.AllowUserToAddRows = false;
            dgwAppUserRoleList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwAppUserRoleList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwAppUserRoleList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwAppUserRoleList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwAppUserRoleList.BackgroundColor = SystemColors.Control;
            dgwAppUserRoleList.BorderStyle = BorderStyle.None;
            dgwAppUserRoleList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwAppUserRoleList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwAppUserRoleList.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dgwAppUserRoleList.ContextMenuStrip = contextMenuStrip1;
            dgwAppUserRoleList.Dock = DockStyle.Fill;
            dgwAppUserRoleList.Location = new Point(0, 38);
            dgwAppUserRoleList.Name = "dgwAppUserRoleList";
            dgwAppUserRoleList.ReadOnly = true;
            dgwAppUserRoleList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwAppUserRoleList.RowTemplate.Height = 25;
            dgwAppUserRoleList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwAppUserRoleList.Size = new Size(920, 399);
            dgwAppUserRoleList.TabIndex = 12;
            // 
            // Column4
            // 
            Column4.HeaderText = "Column4";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
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
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 437);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(920, 32);
            panelBottom.TabIndex = 9;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(835, 27);
            txtSearch.TabIndex = 2;
            txtSearch.Text = "Arama....";
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(840, 5);
            bttnSearch.Name = "bttnSearch";
            bttnSearch.Size = new Size(75, 28);
            bttnSearch.TabIndex = 1;
            bttnSearch.Text = "Ara...";
            bttnSearch.UseVisualStyleBackColor = true;
            // 
            // panelDgwFooter
            // 
            panelDgwFooter.Dock = DockStyle.Bottom;
            panelDgwFooter.Location = new Point(0, 469);
            panelDgwFooter.Name = "panelDgwFooter";
            panelDgwFooter.Size = new Size(920, 26);
            panelDgwFooter.TabIndex = 11;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(bttnSearch);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(5);
            panelTop.Size = new Size(920, 38);
            panelTop.TabIndex = 10;
            // 
            // frmAppUserRoleList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 495);
            Controls.Add(dgwAppUserRoleList);
            Controls.Add(panelBottom);
            Controls.Add(panelDgwFooter);
            Controls.Add(panelTop);
            Name = "frmAppUserRoleList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yetki Listesi";
            ((System.ComponentModel.ISupportInitialize)dgwAppUserRoleList).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridView dgwAppUserRoleList;
        private DataGridViewTextBoxColumn Column4;
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
        private System.Windows.Forms.Panel panelBottom;
        private TextBox txtSearch;
        private Button bttnSearch;
        private System.Windows.Forms.Panel panelDgwFooter;
        private System.Windows.Forms.Panel panelTop;
    }
}