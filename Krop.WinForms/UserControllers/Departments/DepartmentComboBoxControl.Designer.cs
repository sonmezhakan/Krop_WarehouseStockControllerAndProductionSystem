namespace Krop.WinForms.UserControllers.Departments
{
    partial class DepartmentComboBoxControl
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
            label3 = new Label();
            cmbBoxDepartmentSelect = new ComboBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 2);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 7;
            label3.Text = "Departman Adı :";
            // 
            // cmbBoxDepartmentSelect
            // 
            cmbBoxDepartmentSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxDepartmentSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxDepartmentSelect.FormattingEnabled = true;
            cmbBoxDepartmentSelect.Location = new Point(15, 20);
            cmbBoxDepartmentSelect.Name = "cmbBoxDepartmentSelect";
            cmbBoxDepartmentSelect.Size = new Size(200, 23);
            cmbBoxDepartmentSelect.TabIndex = 6;
            // 
            // DepartmentComboBoxControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(cmbBoxDepartmentSelect);
            Name = "DepartmentComboBoxControl";
            Size = new Size(230, 46);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private ComboBox cmbBoxDepartmentSelect;
    }
}
