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
            bttnSupplierAdd = new Button();
            cmbBoxSupplierSelect = new ComboBox();
            panelMid = new System.Windows.Forms.Panel();
            bttnSelect = new Button();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(21, 19);
            label10.Name = "label10";
            label10.Size = new Size(203, 15);
            label10.TabIndex = 18;
            label10.Text = "Silinecek Tedarikçi Telefon Numarası :";
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnSupplierAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 79);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(302, 41);
            panelBottom.TabIndex = 8;
            // 
            // bttnSupplierAdd
            // 
            bttnSupplierAdd.Dock = DockStyle.Right;
            bttnSupplierAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnSupplierAdd.Image = (Image)resources.GetObject("bttnSupplierAdd.Image");
            bttnSupplierAdd.Location = new Point(191, 0);
            bttnSupplierAdd.Name = "bttnSupplierAdd";
            bttnSupplierAdd.Size = new Size(99, 39);
            bttnSupplierAdd.TabIndex = 1;
            bttnSupplierAdd.Text = "Sil";
            bttnSupplierAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnSupplierAdd.UseVisualStyleBackColor = true;
            // 
            // cmbBoxSupplierSelect
            // 
            cmbBoxSupplierSelect.FormattingEnabled = true;
            cmbBoxSupplierSelect.Location = new Point(21, 37);
            cmbBoxSupplierSelect.Name = "cmbBoxSupplierSelect";
            cmbBoxSupplierSelect.Size = new Size(234, 23);
            cmbBoxSupplierSelect.TabIndex = 19;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(bttnSelect);
            panelMid.Controls.Add(cmbBoxSupplierSelect);
            panelMid.Controls.Add(label10);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(302, 120);
            panelMid.TabIndex = 9;
            // 
            // bttnSelect
            // 
            bttnSelect.Location = new Point(261, 37);
            bttnSelect.Name = "bttnSelect";
            bttnSelect.Size = new Size(31, 23);
            bttnSelect.TabIndex = 20;
            bttnSelect.Text = "...";
            bttnSelect.UseVisualStyleBackColor = true;
            // 
            // frmSupplierDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 120);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmSupplierDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tedarikçi Sil";
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label10;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnSupplierAdd;
        private ComboBox cmbBoxSupplierSelect;
        private System.Windows.Forms.Panel panelMid;
        private Button bttnSelect;
    }
}