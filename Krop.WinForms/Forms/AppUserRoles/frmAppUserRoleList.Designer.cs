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
            dgwAppUserRoleList = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            appUserRoleAddToolStripMenuItem = new ToolStripMenuItem();
            appUserRoleUpdateToolStripMenuItem = new ToolStripMenuItem();
            appUserRoleDeleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            appUserRoleListRefreshToolStripMenuItem = new ToolStripMenuItem();
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
            bttnSearch.Click += bttnSearch_Click;
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
            Load += frmAppUserRoleList_Load;
            ((System.ComponentModel.ISupportInitialize)dgwAppUserRoleList).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgwAppUserRoleList;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem appUserRoleAddToolStripMenuItem;
        private ToolStripMenuItem appUserRoleUpdateToolStripMenuItem;
        private ToolStripMenuItem appUserRoleDeleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem appUserRoleListRefreshToolStripMenuItem;
        private System.Windows.Forms.Panel panelBottom;
        private TextBox txtSearch;
        private Button bttnSearch;
        private System.Windows.Forms.Panel panelDgwFooter;
        private System.Windows.Forms.Panel panelTop;
    }
}