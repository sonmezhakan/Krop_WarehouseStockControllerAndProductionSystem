﻿namespace Krop.WinForms.Suppliers
{
    partial class frmSupplierList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierList));
            bttnSearch = new Button();
            panel1 = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            supplierCartToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            supplierAddToolStripMenuItem = new ToolStripMenuItem();
            supplierUpdateToolStripMenuItem = new ToolStripMenuItem();
            supplierDeleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            supplierListRefreshToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            panelDgwFooter = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            supplierListControl = new UserControllers.Suppliers.SupplierListControl();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(924, 5);
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
            panel1.Size = new Size(1004, 38);
            panel1.TabIndex = 12;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama....";
            txtSearch.Size = new Size(919, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { supplierCartToolStripMenuItem, toolStripSeparator1, supplierAddToolStripMenuItem, supplierUpdateToolStripMenuItem, supplierDeleteToolStripMenuItem, toolStripSeparator2, supplierListRefreshToolStripMenuItem, toolStripSeparator4 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(121, 132);
            // 
            // supplierCartToolStripMenuItem
            // 
            supplierCartToolStripMenuItem.Image = (Image)resources.GetObject("supplierCartToolStripMenuItem.Image");
            supplierCartToolStripMenuItem.Name = "supplierCartToolStripMenuItem";
            supplierCartToolStripMenuItem.Size = new Size(120, 22);
            supplierCartToolStripMenuItem.Text = "Kart";
            supplierCartToolStripMenuItem.Click += supplierCartToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(117, 6);
            // 
            // supplierAddToolStripMenuItem
            // 
            supplierAddToolStripMenuItem.Image = (Image)resources.GetObject("supplierAddToolStripMenuItem.Image");
            supplierAddToolStripMenuItem.Name = "supplierAddToolStripMenuItem";
            supplierAddToolStripMenuItem.Size = new Size(120, 22);
            supplierAddToolStripMenuItem.Text = "Ekle";
            supplierAddToolStripMenuItem.Click += supplierAddToolStripMenuItem_Click;
            // 
            // supplierUpdateToolStripMenuItem
            // 
            supplierUpdateToolStripMenuItem.Image = (Image)resources.GetObject("supplierUpdateToolStripMenuItem.Image");
            supplierUpdateToolStripMenuItem.Name = "supplierUpdateToolStripMenuItem";
            supplierUpdateToolStripMenuItem.Size = new Size(120, 22);
            supplierUpdateToolStripMenuItem.Text = "Güncelle";
            supplierUpdateToolStripMenuItem.Click += supplierUpdateToolStripMenuItem_Click;
            // 
            // supplierDeleteToolStripMenuItem
            // 
            supplierDeleteToolStripMenuItem.Image = (Image)resources.GetObject("supplierDeleteToolStripMenuItem.Image");
            supplierDeleteToolStripMenuItem.Name = "supplierDeleteToolStripMenuItem";
            supplierDeleteToolStripMenuItem.Size = new Size(120, 22);
            supplierDeleteToolStripMenuItem.Text = "Sil";
            supplierDeleteToolStripMenuItem.Click += supplierDeleteToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(117, 6);
            // 
            // supplierListRefreshToolStripMenuItem
            // 
            supplierListRefreshToolStripMenuItem.Name = "supplierListRefreshToolStripMenuItem";
            supplierListRefreshToolStripMenuItem.Size = new Size(120, 22);
            supplierListRefreshToolStripMenuItem.Text = "Yenile";
            supplierListRefreshToolStripMenuItem.Click += supplierListRefreshToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(117, 6);
            // 
            // panelDgwFooter
            // 
            panelDgwFooter.Dock = DockStyle.Bottom;
            panelDgwFooter.Location = new Point(0, 477);
            panelDgwFooter.Name = "panelDgwFooter";
            panelDgwFooter.Size = new Size(1004, 26);
            panelDgwFooter.TabIndex = 10;
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 503);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1004, 32);
            panelBottom.TabIndex = 9;
            // 
            // supplierListControl
            // 
            supplierListControl.ContextMenuStrip = contextMenuStrip1;
            supplierListControl.Dock = DockStyle.Fill;
            supplierListControl.Location = new Point(0, 38);
            supplierListControl.Name = "supplierListControl";
            supplierListControl.Size = new Size(1004, 439);
            supplierListControl.TabIndex = 13;
            // 
            // frmSupplierList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1004, 535);
            Controls.Add(supplierListControl);
            Controls.Add(panel1);
            Controls.Add(panelDgwFooter);
            Controls.Add(panelBottom);
            Name = "frmSupplierList";
            Text = "Tedarikçi Listesi";
            Load += frmSupplierList_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button bttnSearch;
        private System.Windows.Forms.Panel panel1;
        private TextBox txtSearch;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem supplierCartToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem supplierAddToolStripMenuItem;
        private ToolStripMenuItem supplierUpdateToolStripMenuItem;
        private ToolStripMenuItem supplierDeleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem supplierListRefreshToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel panelDgwFooter;
        private System.Windows.Forms.Panel panelBottom;
        private UserControllers.Suppliers.SupplierListControl supplierListControl;
    }
}