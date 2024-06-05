namespace Krop.WinForms.UserControllers.Products
{
    partial class ProductComboBoxControl
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
            cmbBoxProductCodeSelect = new ComboBox();
            labelCode = new Label();
            cmbBoxProductNameSelect = new ComboBox();
            labelName = new Label();
            SuspendLayout();
            // 
            // cmbBoxProductCodeSelect
            // 
            cmbBoxProductCodeSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxProductCodeSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxProductCodeSelect.FormattingEnabled = true;
            cmbBoxProductCodeSelect.Location = new Point(15, 63);
            cmbBoxProductCodeSelect.Name = "cmbBoxProductCodeSelect";
            cmbBoxProductCodeSelect.Size = new Size(200, 23);
            cmbBoxProductCodeSelect.TabIndex = 45;
            // 
            // labelCode
            // 
            labelCode.AutoSize = true;
            labelCode.Location = new Point(15, 45);
            labelCode.Name = "labelCode";
            labelCode.Size = new Size(70, 15);
            labelCode.TabIndex = 44;
            labelCode.Text = "Ürün Kodu :";
            // 
            // cmbBoxProductNameSelect
            // 
            cmbBoxProductNameSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxProductNameSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxProductNameSelect.FormattingEnabled = true;
            cmbBoxProductNameSelect.Location = new Point(15, 18);
            cmbBoxProductNameSelect.Name = "cmbBoxProductNameSelect";
            cmbBoxProductNameSelect.Size = new Size(200, 23);
            cmbBoxProductNameSelect.TabIndex = 43;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(15, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(60, 15);
            labelName.TabIndex = 42;
            labelName.Text = "Ürün Adı :";
            // 
            // ProductComboBoxControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbBoxProductCodeSelect);
            Controls.Add(labelCode);
            Controls.Add(cmbBoxProductNameSelect);
            Controls.Add(labelName);
            Name = "ProductComboBoxControl";
            Size = new Size(231, 88);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBoxProductCodeSelect;
        private ComboBox cmbBoxProductNameSelect;
        public Label labelCode;
        public Label labelName;
    }
}
