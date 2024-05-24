namespace Krop.WinForms.Suppliers
{
    partial class frmSupplierDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierDelete));
            label10 = new Label();
            panelBottom = new System.Windows.Forms.Panel();
            bttnSupplierDelete = new Button();
            cmbBoxSupplierSelect = new ComboBox();
            panelMid = new System.Windows.Forms.Panel();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(21, 19);
            label10.Name = "label10";
            label10.Size = new Size(146, 15);
            label10.TabIndex = 18;
            label10.Text = "Silinecek Tedarikçinin Adı :";
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnSupplierDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 79);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(269, 41);
            panelBottom.TabIndex = 8;
            // 
            // bttnSupplierDelete
            // 
            bttnSupplierDelete.Dock = DockStyle.Right;
            bttnSupplierDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnSupplierDelete.Image = (Image)resources.GetObject("bttnSupplierDelete.Image");
            bttnSupplierDelete.Location = new Point(158, 0);
            bttnSupplierDelete.Name = "bttnSupplierDelete";
            bttnSupplierDelete.Size = new Size(99, 39);
            bttnSupplierDelete.TabIndex = 1;
            bttnSupplierDelete.Text = "Sil";
            bttnSupplierDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnSupplierDelete.UseVisualStyleBackColor = true;
            bttnSupplierDelete.Click += bttnSupplierDelete_Click;
            // 
            // cmbBoxSupplierSelect
            // 
            cmbBoxSupplierSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxSupplierSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxSupplierSelect.FormattingEnabled = true;
            cmbBoxSupplierSelect.Location = new Point(21, 37);
            cmbBoxSupplierSelect.Name = "cmbBoxSupplierSelect";
            cmbBoxSupplierSelect.Size = new Size(234, 23);
            cmbBoxSupplierSelect.TabIndex = 19;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(cmbBoxSupplierSelect);
            panelMid.Controls.Add(label10);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(269, 120);
            panelMid.TabIndex = 9;
            // 
            // frmSupplierDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(269, 120);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmSupplierDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tedarikçi Sil";
            Load += frmSupplierDelete_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label10;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnSupplierDelete;
        private ComboBox cmbBoxSupplierSelect;
        private System.Windows.Forms.Panel panelMid;
    }
}