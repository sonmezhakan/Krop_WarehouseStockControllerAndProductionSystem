namespace Krop.WinForms.Forms.Stocks
{
    partial class frmStockList
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
            panelDgwFooter = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            branchComboBoxControl = new UserControllers.Branches.BranchComboBoxControl();
            panel1 = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            bttnSearch = new Button();
            stockListControl = new UserControllers.Stocks.StockListControl();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            sıralaToolStripMenuItem = new ToolStripMenuItem();
            büyüktenKüçüğeToolStripMenuItem = new ToolStripMenuItem();
            küçüktenBüyüğüyeToolStripMenuItem = new ToolStripMenuItem();
            panelTop.SuspendLayout();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelDgwFooter
            // 
            panelDgwFooter.Dock = DockStyle.Bottom;
            panelDgwFooter.Location = new Point(0, 501);
            panelDgwFooter.Name = "panelDgwFooter";
            panelDgwFooter.Size = new Size(1071, 26);
            panelDgwFooter.TabIndex = 19;
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 527);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1071, 32);
            panelBottom.TabIndex = 17;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(branchComboBoxControl);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1071, 31);
            panelTop.TabIndex = 20;
            // 
            // branchComboBoxControl
            // 
            branchComboBoxControl.Location = new Point(125, 0);
            branchComboBoxControl.Name = "branchComboBoxControl";
            branchComboBoxControl.Size = new Size(227, 54);
            branchComboBoxControl.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(bttnSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 31);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(1071, 38);
            panel1.TabIndex = 21;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama...";
            txtSearch.Size = new Size(986, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(991, 5);
            bttnSearch.Name = "bttnSearch";
            bttnSearch.Size = new Size(75, 28);
            bttnSearch.TabIndex = 1;
            bttnSearch.Text = "Ara...";
            bttnSearch.UseVisualStyleBackColor = true;
            // 
            // stockListControl
            // 
            stockListControl.ContextMenuStrip = contextMenuStrip1;
            stockListControl.Dock = DockStyle.Fill;
            stockListControl.Location = new Point(0, 69);
            stockListControl.Name = "stockListControl";
            stockListControl.Size = new Size(1071, 432);
            stockListControl.TabIndex = 22;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, sıralaToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(212, 48);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(211, 22);
            toolStripMenuItem1.Text = "Kritik Miktarın Altındakiler";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // sıralaToolStripMenuItem
            // 
            sıralaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { büyüktenKüçüğeToolStripMenuItem, küçüktenBüyüğüyeToolStripMenuItem });
            sıralaToolStripMenuItem.Name = "sıralaToolStripMenuItem";
            sıralaToolStripMenuItem.Size = new Size(211, 22);
            sıralaToolStripMenuItem.Text = "Stok Miktarını Sırala";
            // 
            // büyüktenKüçüğeToolStripMenuItem
            // 
            büyüktenKüçüğeToolStripMenuItem.Name = "büyüktenKüçüğeToolStripMenuItem";
            büyüktenKüçüğeToolStripMenuItem.Size = new Size(167, 22);
            büyüktenKüçüğeToolStripMenuItem.Text = "Büyükten Küçüğe";
            büyüktenKüçüğeToolStripMenuItem.Click += büyüktenKüçüğeToolStripMenuItem_Click;
            // 
            // küçüktenBüyüğüyeToolStripMenuItem
            // 
            küçüktenBüyüğüyeToolStripMenuItem.Name = "küçüktenBüyüğüyeToolStripMenuItem";
            küçüktenBüyüğüyeToolStripMenuItem.Size = new Size(167, 22);
            küçüktenBüyüğüyeToolStripMenuItem.Text = "Küçükten Büyüğe";
            küçüktenBüyüğüyeToolStripMenuItem.Click += küçüktenBüyüğüyeToolStripMenuItem_Click;
            // 
            // frmStockList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 559);
            Controls.Add(stockListControl);
            Controls.Add(panel1);
            Controls.Add(panelTop);
            Controls.Add(panelDgwFooter);
            Controls.Add(panelBottom);
            Name = "frmStockList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stok Listesi";
            Load += frmStockList_Load;
            panelTop.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panelDgwFooter;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTop;
        private UserControllers.Branches.BranchComboBoxControl branchComboBoxControl;
        private System.Windows.Forms.Panel panel1;
        private TextBox txtSearch;
        private Button bttnSearch;
        private UserControllers.Stocks.StockListControl stockListControl;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem sıralaToolStripMenuItem;
        private ToolStripMenuItem büyüktenKüçüğeToolStripMenuItem;
        private ToolStripMenuItem küçüktenBüyüğüyeToolStripMenuItem;
    }
}