namespace Krop.WinForms.Forms.Departments
{
    partial class frmDepartmentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepartmentList));
            departmentListRefreshToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            departmentDeleteToolStripMenuItem = new ToolStripMenuItem();
            departmentUpdateToolStripMenuItem = new ToolStripMenuItem();
            departmentAddToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            contextMenuStrip1 = new ContextMenuStrip(components);
            departmentCartToolStripMenuItem = new ToolStripMenuItem();
            panelDgwFooter = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            bttnSearch = new Button();
            panelBottom = new System.Windows.Forms.Panel();
            departmentListControl = new UserControllers.Departments.DepartmentListControl();
            contextMenuStrip1.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // departmentListRefreshToolStripMenuItem
            // 
            departmentListRefreshToolStripMenuItem.Name = "departmentListRefreshToolStripMenuItem";
            departmentListRefreshToolStripMenuItem.Size = new Size(120, 22);
            departmentListRefreshToolStripMenuItem.Text = "Yenile";
            departmentListRefreshToolStripMenuItem.Click += departmentListRefreshToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(117, 6);
            // 
            // departmentDeleteToolStripMenuItem
            // 
            departmentDeleteToolStripMenuItem.Image = (Image)resources.GetObject("departmentDeleteToolStripMenuItem.Image");
            departmentDeleteToolStripMenuItem.Name = "departmentDeleteToolStripMenuItem";
            departmentDeleteToolStripMenuItem.Size = new Size(120, 22);
            departmentDeleteToolStripMenuItem.Text = "Sil";
            departmentDeleteToolStripMenuItem.Click += departmentDeleteToolStripMenuItem_Click;
            // 
            // departmentUpdateToolStripMenuItem
            // 
            departmentUpdateToolStripMenuItem.Image = (Image)resources.GetObject("departmentUpdateToolStripMenuItem.Image");
            departmentUpdateToolStripMenuItem.Name = "departmentUpdateToolStripMenuItem";
            departmentUpdateToolStripMenuItem.Size = new Size(120, 22);
            departmentUpdateToolStripMenuItem.Text = "Güncelle";
            departmentUpdateToolStripMenuItem.Click += departmentUpdateToolStripMenuItem_Click;
            // 
            // departmentAddToolStripMenuItem
            // 
            departmentAddToolStripMenuItem.Image = (Image)resources.GetObject("departmentAddToolStripMenuItem.Image");
            departmentAddToolStripMenuItem.Name = "departmentAddToolStripMenuItem";
            departmentAddToolStripMenuItem.Size = new Size(120, 22);
            departmentAddToolStripMenuItem.Text = "Ekle";
            departmentAddToolStripMenuItem.Click += departmentAddToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(117, 6);
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { departmentCartToolStripMenuItem, toolStripSeparator1, departmentAddToolStripMenuItem, departmentUpdateToolStripMenuItem, departmentDeleteToolStripMenuItem, toolStripSeparator2, departmentListRefreshToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(121, 126);
            // 
            // departmentCartToolStripMenuItem
            // 
            departmentCartToolStripMenuItem.Image = (Image)resources.GetObject("departmentCartToolStripMenuItem.Image");
            departmentCartToolStripMenuItem.Name = "departmentCartToolStripMenuItem";
            departmentCartToolStripMenuItem.Size = new Size(120, 22);
            departmentCartToolStripMenuItem.Text = "Kart";
            departmentCartToolStripMenuItem.Click += departmentCartToolStripMenuItem_Click;
            // 
            // panelDgwFooter
            // 
            panelDgwFooter.Dock = DockStyle.Bottom;
            panelDgwFooter.Location = new Point(0, 525);
            panelDgwFooter.Name = "panelDgwFooter";
            panelDgwFooter.Size = new Size(939, 26);
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
            panelTop.Size = new Size(939, 38);
            panelTop.TabIndex = 10;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama...";
            txtSearch.Size = new Size(854, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(859, 5);
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
            panelBottom.Location = new Point(0, 551);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(939, 32);
            panelBottom.TabIndex = 9;
            // 
            // departmentListControl
            // 
            departmentListControl.ContextMenuStrip = contextMenuStrip1;
            departmentListControl.Dock = DockStyle.Fill;
            departmentListControl.Location = new Point(0, 38);
            departmentListControl.Name = "departmentListControl";
            departmentListControl.Size = new Size(939, 487);
            departmentListControl.TabIndex = 12;
            // 
            // frmDepartmentList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 583);
            Controls.Add(departmentListControl);
            Controls.Add(panelDgwFooter);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Name = "frmDepartmentList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Departman Listesi";
            Load += frmDepartmentList_Load;
            contextMenuStrip1.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripMenuItem departmentListRefreshToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem departmentDeleteToolStripMenuItem;
        private ToolStripMenuItem departmentUpdateToolStripMenuItem;
        private ToolStripMenuItem departmentAddToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem departmentCartToolStripMenuItem;
        private System.Windows.Forms.Panel panelDgwFooter;
        private System.Windows.Forms.Panel panelTop;
        private TextBox txtSearch;
        private Button bttnSearch;
        private System.Windows.Forms.Panel panelBottom;
        private UserControllers.Departments.DepartmentListControl departmentListControl;
    }
}