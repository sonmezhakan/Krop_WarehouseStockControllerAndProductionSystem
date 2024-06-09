namespace Krop.WinForms.UserControllers.Employees
{
    partial class EmployeeComboBoxControl
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
            cmbBoxAppUserSelect = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // cmbBoxAppUserSelect
            // 
            cmbBoxAppUserSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxAppUserSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxAppUserSelect.FormattingEnabled = true;
            cmbBoxAppUserSelect.Location = new Point(15, 26);
            cmbBoxAppUserSelect.Name = "cmbBoxAppUserSelect";
            cmbBoxAppUserSelect.Size = new Size(200, 23);
            cmbBoxAppUserSelect.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 8);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 2;
            label1.Text = "Çalışan Kullanıcı Adı :";
            // 
            // EmployeeComboBoxControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbBoxAppUserSelect);
            Controls.Add(label1);
            Name = "EmployeeComboBoxControl";
            Size = new Size(226, 53);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBoxAppUserSelect;
        public Label label1;
    }
}
