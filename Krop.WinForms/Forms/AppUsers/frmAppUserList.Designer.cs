namespace Krop.WinForms.Forms.AppUsers
{
    partial class frmAppUserList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppUserList));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            appUserListRefreshToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            appUserUpdateToolStripMenuItem = new ToolStripMenuItem();
            appUserAddToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            contextMenuStrip1 = new ContextMenuStrip(components);
            appUserCartToolStripMenuItem = new ToolStripMenuItem();
            panelDgwFooter = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            bttnSearch = new Button();
            panelBottom = new System.Windows.Forms.Panel();
            dgwAppUserList = new DataGridView();
            contextMenuStrip1.SuspendLayout();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwAppUserList).BeginInit();
            SuspendLayout();
            // 
            // appUserListRefreshToolStripMenuItem
            // 
            appUserListRefreshToolStripMenuItem.Name = "appUserListRefreshToolStripMenuItem";
            appUserListRefreshToolStripMenuItem.Size = new Size(120, 22);
            appUserListRefreshToolStripMenuItem.Text = "Yenile";
            appUserListRefreshToolStripMenuItem.Click += appUserListRefreshToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(117, 6);
            // 
            // appUserUpdateToolStripMenuItem
            // 
            appUserUpdateToolStripMenuItem.Image = (Image)resources.GetObject("appUserUpdateToolStripMenuItem.Image");
            appUserUpdateToolStripMenuItem.Name = "appUserUpdateToolStripMenuItem";
            appUserUpdateToolStripMenuItem.Size = new Size(120, 22);
            appUserUpdateToolStripMenuItem.Text = "Güncelle";
            appUserUpdateToolStripMenuItem.Click += appUserUpdateToolStripMenuItem_Click;
            // 
            // appUserAddToolStripMenuItem
            // 
            appUserAddToolStripMenuItem.Image = (Image)resources.GetObject("appUserAddToolStripMenuItem.Image");
            appUserAddToolStripMenuItem.Name = "appUserAddToolStripMenuItem";
            appUserAddToolStripMenuItem.Size = new Size(120, 22);
            appUserAddToolStripMenuItem.Text = "Ekle";
            appUserAddToolStripMenuItem.Click += appUserAddToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(117, 6);
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { appUserCartToolStripMenuItem, toolStripSeparator1, appUserAddToolStripMenuItem, appUserUpdateToolStripMenuItem, toolStripSeparator2, appUserListRefreshToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(121, 104);
            // 
            // appUserCartToolStripMenuItem
            // 
            appUserCartToolStripMenuItem.Image = (Image)resources.GetObject("appUserCartToolStripMenuItem.Image");
            appUserCartToolStripMenuItem.Name = "appUserCartToolStripMenuItem";
            appUserCartToolStripMenuItem.Size = new Size(120, 22);
            appUserCartToolStripMenuItem.Text = "Kart";
            appUserCartToolStripMenuItem.Click += appUserCartToolStripMenuItem_Click;
            // 
            // panelDgwFooter
            // 
            panelDgwFooter.Dock = DockStyle.Bottom;
            panelDgwFooter.Location = new Point(0, 465);
            panelDgwFooter.Name = "panelDgwFooter";
            panelDgwFooter.Size = new Size(1015, 26);
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
            panelTop.Size = new Size(1015, 38);
            panelTop.TabIndex = 10;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama...";
            txtSearch.Size = new Size(930, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(935, 5);
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
            panelBottom.Location = new Point(0, 491);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1015, 32);
            panelBottom.TabIndex = 9;
            // 
            // dgwAppUserList
            // 
            dgwAppUserList.AllowUserToAddRows = false;
            dgwAppUserList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwAppUserList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwAppUserList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwAppUserList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwAppUserList.BackgroundColor = SystemColors.Control;
            dgwAppUserList.BorderStyle = BorderStyle.None;
            dgwAppUserList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwAppUserList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwAppUserList.ContextMenuStrip = contextMenuStrip1;
            dgwAppUserList.Dock = DockStyle.Fill;
            dgwAppUserList.Location = new Point(0, 38);
            dgwAppUserList.Name = "dgwAppUserList";
            dgwAppUserList.ReadOnly = true;
            dgwAppUserList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwAppUserList.RowTemplate.Height = 25;
            dgwAppUserList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwAppUserList.Size = new Size(1015, 427);
            dgwAppUserList.TabIndex = 13;
            // 
            // frmAppUserList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 523);
            Controls.Add(dgwAppUserList);
            Controls.Add(panelDgwFooter);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Name = "frmAppUserList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kullanıcı Listesi";
            Load += frmAppUserList_Load;
            contextMenuStrip1.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgwAppUserList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripMenuItem appUserListRefreshToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem appUserUpdateToolStripMenuItem;
        private ToolStripMenuItem appUserAddToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem appUserCartToolStripMenuItem;
        private System.Windows.Forms.Panel panelDgwFooter;
        private System.Windows.Forms.Panel panelTop;
        private TextBox txtSearch;
        private Button bttnSearch;
        private System.Windows.Forms.Panel panelBottom;
        private DataGridView dgwAppUserList;
    }
}