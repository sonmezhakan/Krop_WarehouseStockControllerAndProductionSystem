namespace Krop.WinForms.Brands
{
    partial class frmBrandList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrandList));
            contextMenuStrip1 = new ContextMenuStrip(components);
            brandCartToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            brandAddToolStripMenuItem = new ToolStripMenuItem();
            brandUpdateToolStripMenuItem = new ToolStripMenuItem();
            brandDeleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            brandListRefreshToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            panelBottom = new System.Windows.Forms.Panel();
            bttnSearch = new Button();
            panelDgwFooter = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            brandListControl = new UserControllers.Brands.BrandListControl();
            contextMenuStrip1.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { brandCartToolStripMenuItem, toolStripSeparator1, brandAddToolStripMenuItem, brandUpdateToolStripMenuItem, brandDeleteToolStripMenuItem, toolStripSeparator2, brandListRefreshToolStripMenuItem, toolStripSeparator4 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(121, 132);
            // 
            // brandCartToolStripMenuItem
            // 
            brandCartToolStripMenuItem.Image = (Image)resources.GetObject("brandCartToolStripMenuItem.Image");
            brandCartToolStripMenuItem.Name = "brandCartToolStripMenuItem";
            brandCartToolStripMenuItem.Size = new Size(120, 22);
            brandCartToolStripMenuItem.Text = "Kart";
            brandCartToolStripMenuItem.Click += brandCartToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(117, 6);
            // 
            // brandAddToolStripMenuItem
            // 
            brandAddToolStripMenuItem.Image = (Image)resources.GetObject("brandAddToolStripMenuItem.Image");
            brandAddToolStripMenuItem.Name = "brandAddToolStripMenuItem";
            brandAddToolStripMenuItem.Size = new Size(120, 22);
            brandAddToolStripMenuItem.Text = "Ekle";
            brandAddToolStripMenuItem.Click += brandAddToolStripMenuItem_Click;
            // 
            // brandUpdateToolStripMenuItem
            // 
            brandUpdateToolStripMenuItem.Image = (Image)resources.GetObject("brandUpdateToolStripMenuItem.Image");
            brandUpdateToolStripMenuItem.Name = "brandUpdateToolStripMenuItem";
            brandUpdateToolStripMenuItem.Size = new Size(120, 22);
            brandUpdateToolStripMenuItem.Text = "Güncelle";
            brandUpdateToolStripMenuItem.Click += brandUpdateToolStripMenuItem_Click;
            // 
            // brandDeleteToolStripMenuItem
            // 
            brandDeleteToolStripMenuItem.Image = (Image)resources.GetObject("brandDeleteToolStripMenuItem.Image");
            brandDeleteToolStripMenuItem.Name = "brandDeleteToolStripMenuItem";
            brandDeleteToolStripMenuItem.Size = new Size(120, 22);
            brandDeleteToolStripMenuItem.Text = "Sil";
            brandDeleteToolStripMenuItem.Click += brandDeleteToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(117, 6);
            // 
            // brandListRefreshToolStripMenuItem
            // 
            brandListRefreshToolStripMenuItem.Name = "brandListRefreshToolStripMenuItem";
            brandListRefreshToolStripMenuItem.Size = new Size(120, 22);
            brandListRefreshToolStripMenuItem.Text = "Yenile";
            brandListRefreshToolStripMenuItem.Click += brandListRefreshToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(117, 6);
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 420);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(875, 32);
            panelBottom.TabIndex = 9;
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(795, 5);
            bttnSearch.Name = "bttnSearch";
            bttnSearch.Size = new Size(75, 28);
            bttnSearch.TabIndex = 1;
            bttnSearch.Text = "Ara...";
            bttnSearch.UseVisualStyleBackColor = true;
            bttnSearch.Click += bttnSearch_Click;
            // 
            // panelDgwFooter
            // 
            panelDgwFooter.Dock = DockStyle.Bottom;
            panelDgwFooter.Location = new Point(0, 452);
            panelDgwFooter.Name = "panelDgwFooter";
            panelDgwFooter.Size = new Size(875, 26);
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
            panelTop.Size = new Size(875, 38);
            panelTop.TabIndex = 10;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama....";
            txtSearch.Size = new Size(790, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // brandListControl
            // 
            brandListControl.ContextMenuStrip = contextMenuStrip1;
            brandListControl.Dock = DockStyle.Fill;
            brandListControl.Location = new Point(0, 38);
            brandListControl.Name = "brandListControl";
            brandListControl.Size = new Size(875, 382);
            brandListControl.TabIndex = 12;
            // 
            // frmBrandList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 478);
            Controls.Add(brandListControl);
            Controls.Add(panelBottom);
            Controls.Add(panelDgwFooter);
            Controls.Add(panelTop);
            Name = "frmBrandList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marka Listesi";
            Load += frmBrandList_Load;
            contextMenuStrip1.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem brandCartToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem brandAddToolStripMenuItem;
        private ToolStripMenuItem brandUpdateToolStripMenuItem;
        private ToolStripMenuItem brandDeleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem brandListRefreshToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnSearch;
        private System.Windows.Forms.Panel panelDgwFooter;
        private System.Windows.Forms.Panel panelTop;
        private TextBox txtSearch;
        private UserControllers.Brands.BrandListControl brandListControl;
    }
}