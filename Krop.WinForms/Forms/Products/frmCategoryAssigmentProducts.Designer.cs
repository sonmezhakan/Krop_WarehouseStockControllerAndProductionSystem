namespace Krop.WinForms.Products
{
    partial class frmCategoryAssigmentProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoryAssigmentProducts));
            panelBottom = new System.Windows.Forms.Panel();
            panelMid = new System.Windows.Forms.Panel();
            checkedListBoxProductList = new CheckedListBox();
            label1 = new Label();
            cmbBoxCategorySelect = new ComboBox();
            label2 = new Label();
            bttnCategoryProductAdd = new Button();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnCategoryProductAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 378);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 15, 0);
            panelBottom.Size = new Size(304, 39);
            panelBottom.TabIndex = 0;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(label2);
            panelMid.Controls.Add(cmbBoxCategorySelect);
            panelMid.Controls.Add(label1);
            panelMid.Controls.Add(checkedListBoxProductList);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(304, 378);
            panelMid.TabIndex = 1;
            // 
            // checkedListBoxProductList
            // 
            checkedListBoxProductList.FormattingEnabled = true;
            checkedListBoxProductList.Location = new Point(12, 74);
            checkedListBoxProductList.Name = "checkedListBoxProductList";
            checkedListBoxProductList.Size = new Size(275, 292);
            checkedListBoxProductList.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 1;
            label1.Text = "Atanacak Kategori :";
            // 
            // cmbBoxCategorySelect
            // 
            cmbBoxCategorySelect.FormattingEnabled = true;
            cmbBoxCategorySelect.Location = new Point(12, 30);
            cmbBoxCategorySelect.Name = "cmbBoxCategorySelect";
            cmbBoxCategorySelect.Size = new Size(275, 23);
            cmbBoxCategorySelect.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 56);
            label2.Name = "label2";
            label2.Size = new Size(151, 15);
            label2.TabIndex = 3;
            label2.Text = "Kategori Atanacak Ürünler :";
            // 
            // bttnCategoryProductAdd
            // 
            bttnCategoryProductAdd.Dock = DockStyle.Right;
            bttnCategoryProductAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnCategoryProductAdd.Image = (Image)resources.GetObject("bttnCategoryProductAdd.Image");
            bttnCategoryProductAdd.Location = new Point(195, 0);
            bttnCategoryProductAdd.Name = "bttnCategoryProductAdd";
            bttnCategoryProductAdd.Size = new Size(92, 37);
            bttnCategoryProductAdd.TabIndex = 1;
            bttnCategoryProductAdd.Text = "Ekle";
            bttnCategoryProductAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnCategoryProductAdd.UseVisualStyleBackColor = true;
            // 
            // frmCategoryAssigmentProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 417);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCategoryAssigmentProducts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ürünlere Toplu Kategori Ataması";
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMid;
        private ComboBox cmbBoxCategorySelect;
        private Label label1;
        private CheckedListBox checkedListBoxProductList;
        private Label label2;
        private Button bttnCategoryProductAdd;
    }
}