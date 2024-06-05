namespace Krop.WinForms.Forms.Employees
{
    partial class frmEmployeeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeList));
            panelDgwFooter = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            bttnSearch = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            EmployeeCartToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            EmployeeAddToolStripMenuItem = new ToolStripMenuItem();
            EmployeeUpdateToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            EmployeeListRefreshToolStripMenuItem = new ToolStripMenuItem();
            panelBottom = new System.Windows.Forms.Panel();
            employeeListControl = new UserControllers.Employees.EmployeeListControl();
            panelTop.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelDgwFooter
            // 
            panelDgwFooter.Dock = DockStyle.Bottom;
            panelDgwFooter.Location = new Point(0, 501);
            panelDgwFooter.Name = "panelDgwFooter";
            panelDgwFooter.Size = new Size(932, 26);
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
            panelTop.Size = new Size(932, 38);
            panelTop.TabIndex = 14;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama...";
            txtSearch.Size = new Size(847, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(852, 5);
            bttnSearch.Name = "bttnSearch";
            bttnSearch.Size = new Size(75, 28);
            bttnSearch.TabIndex = 1;
            bttnSearch.Text = "Ara...";
            bttnSearch.UseVisualStyleBackColor = true;
            bttnSearch.Click += bttnSearch_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { EmployeeCartToolStripMenuItem, toolStripSeparator1, EmployeeAddToolStripMenuItem, EmployeeUpdateToolStripMenuItem, toolStripSeparator2, EmployeeListRefreshToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(121, 104);
            // 
            // EmployeeCartToolStripMenuItem
            // 
            EmployeeCartToolStripMenuItem.Image = (Image)resources.GetObject("EmployeeCartToolStripMenuItem.Image");
            EmployeeCartToolStripMenuItem.Name = "EmployeeCartToolStripMenuItem";
            EmployeeCartToolStripMenuItem.Size = new Size(120, 22);
            EmployeeCartToolStripMenuItem.Text = "Kart";
            EmployeeCartToolStripMenuItem.Click += EmployeeCartToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(117, 6);
            // 
            // EmployeeAddToolStripMenuItem
            // 
            EmployeeAddToolStripMenuItem.Image = (Image)resources.GetObject("EmployeeAddToolStripMenuItem.Image");
            EmployeeAddToolStripMenuItem.Name = "EmployeeAddToolStripMenuItem";
            EmployeeAddToolStripMenuItem.Size = new Size(120, 22);
            EmployeeAddToolStripMenuItem.Text = "Ekle";
            EmployeeAddToolStripMenuItem.Click += EmployeeAddToolStripMenuItem_Click;
            // 
            // EmployeeUpdateToolStripMenuItem
            // 
            EmployeeUpdateToolStripMenuItem.Image = (Image)resources.GetObject("EmployeeUpdateToolStripMenuItem.Image");
            EmployeeUpdateToolStripMenuItem.Name = "EmployeeUpdateToolStripMenuItem";
            EmployeeUpdateToolStripMenuItem.Size = new Size(120, 22);
            EmployeeUpdateToolStripMenuItem.Text = "Güncelle";
            EmployeeUpdateToolStripMenuItem.Click += EmployeeUpdateToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(117, 6);
            // 
            // EmployeeListRefreshToolStripMenuItem
            // 
            EmployeeListRefreshToolStripMenuItem.Name = "EmployeeListRefreshToolStripMenuItem";
            EmployeeListRefreshToolStripMenuItem.Size = new Size(120, 22);
            EmployeeListRefreshToolStripMenuItem.Text = "Yenile";
            EmployeeListRefreshToolStripMenuItem.Click += EmployeeListRefreshToolStripMenuItem_Click;
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 527);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(932, 32);
            panelBottom.TabIndex = 13;
            // 
            // employeeListControl
            // 
            employeeListControl.ContextMenuStrip = contextMenuStrip1;
            employeeListControl.Dock = DockStyle.Fill;
            employeeListControl.Location = new Point(0, 38);
            employeeListControl.Name = "employeeListControl";
            employeeListControl.Size = new Size(932, 463);
            employeeListControl.TabIndex = 16;
            // 
            // frmEmployeeList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 559);
            Controls.Add(employeeListControl);
            Controls.Add(panelDgwFooter);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Name = "frmEmployeeList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Çalışan Listesi";
            Load += frmEmployeeList_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelDgwFooter;
        private System.Windows.Forms.Panel panelTop;
        private TextBox txtSearch;
        private Button bttnSearch;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem EmployeeCartToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem EmployeeAddToolStripMenuItem;
        private ToolStripMenuItem EmployeeUpdateToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem EmployeeListRefreshToolStripMenuItem;
        private System.Windows.Forms.Panel panelBottom;
        private UserControllers.Employees.EmployeeListControl employeeListControl;
    }
}