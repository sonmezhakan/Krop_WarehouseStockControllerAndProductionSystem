namespace Krop.WinForms.Customers
{
    partial class frmCustomerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerList));
            bttnSearch = new Button();
            panel1 = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripSeparator1 = new ToolStripSeparator();
            panelDgwFooter = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            customerCartToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            customerAddToolStripMenuItem = new ToolStripMenuItem();
            customerUpdateToolStripMenuItem = new ToolStripMenuItem();
            customerDeleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            customerRefreshToolStripMenuItem = new ToolStripMenuItem();
            customerListControl = new UserControllers.Customers.CustomerListControl();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(945, 5);
            bttnSearch.Name = "bttnSearch";
            bttnSearch.Size = new Size(75, 28);
            bttnSearch.TabIndex = 1;
            bttnSearch.Text = "Ara...";
            bttnSearch.UseVisualStyleBackColor = true;
            bttnSearch.Click += bttnSearch_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(bttnSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(1025, 38);
            panel1.TabIndex = 12;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama....";
            txtSearch.Size = new Size(940, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 6);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 6);
            // 
            // panelDgwFooter
            // 
            panelDgwFooter.Dock = DockStyle.Bottom;
            panelDgwFooter.Location = new Point(0, 465);
            panelDgwFooter.Name = "panelDgwFooter";
            panelDgwFooter.Size = new Size(1025, 26);
            panelDgwFooter.TabIndex = 10;
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 491);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1025, 32);
            panelBottom.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { customerCartToolStripMenuItem, toolStripSeparator3, customerAddToolStripMenuItem, customerUpdateToolStripMenuItem, customerDeleteToolStripMenuItem, toolStripSeparator4, customerRefreshToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(121, 126);
            // 
            // customerCartToolStripMenuItem
            // 
            customerCartToolStripMenuItem.Image = (Image)resources.GetObject("customerCartToolStripMenuItem.Image");
            customerCartToolStripMenuItem.Name = "customerCartToolStripMenuItem";
            customerCartToolStripMenuItem.Size = new Size(120, 22);
            customerCartToolStripMenuItem.Text = "Kart";
            customerCartToolStripMenuItem.Click += customerCartToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(117, 6);
            // 
            // customerAddToolStripMenuItem
            // 
            customerAddToolStripMenuItem.Image = (Image)resources.GetObject("customerAddToolStripMenuItem.Image");
            customerAddToolStripMenuItem.Name = "customerAddToolStripMenuItem";
            customerAddToolStripMenuItem.Size = new Size(120, 22);
            customerAddToolStripMenuItem.Text = "Ekle";
            customerAddToolStripMenuItem.Click += customerAddToolStripMenuItem_Click;
            // 
            // customerUpdateToolStripMenuItem
            // 
            customerUpdateToolStripMenuItem.Image = (Image)resources.GetObject("customerUpdateToolStripMenuItem.Image");
            customerUpdateToolStripMenuItem.Name = "customerUpdateToolStripMenuItem";
            customerUpdateToolStripMenuItem.Size = new Size(120, 22);
            customerUpdateToolStripMenuItem.Text = "Güncelle";
            customerUpdateToolStripMenuItem.Click += customerUpdateToolStripMenuItem_Click;
            // 
            // customerDeleteToolStripMenuItem
            // 
            customerDeleteToolStripMenuItem.Image = (Image)resources.GetObject("customerDeleteToolStripMenuItem.Image");
            customerDeleteToolStripMenuItem.Name = "customerDeleteToolStripMenuItem";
            customerDeleteToolStripMenuItem.Size = new Size(120, 22);
            customerDeleteToolStripMenuItem.Text = "Sil";
            customerDeleteToolStripMenuItem.Click += customerDeleteToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(117, 6);
            // 
            // customerRefreshToolStripMenuItem
            // 
            customerRefreshToolStripMenuItem.Name = "customerRefreshToolStripMenuItem";
            customerRefreshToolStripMenuItem.Size = new Size(120, 22);
            customerRefreshToolStripMenuItem.Text = "Yenile";
            customerRefreshToolStripMenuItem.Click += customerRefreshToolStripMenuItem_Click;
            // 
            // customerListControl
            // 
            customerListControl.ContextMenuStrip = contextMenuStrip1;
            customerListControl.Dock = DockStyle.Fill;
            customerListControl.Location = new Point(0, 38);
            customerListControl.Name = "customerListControl";
            customerListControl.Size = new Size(1025, 427);
            customerListControl.TabIndex = 13;
            // 
            // frmCustomerList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 523);
            Controls.Add(customerListControl);
            Controls.Add(panel1);
            Controls.Add(panelDgwFooter);
            Controls.Add(panelBottom);
            Name = "frmCustomerList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Müşteri Listesi";
            Load += frmCustomerList_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button bttnSearch;
        private System.Windows.Forms.Panel panel1;
        private TextBox txtSearch;
        private ToolStripMenuItem stockNotificationToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem stockTransferToolStripMenuItem;
        private ToolStripMenuItem stockReceiptToolStripMenuItem;
        private ToolStripMenuItem productionListToolStripMenuItem;
        private ToolStripMenuItem produuctListRefreshToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem productDeleteToolStripMenuItem;
        private ToolStripMenuItem productUpdateToolStripMenuItem;
        private ToolStripMenuItem productAddToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panelDgwFooter;
        private System.Windows.Forms.Panel panelBottom;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem customerCartToolStripMenuItem;
        private ToolStripMenuItem customerAddToolStripMenuItem;
        private ToolStripMenuItem customerUpdateToolStripMenuItem;
        private ToolStripMenuItem customerDeleteToolStripMenuItem;
        private ToolStripMenuItem customerRefreshToolStripMenuItem;
        private UserControllers.Customers.CustomerListControl customerListControl;
    }
}