namespace Krop.WinForms.Forms.ProductNotifications
{
    partial class frmProductNotficationSentList
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
            panelTop = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            bttnSearch = new Button();
            dgwProductNotificationSentList = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            güncelleToolStripMenuItem = new ToolStripMenuItem();
            bildirimGüncelleToolStripMenuItem = new ToolStripMenuItem();
            bildirimSilToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItem1 = new ToolStripMenuItem();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwProductNotificationSentList).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(bttnSearch);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(5);
            panelTop.Size = new Size(910, 38);
            panelTop.TabIndex = 14;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama...";
            txtSearch.Size = new Size(825, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(830, 5);
            bttnSearch.Name = "bttnSearch";
            bttnSearch.Size = new Size(75, 28);
            bttnSearch.TabIndex = 1;
            bttnSearch.Text = "Ara...";
            bttnSearch.UseVisualStyleBackColor = true;
            // 
            // dgwProductNotificationSentList
            // 
            dgwProductNotificationSentList.AllowUserToAddRows = false;
            dgwProductNotificationSentList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwProductNotificationSentList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwProductNotificationSentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwProductNotificationSentList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwProductNotificationSentList.BackgroundColor = SystemColors.Control;
            dgwProductNotificationSentList.BorderStyle = BorderStyle.None;
            dgwProductNotificationSentList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductNotificationSentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwProductNotificationSentList.ContextMenuStrip = contextMenuStrip1;
            dgwProductNotificationSentList.Dock = DockStyle.Fill;
            dgwProductNotificationSentList.Location = new Point(0, 38);
            dgwProductNotificationSentList.Name = "dgwProductNotificationSentList";
            dgwProductNotificationSentList.ReadOnly = true;
            dgwProductNotificationSentList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductNotificationSentList.RowTemplate.Height = 25;
            dgwProductNotificationSentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwProductNotificationSentList.Size = new Size(910, 473);
            dgwProductNotificationSentList.TabIndex = 15;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { güncelleToolStripMenuItem, bildirimGüncelleToolStripMenuItem, bildirimSilToolStripMenuItem, toolStripSeparator1, toolStripMenuItem1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 120);
            // 
            // güncelleToolStripMenuItem
            // 
            güncelleToolStripMenuItem.Name = "güncelleToolStripMenuItem";
            güncelleToolStripMenuItem.Size = new Size(180, 22);
            güncelleToolStripMenuItem.Text = "Bildirim Gönder";
            güncelleToolStripMenuItem.Click += güncelleToolStripMenuItem_Click;
            // 
            // bildirimGüncelleToolStripMenuItem
            // 
            bildirimGüncelleToolStripMenuItem.Name = "bildirimGüncelleToolStripMenuItem";
            bildirimGüncelleToolStripMenuItem.Size = new Size(180, 22);
            bildirimGüncelleToolStripMenuItem.Text = "Bildirim Güncelle";
            bildirimGüncelleToolStripMenuItem.Click += bildirimGüncelleToolStripMenuItem_Click;
            // 
            // bildirimSilToolStripMenuItem
            // 
            bildirimSilToolStripMenuItem.Name = "bildirimSilToolStripMenuItem";
            bildirimSilToolStripMenuItem.Size = new Size(180, 22);
            bildirimSilToolStripMenuItem.Text = "Bildirim Sil";
            bildirimSilToolStripMenuItem.Click += bildirimSilToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 22);
            toolStripMenuItem1.Text = "Yenile";
            // 
            // frmProductNotficationSentList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 511);
            Controls.Add(dgwProductNotificationSentList);
            Controls.Add(panelTop);
            Name = "frmProductNotficationSentList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gönderilen Bildirimler";
            Load += frmProductNotficationSentList_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgwProductNotificationSentList).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private TextBox txtSearch;
        private Button bttnSearch;
        private DataGridView dgwProductNotificationSentList;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem güncelleToolStripMenuItem;
        private ToolStripMenuItem bildirimGüncelleToolStripMenuItem;
        private ToolStripMenuItem bildirimSilToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}