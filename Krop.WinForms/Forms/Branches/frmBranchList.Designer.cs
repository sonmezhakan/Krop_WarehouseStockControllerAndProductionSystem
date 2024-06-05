namespace Krop.WinForms.Forms.Branches
{
    partial class frmBranchList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBranchList));
            contextMenuStrip1 = new ContextMenuStrip(components);
            branchCartToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            branchAddToolStripMenuItem = new ToolStripMenuItem();
            branchUpdateToolStripMenuItem = new ToolStripMenuItem();
            branchDeleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            branchListRefreshToolStripMenuItem = new ToolStripMenuItem();
            panelBottom = new System.Windows.Forms.Panel();
            bttnSearch = new Button();
            panelDgwFooter = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            branchListControl = new UserControllers.Branches.BranchListControl();
            contextMenuStrip1.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { branchCartToolStripMenuItem, toolStripSeparator1, branchAddToolStripMenuItem, branchUpdateToolStripMenuItem, branchDeleteToolStripMenuItem, toolStripSeparator2, branchListRefreshToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(121, 126);
            // 
            // branchCartToolStripMenuItem
            // 
            branchCartToolStripMenuItem.Image = (Image)resources.GetObject("branchCartToolStripMenuItem.Image");
            branchCartToolStripMenuItem.Name = "branchCartToolStripMenuItem";
            branchCartToolStripMenuItem.Size = new Size(120, 22);
            branchCartToolStripMenuItem.Text = "Kart";
            branchCartToolStripMenuItem.Click += branchCartToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(117, 6);
            // 
            // branchAddToolStripMenuItem
            // 
            branchAddToolStripMenuItem.Image = (Image)resources.GetObject("branchAddToolStripMenuItem.Image");
            branchAddToolStripMenuItem.Name = "branchAddToolStripMenuItem";
            branchAddToolStripMenuItem.Size = new Size(120, 22);
            branchAddToolStripMenuItem.Text = "Ekle";
            branchAddToolStripMenuItem.Click += branchAddToolStripMenuItem_Click;
            // 
            // branchUpdateToolStripMenuItem
            // 
            branchUpdateToolStripMenuItem.Image = (Image)resources.GetObject("branchUpdateToolStripMenuItem.Image");
            branchUpdateToolStripMenuItem.Name = "branchUpdateToolStripMenuItem";
            branchUpdateToolStripMenuItem.Size = new Size(120, 22);
            branchUpdateToolStripMenuItem.Text = "Güncelle";
            branchUpdateToolStripMenuItem.Click += branchUpdateToolStripMenuItem_Click;
            // 
            // branchDeleteToolStripMenuItem
            // 
            branchDeleteToolStripMenuItem.Image = (Image)resources.GetObject("branchDeleteToolStripMenuItem.Image");
            branchDeleteToolStripMenuItem.Name = "branchDeleteToolStripMenuItem";
            branchDeleteToolStripMenuItem.Size = new Size(120, 22);
            branchDeleteToolStripMenuItem.Text = "Sil";
            branchDeleteToolStripMenuItem.Click += branchDeleteToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(117, 6);
            // 
            // branchListRefreshToolStripMenuItem
            // 
            branchListRefreshToolStripMenuItem.Name = "branchListRefreshToolStripMenuItem";
            branchListRefreshToolStripMenuItem.Size = new Size(120, 22);
            branchListRefreshToolStripMenuItem.Text = "Yenile";
            branchListRefreshToolStripMenuItem.Click += branchListRefreshToolStripMenuItem_Click;
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 531);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1123, 32);
            panelBottom.TabIndex = 13;
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(1043, 5);
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
            panelDgwFooter.Location = new Point(0, 563);
            panelDgwFooter.Name = "panelDgwFooter";
            panelDgwFooter.Size = new Size(1123, 26);
            panelDgwFooter.TabIndex = 15;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(bttnSearch);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(5);
            panelTop.Size = new Size(1123, 38);
            panelTop.TabIndex = 14;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama....";
            txtSearch.Size = new Size(1038, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // branchListControl
            // 
            branchListControl.ContextMenuStrip = contextMenuStrip1;
            branchListControl.Dock = DockStyle.Fill;
            branchListControl.Location = new Point(0, 38);
            branchListControl.Name = "branchListControl";
            branchListControl.Size = new Size(1123, 493);
            branchListControl.TabIndex = 16;
            // 
            // frmBranchList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1123, 589);
            Controls.Add(branchListControl);
            Controls.Add(panelBottom);
            Controls.Add(panelDgwFooter);
            Controls.Add(panelTop);
            Name = "frmBranchList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Şube Listesi";
            Load += frmBranchList_Load;
            contextMenuStrip1.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem branchCartToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem branchAddToolStripMenuItem;
        private ToolStripMenuItem branchUpdateToolStripMenuItem;
        private ToolStripMenuItem branchDeleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem branchListRefreshToolStripMenuItem;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnSearch;
        private System.Windows.Forms.Panel panelDgwFooter;
        private System.Windows.Forms.Panel panelTop;
        private TextBox txtSearch;
        private UserControllers.Branches.BranchListControl branchListControl;
    }
}