﻿namespace Krop.WinForms.Forms.StockInputs
{
    partial class frmStockInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockInput));
            panelBottom = new System.Windows.Forms.Panel();
            bttnAdd = new Button();
            bttnUpdate = new Button();
            bttnDelete = new Button();
            panelLeft = new System.Windows.Forms.Panel();
            supplierComboBoxControl = new UserControllers.Suppliers.SupplierComboBoxControl();
            productComboBoxControl = new UserControllers.Products.ProductComboBoxControl();
            branchComboBoxControl = new UserControllers.Branches.BranchComboBoxControl();
            bttnNewBranch = new Button();
            bttnNewSupplier = new Button();
            bttnNewProduct = new Button();
            inputDateTimePicker = new DateTimePicker();
            label11 = new Label();
            txtDescription = new TextBox();
            label10 = new Label();
            label9 = new Label();
            txtQuantity = new TextBox();
            label8 = new Label();
            label7 = new Label();
            txtUnitPrice = new TextBox();
            label6 = new Label();
            txtInvoiceNumber = new TextBox();
            label5 = new Label();
            stockNotificationToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            stockTransferToolStripMenuItem = new ToolStripMenuItem();
            stockReceiptToolStripMenuItem = new ToolStripMenuItem();
            productionListToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            produuctListRefreshToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            productDeleteToolStripMenuItem = new ToolStripMenuItem();
            productUpdateToolStripMenuItem = new ToolStripMenuItem();
            productAddToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            productCartToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panelMid = new System.Windows.Forms.Panel();
            stockInputListControl = new UserControllers.StockInputListControl();
            panel1 = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            bttnSearch = new Button();
            panelBottom.SuspendLayout();
            panelLeft.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            panelMid.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnAdd);
            panelBottom.Controls.Add(bttnUpdate);
            panelBottom.Controls.Add(bttnDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 592);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1106, 41);
            panelBottom.TabIndex = 0;
            // 
            // bttnAdd
            // 
            bttnAdd.Dock = DockStyle.Right;
            bttnAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAdd.Image = (Image)resources.GetObject("bttnAdd.Image");
            bttnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            bttnAdd.Location = new Point(803, 0);
            bttnAdd.Name = "bttnAdd";
            bttnAdd.Size = new Size(90, 39);
            bttnAdd.TabIndex = 2;
            bttnAdd.Text = "Ekle";
            bttnAdd.UseVisualStyleBackColor = true;
            bttnAdd.Click += bttnAdd_Click;
            // 
            // bttnUpdate
            // 
            bttnUpdate.Dock = DockStyle.Right;
            bttnUpdate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnUpdate.Image = (Image)resources.GetObject("bttnUpdate.Image");
            bttnUpdate.ImageAlign = ContentAlignment.MiddleLeft;
            bttnUpdate.Location = new Point(893, 0);
            bttnUpdate.Name = "bttnUpdate";
            bttnUpdate.Size = new Size(121, 39);
            bttnUpdate.TabIndex = 1;
            bttnUpdate.Text = "Güncelle";
            bttnUpdate.UseVisualStyleBackColor = true;
            bttnUpdate.Click += bttnUpdate_Click;
            // 
            // bttnDelete
            // 
            bttnDelete.Dock = DockStyle.Right;
            bttnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnDelete.Image = (Image)resources.GetObject("bttnDelete.Image");
            bttnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            bttnDelete.Location = new Point(1014, 0);
            bttnDelete.Name = "bttnDelete";
            bttnDelete.Size = new Size(90, 39);
            bttnDelete.TabIndex = 0;
            bttnDelete.Text = "Sil";
            bttnDelete.UseVisualStyleBackColor = true;
            bttnDelete.Click += bttnDelete_Click;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(supplierComboBoxControl);
            panelLeft.Controls.Add(productComboBoxControl);
            panelLeft.Controls.Add(branchComboBoxControl);
            panelLeft.Controls.Add(bttnNewBranch);
            panelLeft.Controls.Add(bttnNewSupplier);
            panelLeft.Controls.Add(bttnNewProduct);
            panelLeft.Controls.Add(inputDateTimePicker);
            panelLeft.Controls.Add(label11);
            panelLeft.Controls.Add(txtDescription);
            panelLeft.Controls.Add(label10);
            panelLeft.Controls.Add(label9);
            panelLeft.Controls.Add(txtQuantity);
            panelLeft.Controls.Add(label8);
            panelLeft.Controls.Add(label7);
            panelLeft.Controls.Add(txtUnitPrice);
            panelLeft.Controls.Add(label6);
            panelLeft.Controls.Add(txtInvoiceNumber);
            panelLeft.Controls.Add(label5);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(10);
            panelLeft.Size = new Size(267, 592);
            panelLeft.TabIndex = 1;
            // 
            // supplierComboBoxControl
            // 
            supplierComboBoxControl.Location = new Point(0, 154);
            supplierComboBoxControl.Name = "supplierComboBoxControl";
            supplierComboBoxControl.Size = new Size(226, 49);
            supplierComboBoxControl.TabIndex = 25;
            // 
            // productComboBoxControl
            // 
            productComboBoxControl.Location = new Point(0, 67);
            productComboBoxControl.Name = "productComboBoxControl";
            productComboBoxControl.Size = new Size(231, 88);
            productComboBoxControl.TabIndex = 24;
            // 
            // branchComboBoxControl
            // 
            branchComboBoxControl.Location = new Point(0, 16);
            branchComboBoxControl.Name = "branchComboBoxControl";
            branchComboBoxControl.Size = new Size(227, 48);
            branchComboBoxControl.TabIndex = 23;
            // 
            // bttnNewBranch
            // 
            bttnNewBranch.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            bttnNewBranch.Location = new Point(235, 39);
            bttnNewBranch.Name = "bttnNewBranch";
            bttnNewBranch.Size = new Size(23, 23);
            bttnNewBranch.TabIndex = 22;
            bttnNewBranch.Text = "+";
            bttnNewBranch.UseVisualStyleBackColor = true;
            bttnNewBranch.Click += bttnNewBranch_Click;
            // 
            // bttnNewSupplier
            // 
            bttnNewSupplier.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            bttnNewSupplier.Location = new Point(235, 176);
            bttnNewSupplier.Name = "bttnNewSupplier";
            bttnNewSupplier.Size = new Size(23, 23);
            bttnNewSupplier.TabIndex = 21;
            bttnNewSupplier.Text = "+";
            bttnNewSupplier.UseVisualStyleBackColor = true;
            bttnNewSupplier.Click += bttnNewSupplier_Click;
            // 
            // bttnNewProduct
            // 
            bttnNewProduct.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            bttnNewProduct.Location = new Point(235, 85);
            bttnNewProduct.Name = "bttnNewProduct";
            bttnNewProduct.Size = new Size(23, 23);
            bttnNewProduct.TabIndex = 20;
            bttnNewProduct.Text = "+";
            bttnNewProduct.UseVisualStyleBackColor = true;
            bttnNewProduct.Click += bttnNewProduct_Click;
            // 
            // inputDateTimePicker
            // 
            inputDateTimePicker.Location = new Point(15, 356);
            inputDateTimePicker.Name = "inputDateTimePicker";
            inputDateTimePicker.Size = new Size(200, 23);
            inputDateTimePicker.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(15, 338);
            label11.Name = "label11";
            label11.Size = new Size(67, 15);
            label11.TabIndex = 18;
            label11.Text = "Giriş Tarihi :";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(15, 400);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Açıklama...";
            txtDescription.Size = new Size(200, 132);
            txtDescription.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(15, 382);
            label10.Name = "label10";
            label10.Size = new Size(62, 15);
            label10.TabIndex = 16;
            label10.Text = "Açıklama :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(183, 315);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 15;
            label9.Text = "Adet";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(15, 312);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.PlaceholderText = "Giriş Yapılacak Miktar..";
            txtQuantity.Size = new Size(158, 23);
            txtQuantity.TabIndex = 14;
            txtQuantity.Text = "0";
            txtQuantity.KeyPress += txtQuantity_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 294);
            label8.Name = "label8";
            label8.Size = new Size(125, 15);
            label8.TabIndex = 13;
            label8.Text = "Giriş Yapılacak Miktar :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(183, 268);
            label7.Name = "label7";
            label7.Size = new Size(13, 15);
            label7.TabIndex = 12;
            label7.Text = "₺";
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(14, 265);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.PlaceholderText = "Alış Birim Fiyatı...";
            txtUnitPrice.Size = new Size(159, 23);
            txtUnitPrice.TabIndex = 11;
            txtUnitPrice.Text = "0";
            txtUnitPrice.KeyPress += txtUnitPrice_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 247);
            label6.Name = "label6";
            label6.Size = new Size(91, 15);
            label6.TabIndex = 10;
            label6.Text = "Alış Birim Fiyat :";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Location = new Point(15, 222);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.PlaceholderText = "Fatura Numarası...";
            txtInvoiceNumber.Size = new Size(200, 23);
            txtInvoiceNumber.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 204);
            label5.Name = "label5";
            label5.Size = new Size(100, 15);
            label5.TabIndex = 8;
            label5.Text = "Fatura Numarası :";
            // 
            // stockNotificationToolStripMenuItem
            // 
            stockNotificationToolStripMenuItem.Name = "stockNotificationToolStripMenuItem";
            stockNotificationToolStripMenuItem.Size = new Size(157, 22);
            stockNotificationToolStripMenuItem.Text = "Stok Bildirimi";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(154, 6);
            // 
            // stockTransferToolStripMenuItem
            // 
            stockTransferToolStripMenuItem.Image = (Image)resources.GetObject("stockTransferToolStripMenuItem.Image");
            stockTransferToolStripMenuItem.Name = "stockTransferToolStripMenuItem";
            stockTransferToolStripMenuItem.Size = new Size(157, 22);
            stockTransferToolStripMenuItem.Text = "Stok Transferleri";
            // 
            // stockReceiptToolStripMenuItem
            // 
            stockReceiptToolStripMenuItem.Image = (Image)resources.GetObject("stockReceiptToolStripMenuItem.Image");
            stockReceiptToolStripMenuItem.Name = "stockReceiptToolStripMenuItem";
            stockReceiptToolStripMenuItem.Size = new Size(157, 22);
            stockReceiptToolStripMenuItem.Text = "Stock Girişleri";
            // 
            // productionListToolStripMenuItem
            // 
            productionListToolStripMenuItem.Image = (Image)resources.GetObject("productionListToolStripMenuItem.Image");
            productionListToolStripMenuItem.Name = "productionListToolStripMenuItem";
            productionListToolStripMenuItem.Size = new Size(157, 22);
            productionListToolStripMenuItem.Text = "Üretim Listesi";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(154, 6);
            // 
            // produuctListRefreshToolStripMenuItem
            // 
            produuctListRefreshToolStripMenuItem.Name = "produuctListRefreshToolStripMenuItem";
            produuctListRefreshToolStripMenuItem.Size = new Size(157, 22);
            produuctListRefreshToolStripMenuItem.Text = "Yenile";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(154, 6);
            // 
            // productDeleteToolStripMenuItem
            // 
            productDeleteToolStripMenuItem.Image = (Image)resources.GetObject("productDeleteToolStripMenuItem.Image");
            productDeleteToolStripMenuItem.Name = "productDeleteToolStripMenuItem";
            productDeleteToolStripMenuItem.Size = new Size(157, 22);
            productDeleteToolStripMenuItem.Text = "Sil";
            // 
            // productUpdateToolStripMenuItem
            // 
            productUpdateToolStripMenuItem.Image = (Image)resources.GetObject("productUpdateToolStripMenuItem.Image");
            productUpdateToolStripMenuItem.Name = "productUpdateToolStripMenuItem";
            productUpdateToolStripMenuItem.Size = new Size(157, 22);
            productUpdateToolStripMenuItem.Text = "Güncelle";
            // 
            // productAddToolStripMenuItem
            // 
            productAddToolStripMenuItem.Image = (Image)resources.GetObject("productAddToolStripMenuItem.Image");
            productAddToolStripMenuItem.Name = "productAddToolStripMenuItem";
            productAddToolStripMenuItem.Size = new Size(157, 22);
            productAddToolStripMenuItem.Text = "Ekle";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(154, 6);
            // 
            // productCartToolStripMenuItem
            // 
            productCartToolStripMenuItem.Image = (Image)resources.GetObject("productCartToolStripMenuItem.Image");
            productCartToolStripMenuItem.Name = "productCartToolStripMenuItem";
            productCartToolStripMenuItem.Size = new Size(157, 22);
            productCartToolStripMenuItem.Text = "Kart";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { productCartToolStripMenuItem, toolStripSeparator1, productAddToolStripMenuItem, productUpdateToolStripMenuItem, productDeleteToolStripMenuItem, toolStripSeparator2, produuctListRefreshToolStripMenuItem, toolStripSeparator3, productionListToolStripMenuItem, stockReceiptToolStripMenuItem, stockTransferToolStripMenuItem, toolStripSeparator4, stockNotificationToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(158, 226);
            // 
            // panelMid
            // 
            panelMid.Controls.Add(stockInputListControl);
            panelMid.Controls.Add(panel1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(267, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(839, 592);
            panelMid.TabIndex = 2;
            // 
            // stockInputListControl
            // 
            stockInputListControl.ContextMenuStrip = contextMenuStrip1;
            stockInputListControl.Dock = DockStyle.Fill;
            stockInputListControl.Location = new Point(10, 48);
            stockInputListControl.Name = "stockInputListControl";
            stockInputListControl.Size = new Size(819, 534);
            stockInputListControl.TabIndex = 14;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(bttnSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(819, 38);
            panel1.TabIndex = 13;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama....";
            txtSearch.Size = new Size(734, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(739, 5);
            bttnSearch.Name = "bttnSearch";
            bttnSearch.Size = new Size(75, 28);
            bttnSearch.TabIndex = 1;
            bttnSearch.Text = "Ara...";
            bttnSearch.UseVisualStyleBackColor = true;
            bttnSearch.Click += bttnSearch_Click;
            // 
            // frmStockInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1106, 633);
            Controls.Add(panelMid);
            Controls.Add(panelLeft);
            Controls.Add(panelBottom);
            Name = "frmStockInput";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stok Girişi";
            Load += frmStockInput_Load;
            panelBottom.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelLeft;
        private TextBox txtUnitPrice;
        private Label label6;
        private TextBox txtInvoiceNumber;
        private Label label5;
        private DateTimePicker inputDateTimePicker;
        private Label label11;
        private TextBox txtDescription;
        private Label label10;
        private Label label9;
        private TextBox txtQuantity;
        private Label label8;
        private Label label7;
        private ToolStripMenuItem stockNotificationToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem stockTransferToolStripMenuItem;
        private ToolStripMenuItem stockReceiptToolStripMenuItem;
        private ToolStripMenuItem productionListToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem produuctListRefreshToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem productDeleteToolStripMenuItem;
        private ToolStripMenuItem productUpdateToolStripMenuItem;
        private ToolStripMenuItem productAddToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem productCartToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panel1;
        private TextBox txtSearch;
        private Button bttnSearch;
        private Button bttnDelete;
        private Button bttnAdd;
        private Button bttnUpdate;
        private Button bttnNewProduct;
        private Button bttnNewBranch;
        private Button bttnNewSupplier;
        private UserControllers.StockInputListControl stockInputListControl;
        private UserControllers.Branches.BranchComboBoxControl branchComboBoxControl;
        private UserControllers.Products.ProductComboBoxControl productComboBoxControl;
        private UserControllers.Suppliers.SupplierComboBoxControl supplierComboBoxControl;
    }
}