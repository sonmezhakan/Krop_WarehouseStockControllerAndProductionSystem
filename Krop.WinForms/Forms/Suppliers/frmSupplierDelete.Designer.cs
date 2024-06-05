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
            panelBottom = new System.Windows.Forms.Panel();
            bttnSupplierDelete = new Button();
            panelMid = new System.Windows.Forms.Panel();
            supplierComboBoxControl = new UserControllers.Suppliers.SupplierComboBoxControl();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnSupplierDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 72);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(229, 41);
            panelBottom.TabIndex = 8;
            // 
            // bttnSupplierDelete
            // 
            bttnSupplierDelete.Dock = DockStyle.Right;
            bttnSupplierDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnSupplierDelete.Image = (Image)resources.GetObject("bttnSupplierDelete.Image");
            bttnSupplierDelete.Location = new Point(118, 0);
            bttnSupplierDelete.Name = "bttnSupplierDelete";
            bttnSupplierDelete.Size = new Size(99, 39);
            bttnSupplierDelete.TabIndex = 1;
            bttnSupplierDelete.Text = "Sil";
            bttnSupplierDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnSupplierDelete.UseVisualStyleBackColor = true;
            bttnSupplierDelete.Click += bttnSupplierDelete_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(supplierComboBoxControl);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(229, 113);
            panelMid.TabIndex = 9;
            // 
            // supplierComboBoxControl
            // 
            supplierComboBoxControl.Location = new Point(0, 10);
            supplierComboBoxControl.Name = "supplierComboBoxControl";
            supplierComboBoxControl.Size = new Size(226, 49);
            supplierComboBoxControl.TabIndex = 0;
            // 
            // frmSupplierDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(229, 113);
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
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnSupplierDelete;
        private System.Windows.Forms.Panel panelMid;
        private UserControllers.Suppliers.SupplierComboBoxControl supplierComboBoxControl;
    }
}