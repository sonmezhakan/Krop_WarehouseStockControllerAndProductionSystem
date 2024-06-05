namespace Krop.WinForms.Forms.Productions
{
    partial class frmProduction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduction));
            panelBottom = new System.Windows.Forms.Panel();
            productionListControl = new UserControllers.Productions.ProductionListControl();
            panel1 = new System.Windows.Forms.Panel();
            txtProductionSearch = new TextBox();
            bttnProductionSearch = new Button();
            panelBottomBottom = new System.Windows.Forms.Panel();
            bttnAdd = new Button();
            bttnUpdate = new Button();
            bttnDelete = new Button();
            panelMid = new System.Windows.Forms.Panel();
            productReceiptListControl = new UserControllers.ProductReceipts.ProductReceiptListControl();
            panelTop = new System.Windows.Forms.Panel();
            txtProductReceiptSearch = new TextBox();
            bttnProductReceiptSearch = new Button();
            label4 = new Label();
            txtProductionQuantity = new TextBox();
            label5 = new Label();
            productionDateTimePicker = new DateTimePicker();
            label6 = new Label();
            label7 = new Label();
            txtDescription = new TextBox();
            branchComboBoxControl = new UserControllers.Branches.BranchComboBoxControl();
            panelLeft = new System.Windows.Forms.Panel();
            productComboBoxControl = new UserControllers.Products.ProductComboBoxControl();
            panelBottom.SuspendLayout();
            panel1.SuspendLayout();
            panelBottomBottom.SuspendLayout();
            panelMid.SuspendLayout();
            panelTop.SuspendLayout();
            panelLeft.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(productionListControl);
            panelBottom.Controls.Add(panel1);
            panelBottom.Controls.Add(panelBottomBottom);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 383);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(10, 10, 10, 0);
            panelBottom.Size = new Size(1264, 298);
            panelBottom.TabIndex = 0;
            // 
            // productionListControl
            // 
            productionListControl.Dock = DockStyle.Fill;
            productionListControl.Location = new Point(10, 48);
            productionListControl.Name = "productionListControl";
            productionListControl.Size = new Size(1244, 209);
            productionListControl.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtProductionSearch);
            panel1.Controls.Add(bttnProductionSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(1244, 38);
            panel1.TabIndex = 6;
            // 
            // txtProductionSearch
            // 
            txtProductionSearch.Dock = DockStyle.Fill;
            txtProductionSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtProductionSearch.Location = new Point(5, 5);
            txtProductionSearch.Name = "txtProductionSearch";
            txtProductionSearch.PlaceholderText = "Arama...";
            txtProductionSearch.Size = new Size(1159, 27);
            txtProductionSearch.TabIndex = 2;
            txtProductionSearch.TextChanged += txtProductionSearch_TextChanged;
            // 
            // bttnProductionSearch
            // 
            bttnProductionSearch.Dock = DockStyle.Right;
            bttnProductionSearch.Location = new Point(1164, 5);
            bttnProductionSearch.Name = "bttnProductionSearch";
            bttnProductionSearch.Size = new Size(75, 28);
            bttnProductionSearch.TabIndex = 1;
            bttnProductionSearch.Text = "Ara...";
            bttnProductionSearch.UseVisualStyleBackColor = true;
            // 
            // panelBottomBottom
            // 
            panelBottomBottom.Controls.Add(bttnAdd);
            panelBottomBottom.Controls.Add(bttnUpdate);
            panelBottomBottom.Controls.Add(bttnDelete);
            panelBottomBottom.Dock = DockStyle.Bottom;
            panelBottomBottom.Location = new Point(10, 257);
            panelBottomBottom.Name = "panelBottomBottom";
            panelBottomBottom.Size = new Size(1244, 41);
            panelBottomBottom.TabIndex = 1;
            // 
            // bttnAdd
            // 
            bttnAdd.Dock = DockStyle.Right;
            bttnAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAdd.Image = (Image)resources.GetObject("bttnAdd.Image");
            bttnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            bttnAdd.Location = new Point(943, 0);
            bttnAdd.Name = "bttnAdd";
            bttnAdd.Size = new Size(90, 41);
            bttnAdd.TabIndex = 5;
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
            bttnUpdate.Location = new Point(1033, 0);
            bttnUpdate.Name = "bttnUpdate";
            bttnUpdate.Size = new Size(121, 41);
            bttnUpdate.TabIndex = 4;
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
            bttnDelete.Location = new Point(1154, 0);
            bttnDelete.Name = "bttnDelete";
            bttnDelete.Size = new Size(90, 41);
            bttnDelete.TabIndex = 3;
            bttnDelete.Text = "Sil";
            bttnDelete.UseVisualStyleBackColor = true;
            bttnDelete.Click += bttnDelete_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(productReceiptListControl);
            panelMid.Controls.Add(panelTop);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(238, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(1026, 383);
            panelMid.TabIndex = 2;
            // 
            // productReceiptListControl
            // 
            productReceiptListControl.Dock = DockStyle.Fill;
            productReceiptListControl.Location = new Point(10, 48);
            productReceiptListControl.Name = "productReceiptListControl";
            productReceiptListControl.Size = new Size(1006, 325);
            productReceiptListControl.TabIndex = 7;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(txtProductReceiptSearch);
            panelTop.Controls.Add(bttnProductReceiptSearch);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(10, 10);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(5);
            panelTop.Size = new Size(1006, 38);
            panelTop.TabIndex = 6;
            // 
            // txtProductReceiptSearch
            // 
            txtProductReceiptSearch.Dock = DockStyle.Fill;
            txtProductReceiptSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtProductReceiptSearch.Location = new Point(5, 5);
            txtProductReceiptSearch.Name = "txtProductReceiptSearch";
            txtProductReceiptSearch.PlaceholderText = "Arama...";
            txtProductReceiptSearch.Size = new Size(921, 27);
            txtProductReceiptSearch.TabIndex = 2;
            txtProductReceiptSearch.TextChanged += txtProductReceiptSearch_TextChanged;
            // 
            // bttnProductReceiptSearch
            // 
            bttnProductReceiptSearch.Dock = DockStyle.Right;
            bttnProductReceiptSearch.Location = new Point(926, 5);
            bttnProductReceiptSearch.Name = "bttnProductReceiptSearch";
            bttnProductReceiptSearch.Size = new Size(75, 28);
            bttnProductReceiptSearch.TabIndex = 1;
            bttnProductReceiptSearch.Text = "Ara...";
            bttnProductReceiptSearch.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 155);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 6;
            label4.Text = "Üretilecek Miktar :";
            // 
            // txtProductionQuantity
            // 
            txtProductionQuantity.Location = new Point(14, 173);
            txtProductionQuantity.Name = "txtProductionQuantity";
            txtProductionQuantity.PlaceholderText = "Üretilecek Miktar...";
            txtProductionQuantity.Size = new Size(155, 23);
            txtProductionQuantity.TabIndex = 7;
            txtProductionQuantity.Text = "0";
            txtProductionQuantity.KeyPress += txtProductionQuantity_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(183, 176);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 7;
            label5.Text = "Adet";
            // 
            // productionDateTimePicker
            // 
            productionDateTimePicker.Location = new Point(14, 217);
            productionDateTimePicker.Name = "productionDateTimePicker";
            productionDateTimePicker.Size = new Size(200, 23);
            productionDateTimePicker.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 199);
            label6.Name = "label6";
            label6.Size = new Size(80, 15);
            label6.TabIndex = 9;
            label6.Text = "Üretim Tarihi :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 243);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 10;
            label7.Text = "Açıklama :";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(15, 261);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Açıklama...";
            txtDescription.Size = new Size(200, 109);
            txtDescription.TabIndex = 11;
            // 
            // branchComboBoxControl
            // 
            branchComboBoxControl.Location = new Point(0, 11);
            branchComboBoxControl.Name = "branchComboBoxControl";
            branchComboBoxControl.Size = new Size(227, 50);
            branchComboBoxControl.TabIndex = 12;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(productComboBoxControl);
            panelLeft.Controls.Add(branchComboBoxControl);
            panelLeft.Controls.Add(txtDescription);
            panelLeft.Controls.Add(label7);
            panelLeft.Controls.Add(label6);
            panelLeft.Controls.Add(productionDateTimePicker);
            panelLeft.Controls.Add(label5);
            panelLeft.Controls.Add(txtProductionQuantity);
            panelLeft.Controls.Add(label4);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(10);
            panelLeft.Size = new Size(238, 383);
            panelLeft.TabIndex = 1;
            // 
            // productComboBoxControl
            // 
            productComboBoxControl.Location = new Point(0, 61);
            productComboBoxControl.Name = "productComboBoxControl";
            productComboBoxControl.Size = new Size(231, 88);
            productComboBoxControl.TabIndex = 13;
            // 
            // frmProduction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(panelMid);
            Controls.Add(panelLeft);
            Controls.Add(panelBottom);
            Name = "frmProduction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Üretim";
            Load += frmProduction_Load;
            panelBottom.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelBottomBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelBottomBottom;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panel1;
        private TextBox txtProductionSearch;
        private Button bttnProductionSearch;
        private System.Windows.Forms.Panel panelTop;
        private TextBox txtProductReceiptSearch;
        private Button bttnProductReceiptSearch;
        private Button bttnAdd;
        private Button bttnUpdate;
        private Button bttnDelete;
        private UserControllers.ProductReceipts.ProductReceiptListControl productReceiptListControl;
        private UserControllers.Productions.ProductionListControl productionListControl;
        private Label label4;
        private TextBox txtProductionQuantity;
        private Label label5;
        private DateTimePicker productionDateTimePicker;
        private Label label6;
        private Label label7;
        private TextBox txtDescription;
        private UserControllers.Branches.BranchComboBoxControl branchComboBoxControl;
        private System.Windows.Forms.Panel panelLeft;
        private UserControllers.Products.ProductComboBoxControl productComboBoxControl;
    }
}