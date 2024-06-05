namespace Krop.WinForms.Products
{
    partial class frmProductReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductReceipt));
            panelBottom = new System.Windows.Forms.Panel();
            bttnAdd = new Button();
            bttnUpdate = new Button();
            bttnDelete = new Button();
            panel2 = new System.Windows.Forms.Panel();
            panelMidMid = new System.Windows.Forms.Panel();
            productReceiptListControl = new UserControllers.ProductReceipts.ProductReceiptListControl();
            contextMenuStrip1 = new ContextMenuStrip(components);
            SelectToolStripMenuItem = new ToolStripMenuItem();
            panelTop = new System.Windows.Forms.Panel();
            txtSearch = new TextBox();
            bttnSearch = new Button();
            panelMidLeft = new System.Windows.Forms.Panel();
            productComboBoxControl2 = new UserControllers.Products.ProductComboBoxControl();
            productComboBoxControl1 = new UserControllers.Products.ProductComboBoxControl();
            label6 = new Label();
            label5 = new Label();
            txtQuantity = new TextBox();
            panelBottom.SuspendLayout();
            panel2.SuspendLayout();
            panelMidMid.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            panelTop.SuspendLayout();
            panelMidLeft.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnAdd);
            panelBottom.Controls.Add(bttnUpdate);
            panelBottom.Controls.Add(bttnDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 502);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1095, 41);
            panelBottom.TabIndex = 0;
            // 
            // bttnAdd
            // 
            bttnAdd.Dock = DockStyle.Right;
            bttnAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAdd.Image = (Image)resources.GetObject("bttnAdd.Image");
            bttnAdd.Location = new Point(803, 0);
            bttnAdd.Name = "bttnAdd";
            bttnAdd.Size = new Size(92, 39);
            bttnAdd.TabIndex = 3;
            bttnAdd.Text = "Ekle";
            bttnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnAdd.UseVisualStyleBackColor = true;
            bttnAdd.Click += bttnAdd_Click;
            // 
            // bttnUpdate
            // 
            bttnUpdate.Dock = DockStyle.Right;
            bttnUpdate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnUpdate.Image = (Image)resources.GetObject("bttnUpdate.Image");
            bttnUpdate.Location = new Point(895, 0);
            bttnUpdate.Name = "bttnUpdate";
            bttnUpdate.Size = new Size(106, 39);
            bttnUpdate.TabIndex = 2;
            bttnUpdate.Text = "Güncelle";
            bttnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnUpdate.UseVisualStyleBackColor = true;
            bttnUpdate.Click += bttnUpdate_Click;
            // 
            // bttnDelete
            // 
            bttnDelete.Dock = DockStyle.Right;
            bttnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnDelete.Image = (Image)resources.GetObject("bttnDelete.Image");
            bttnDelete.Location = new Point(1001, 0);
            bttnDelete.Name = "bttnDelete";
            bttnDelete.Size = new Size(92, 39);
            bttnDelete.TabIndex = 1;
            bttnDelete.Text = "Sil";
            bttnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnDelete.UseVisualStyleBackColor = true;
            bttnDelete.Click += bttnDelete_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(panelMidMid);
            panel2.Controls.Add(panelTop);
            panel2.Controls.Add(panelMidLeft);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(1095, 502);
            panel2.TabIndex = 1;
            // 
            // panelMidMid
            // 
            panelMidMid.Controls.Add(productReceiptListControl);
            panelMidMid.Dock = DockStyle.Fill;
            panelMidMid.Location = new Point(239, 43);
            panelMidMid.Name = "panelMidMid";
            panelMidMid.Padding = new Padding(5);
            panelMidMid.Size = new Size(851, 454);
            panelMidMid.TabIndex = 7;
            // 
            // productReceiptListControl
            // 
            productReceiptListControl.ContextMenuStrip = contextMenuStrip1;
            productReceiptListControl.Dock = DockStyle.Fill;
            productReceiptListControl.Location = new Point(5, 5);
            productReceiptListControl.Name = "productReceiptListControl";
            productReceiptListControl.Size = new Size(841, 444);
            productReceiptListControl.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { SelectToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(93, 26);
            // 
            // SelectToolStripMenuItem
            // 
            SelectToolStripMenuItem.Name = "SelectToolStripMenuItem";
            SelectToolStripMenuItem.Size = new Size(92, 22);
            SelectToolStripMenuItem.Text = "Seç";
            SelectToolStripMenuItem.Click += SelectToolStripMenuItem_Click;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(bttnSearch);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(239, 5);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(5);
            panelTop.Size = new Size(851, 38);
            panelTop.TabIndex = 6;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Arama....";
            txtSearch.Size = new Size(766, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // bttnSearch
            // 
            bttnSearch.Dock = DockStyle.Right;
            bttnSearch.Location = new Point(771, 5);
            bttnSearch.Name = "bttnSearch";
            bttnSearch.Size = new Size(75, 28);
            bttnSearch.TabIndex = 1;
            bttnSearch.Text = "Ara...";
            bttnSearch.UseVisualStyleBackColor = true;
            bttnSearch.Click += bttnSearch_Click;
            // 
            // panelMidLeft
            // 
            panelMidLeft.ContextMenuStrip = contextMenuStrip1;
            panelMidLeft.Controls.Add(productComboBoxControl2);
            panelMidLeft.Controls.Add(productComboBoxControl1);
            panelMidLeft.Controls.Add(label6);
            panelMidLeft.Controls.Add(label5);
            panelMidLeft.Controls.Add(txtQuantity);
            panelMidLeft.Dock = DockStyle.Left;
            panelMidLeft.Location = new Point(5, 5);
            panelMidLeft.Name = "panelMidLeft";
            panelMidLeft.Padding = new Padding(10);
            panelMidLeft.Size = new Size(234, 492);
            panelMidLeft.TabIndex = 0;
            // 
            // productComboBoxControl2
            // 
            productComboBoxControl2.Location = new Point(0, 118);
            productComboBoxControl2.Name = "productComboBoxControl2";
            productComboBoxControl2.Size = new Size(231, 88);
            productComboBoxControl2.TabIndex = 22;
            // 
            // productComboBoxControl1
            // 
            productComboBoxControl1.Location = new Point(0, 29);
            productComboBoxControl1.Name = "productComboBoxControl1";
            productComboBoxControl1.Size = new Size(231, 88);
            productComboBoxControl1.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(181, 230);
            label6.Name = "label6";
            label6.Size = new Size(32, 15);
            label6.TabIndex = 21;
            label6.Text = "Adet";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 209);
            label5.Name = "label5";
            label5.Size = new Size(113, 15);
            label5.TabIndex = 20;
            label5.Text = "Kullanılacak Miktar :";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(15, 227);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.PlaceholderText = "0";
            txtQuantity.Size = new Size(160, 23);
            txtQuantity.TabIndex = 19;
            txtQuantity.Text = "0";
            txtQuantity.KeyPress += txtQuantity_KeyPress;
            // 
            // frmProductReceipt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 543);
            Controls.Add(panel2);
            Controls.Add(panelBottom);
            Name = "frmProductReceipt";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ürün Reçetesi";
            Load += frmProductReceipt_Load;
            panelBottom.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panelMidMid.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMidLeft.ResumeLayout(false);
            panelMidLeft.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMidLeft;
        private Label label6;
        private Label label5;
        private TextBox txtQuantity;
        private System.Windows.Forms.Panel panelTop;
        private TextBox txtSearch;
        private Button bttnSearch;
        private Button bttnAdd;
        private Button bttnUpdate;
        private Button bttnDelete;
        private System.Windows.Forms.Panel panelMidMid;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem SelectToolStripMenuItem;
        private UserControllers.ProductReceipts.ProductReceiptListControl productReceiptListControl;
        private UserControllers.Products.ProductComboBoxControl productComboBoxControl1;
        private UserControllers.Products.ProductComboBoxControl productComboBoxControl2;
    }
}