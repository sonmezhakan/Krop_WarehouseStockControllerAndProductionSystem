namespace Krop.WinForms.Categories
{
    partial class frmCategoryList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoryList));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            CategoryListRefreshToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            CategoryDeleteToolStripMenuItem = new ToolStripMenuItem();
            CategoryUpdateToolStripMenuItem = new ToolStripMenuItem();
            CategoryAddToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripSeparator1 = new ToolStripSeparator();
            contextMenuStrip1 = new ContextMenuStrip(components);
            CategoryCartToolStripMenuItem = new ToolStripMenuItem();
            panelDgwFooter = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            bttnSearch = new Button();
            panelBottom = new System.Windows.Forms.Panel();
            dgwCategoryList = new DataGridView();
            contextMenuStrip1.SuspendLayout();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwCategoryList).BeginInit();
            SuspendLayout();
            // 
            // CategoryListRefreshToolStripMenuItem
            // 
            CategoryListRefreshToolStripMenuItem.Name = "CategoryListRefreshToolStripMenuItem";
            CategoryListRefreshToolStripMenuItem.Size = new Size(120, 22);
            CategoryListRefreshToolStripMenuItem.Text = "Yenile";
            CategoryListRefreshToolStripMenuItem.Click += CategoryListRefreshToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(117, 6);
            // 
            // CategoryDeleteToolStripMenuItem
            // 
            CategoryDeleteToolStripMenuItem.Image = (Image)resources.GetObject("CategoryDeleteToolStripMenuItem.Image");
            CategoryDeleteToolStripMenuItem.Name = "CategoryDeleteToolStripMenuItem";
            CategoryDeleteToolStripMenuItem.Size = new Size(120, 22);
            CategoryDeleteToolStripMenuItem.Text = "Sil";
            CategoryDeleteToolStripMenuItem.Click += CategoryDeleteToolStripMenuItem_Click;
            // 
            // CategoryUpdateToolStripMenuItem
            // 
            CategoryUpdateToolStripMenuItem.Image = (Image)resources.GetObject("CategoryUpdateToolStripMenuItem.Image");
            CategoryUpdateToolStripMenuItem.Name = "CategoryUpdateToolStripMenuItem";
            CategoryUpdateToolStripMenuItem.Size = new Size(120, 22);
            CategoryUpdateToolStripMenuItem.Text = "Güncelle";
            CategoryUpdateToolStripMenuItem.Click += CategoryUpdateToolStripMenuItem_Click;
            // 
            // CategoryAddToolStripMenuItem
            // 
            CategoryAddToolStripMenuItem.Image = (Image)resources.GetObject("CategoryAddToolStripMenuItem.Image");
            CategoryAddToolStripMenuItem.Name = "CategoryAddToolStripMenuItem";
            CategoryAddToolStripMenuItem.Size = new Size(120, 22);
            CategoryAddToolStripMenuItem.Text = "Ekle";
            CategoryAddToolStripMenuItem.Click += CategoryAddToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(117, 6);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(117, 6);
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { CategoryCartToolStripMenuItem, toolStripSeparator1, CategoryAddToolStripMenuItem, CategoryUpdateToolStripMenuItem, CategoryDeleteToolStripMenuItem, toolStripSeparator2, CategoryListRefreshToolStripMenuItem, toolStripSeparator4 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(121, 132);
            // 
            // CategoryCartToolStripMenuItem
            // 
            CategoryCartToolStripMenuItem.Image = (Image)resources.GetObject("CategoryCartToolStripMenuItem.Image");
            CategoryCartToolStripMenuItem.Name = "CategoryCartToolStripMenuItem";
            CategoryCartToolStripMenuItem.Size = new Size(120, 22);
            CategoryCartToolStripMenuItem.Text = "Kart";
            CategoryCartToolStripMenuItem.Click += CategoryCartToolStripMenuItem_Click;
            // 
            // panelDgwFooter
            // 
            panelDgwFooter.Dock = DockStyle.Bottom;
            panelDgwFooter.Location = new Point(0, 456);
            panelDgwFooter.Name = "panelDgwFooter";
            panelDgwFooter.Size = new Size(941, 26);
            panelDgwFooter.TabIndex = 6;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(bttnSearch);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(5);
            panelTop.Size = new Size(941, 38);
            panelTop.TabIndex = 5;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama...";
            txtSearch.Size = new Size(856, 27);
            txtSearch.TabIndex = 2;
            txtSearch.KeyPress += txtSearch_KeyPress;
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(861, 5);
            bttnSearch.Name = "bttnSearch";
            bttnSearch.Size = new Size(75, 28);
            bttnSearch.TabIndex = 1;
            bttnSearch.Text = "Ara...";
            bttnSearch.UseVisualStyleBackColor = true;
            bttnSearch.Click += bttnSearch_Click;
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 482);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(941, 32);
            panelBottom.TabIndex = 4;
            // 
            // dgwCategoryList
            // 
            dgwCategoryList.AllowUserToAddRows = false;
            dgwCategoryList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwCategoryList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwCategoryList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwCategoryList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwCategoryList.BackgroundColor = SystemColors.Control;
            dgwCategoryList.BorderStyle = BorderStyle.None;
            dgwCategoryList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwCategoryList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwCategoryList.ContextMenuStrip = contextMenuStrip1;
            dgwCategoryList.Dock = DockStyle.Fill;
            dgwCategoryList.Location = new Point(0, 38);
            dgwCategoryList.Name = "dgwCategoryList";
            dgwCategoryList.ReadOnly = true;
            dgwCategoryList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwCategoryList.RowTemplate.Height = 25;
            dgwCategoryList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwCategoryList.Size = new Size(941, 418);
            dgwCategoryList.TabIndex = 8;
            // 
            // frmCategoryList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 514);
            Controls.Add(dgwCategoryList);
            Controls.Add(panelDgwFooter);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Name = "frmCategoryList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kategori Listesi";
            Load += frmCategoryList_Load;
            contextMenuStrip1.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgwCategoryList).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ToolStripMenuItem CategoryListRefreshToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem CategoryDeleteToolStripMenuItem;
        private ToolStripMenuItem CategoryUpdateToolStripMenuItem;
        private ToolStripMenuItem CategoryAddToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem CategoryCartToolStripMenuItem;
        private System.Windows.Forms.Panel panelDgwFooter;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private DataGridView dgwCategoryList;
        private TextBox txtSearch;
        private Button bttnSearch;
    }
}