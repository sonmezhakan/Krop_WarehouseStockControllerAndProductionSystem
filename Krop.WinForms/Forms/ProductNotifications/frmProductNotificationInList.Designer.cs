namespace Krop.WinForms.Forms.ProductNotifications
{
    partial class frmProductNotificationInList
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
            txtSearch = new TextBox();
            panelTop = new System.Windows.Forms.Panel();
            bttnSearch = new Button();
            dgwProductNotificationInList = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwProductNotificationInList).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama...";
            txtSearch.Size = new Size(895, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(bttnSearch);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(5);
            panelTop.Size = new Size(980, 38);
            panelTop.TabIndex = 16;
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(900, 5);
            bttnSearch.Name = "bttnSearch";
            bttnSearch.Size = new Size(75, 28);
            bttnSearch.TabIndex = 1;
            bttnSearch.Text = "Ara...";
            bttnSearch.UseVisualStyleBackColor = true;
            // 
            // dgwProductNotificationInList
            // 
            dgwProductNotificationInList.AllowUserToAddRows = false;
            dgwProductNotificationInList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwProductNotificationInList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwProductNotificationInList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwProductNotificationInList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwProductNotificationInList.BackgroundColor = SystemColors.Control;
            dgwProductNotificationInList.BorderStyle = BorderStyle.None;
            dgwProductNotificationInList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductNotificationInList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwProductNotificationInList.Dock = DockStyle.Fill;
            dgwProductNotificationInList.Location = new Point(0, 0);
            dgwProductNotificationInList.Name = "dgwProductNotificationInList";
            dgwProductNotificationInList.ReadOnly = true;
            dgwProductNotificationInList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductNotificationInList.RowTemplate.Height = 25;
            dgwProductNotificationInList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwProductNotificationInList.Size = new Size(980, 541);
            dgwProductNotificationInList.TabIndex = 17;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(106, 26);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(105, 22);
            toolStripMenuItem1.Text = "Yenile";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // frmProductNotificationIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 541);
            Controls.Add(panelTop);
            Controls.Add(dgwProductNotificationInList);
            Name = "frmProductNotificationIn";
            Text = "Gelen Ürün Bildirimleri";
            Load += frmProductNotificationIn_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgwProductNotificationInList).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtSearch;
        private System.Windows.Forms.Panel panelTop;
        private Button bttnSearch;
        private DataGridView dgwProductNotificationInList;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}