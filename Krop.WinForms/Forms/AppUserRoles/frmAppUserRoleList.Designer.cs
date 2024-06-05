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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppUserRoleList));
            contextMenuStrip1 = new ContextMenuStrip(components);
            appUserRoleAddToolStripMenuItem = new ToolStripMenuItem();
            appUserRoleUpdateToolStripMenuItem = new ToolStripMenuItem();
            appUserRoleDeleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            appUserRoleListRefreshToolStripMenuItem = new ToolStripMenuItem();
            panelBottom = new System.Windows.Forms.Panel();
            panelDgwFooter = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            bttnSearch = new Button();
            appUserRoleListControl = new UserControllers.AppUserRoles.AppUserRoleListControl();
            contextMenuStrip1.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { appUserRoleAddToolStripMenuItem, appUserRoleUpdateToolStripMenuItem, appUserRoleDeleteToolStripMenuItem, toolStripSeparator2, appUserRoleListRefreshToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(121, 98);
            // 
            // appUserRoleAddToolStripMenuItem
            // 
            appUserRoleAddToolStripMenuItem.Image = (Image)resources.GetObject("appUserRoleAddToolStripMenuItem.Image");
            appUserRoleAddToolStripMenuItem.Name = "appUserRoleAddToolStripMenuItem";
            appUserRoleAddToolStripMenuItem.Size = new Size(120, 22);
            appUserRoleAddToolStripMenuItem.Text = "Ekle";
            appUserRoleAddToolStripMenuItem.Click += appUserRoleAddToolStripMenuItem_Click;
            // 
            // appUserRoleUpdateToolStripMenuItem
            // 
            appUserRoleUpdateToolStripMenuItem.Image = (Image)resources.GetObject("appUserRoleUpdateToolStripMenuItem.Image");
            appUserRoleUpdateToolStripMenuItem.Name = "appUserRoleUpdateToolStripMenuItem";
            appUserRoleUpdateToolStripMenuItem.Size = new Size(120, 22);
            appUserRoleUpdateToolStripMenuItem.Text = "Güncelle";
            appUserRoleUpdateToolStripMenuItem.Click += appUserRoleUpdateToolStripMenuItem_Click;
            // 
            // appUserRoleDeleteToolStripMenuItem
            // 
            appUserRoleDeleteToolStripMenuItem.Image = (Image)resources.GetObject("appUserRoleDeleteToolStripMenuItem.Image");
            appUserRoleDeleteToolStripMenuItem.Name = "appUserRoleDeleteToolStripMenuItem";
            appUserRoleDeleteToolStripMenuItem.Size = new Size(120, 22);
            appUserRoleDeleteToolStripMenuItem.Text = "Sil";
            appUserRoleDeleteToolStripMenuItem.Click += appUserRoleDeleteToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(117, 6);
            // 
            // appUserRoleListRefreshToolStripMenuItem
            // 
            appUserRoleListRefreshToolStripMenuItem.Name = "appUserRoleListRefreshToolStripMenuItem";
            appUserRoleListRefreshToolStripMenuItem.Size = new Size(120, 22);
            appUserRoleListRefreshToolStripMenuItem.Text = "Yenile";
            appUserRoleListRefreshToolStripMenuItem.Click += appUserRoleListRefreshToolStripMenuItem_Click;
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 387);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(920, 82);
            panelBottom.TabIndex = 9;
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
            panelTop.TabIndex = 15;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama....";
            txtSearch.Size = new Size(835, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
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
            // appUserRoleListControl
            // 
            appUserRoleListControl.ContextMenuStrip = contextMenuStrip1;
            appUserRoleListControl.Dock = DockStyle.Fill;
            appUserRoleListControl.Location = new Point(0, 38);
            appUserRoleListControl.Name = "appUserRoleListControl";
            appUserRoleListControl.Size = new Size(920, 349);
            appUserRoleListControl.TabIndex = 16;
            // 
            // frmAppUserRoleList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 495);
            Controls.Add(appUserRoleListControl);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Controls.Add(panelDgwFooter);
            Name = "frmAppUserRoleList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yetki Listesi";
            Load += frmAppUserRoleList_Load;
            contextMenuStrip1.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem appUserRoleAddToolStripMenuItem;
        private ToolStripMenuItem appUserRoleUpdateToolStripMenuItem;
        private ToolStripMenuItem appUserRoleDeleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem appUserRoleListRefreshToolStripMenuItem;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelDgwFooter;
        private System.Windows.Forms.Panel panelTop;
        private TextBox txtSearch;
        private Button bttnSearch;
        private UserControllers.AppUserRoles.AppUserRoleListControl appUserRoleListControl;
    }
}