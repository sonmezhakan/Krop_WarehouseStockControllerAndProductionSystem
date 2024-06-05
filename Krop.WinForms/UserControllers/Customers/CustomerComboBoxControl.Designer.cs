namespace Krop.WinForms.UserControllers.Customers
{
    partial class CustomerComboBoxControl
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
            cmbBoxCustomerSelect = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // cmbBoxCustomerSelect
            // 
            cmbBoxCustomerSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxCustomerSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxCustomerSelect.FormattingEnabled = true;
            cmbBoxCustomerSelect.Location = new Point(15, 28);
            cmbBoxCustomerSelect.Name = "cmbBoxCustomerSelect";
            cmbBoxCustomerSelect.Size = new Size(200, 23);
            cmbBoxCustomerSelect.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 10);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 21;
            label1.Text = "Müşteri Adı :";
            // 
            // CustomerComboBoxControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbBoxCustomerSelect);
            Controls.Add(label1);
            Name = "CustomerComboBoxControl";
            Size = new Size(240, 52);
            Load += CustomerComboBoxControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBoxCustomerSelect;
        private Label label1;
    }
}
