namespace Krop.WinForms.UserControllers.Branches
{
    partial class BranchComboBoxControl
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
            labelName = new Label();
            cmbBoxBranchSelect = new ComboBox();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(15, 4);
            labelName.Name = "labelName";
            labelName.Size = new Size(60, 15);
            labelName.TabIndex = 27;
            labelName.Text = "Şube Adı :";
            // 
            // cmbBoxBranchSelect
            // 
            cmbBoxBranchSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxBranchSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxBranchSelect.FormattingEnabled = true;
            cmbBoxBranchSelect.Location = new Point(15, 22);
            cmbBoxBranchSelect.Name = "cmbBoxBranchSelect";
            cmbBoxBranchSelect.Size = new Size(200, 23);
            cmbBoxBranchSelect.TabIndex = 26;
            // 
            // BranchComboBoxControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelName);
            Controls.Add(cmbBoxBranchSelect);
            Name = "BranchComboBoxControl";
            Size = new Size(227, 54);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbBoxBranchSelect;
        public Label labelName;
    }
}
