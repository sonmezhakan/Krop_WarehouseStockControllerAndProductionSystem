namespace Krop.WinForms.UserControllers.Suppliers
{
    partial class SupplierComboBoxControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbBoxSupplierSelect = new ComboBox();
            label10 = new Label();
            SuspendLayout();
            // 
            // cmbBoxSupplierSelect
            // 
            cmbBoxSupplierSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxSupplierSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxSupplierSelect.FormattingEnabled = true;
            cmbBoxSupplierSelect.Location = new Point(15, 23);
            cmbBoxSupplierSelect.Name = "cmbBoxSupplierSelect";
            cmbBoxSupplierSelect.Size = new Size(200, 23);
            cmbBoxSupplierSelect.TabIndex = 21;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(15, 5);
            label10.Name = "label10";
            label10.Size = new Size(80, 15);
            label10.TabIndex = 20;
            label10.Text = "Tedarikçi Adı :";
            // 
            // SupplierComboBoxControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbBoxSupplierSelect);
            Controls.Add(label10);
            Name = "SupplierComboBoxControl";
            Size = new Size(226, 49);
            Load += SupplierComboBoxControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBoxSupplierSelect;
        private Label label10;
    }
}
