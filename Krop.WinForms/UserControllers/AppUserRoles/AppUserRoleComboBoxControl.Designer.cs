namespace Krop.WinForms.UserControllers.AppUserRoles
{
    partial class AppUserRoleComboBoxControl
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
            cmbBoxAppUserRoleSelect = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // cmbBoxAppUserRoleSelect
            // 
            cmbBoxAppUserRoleSelect.FormattingEnabled = true;
            cmbBoxAppUserRoleSelect.Location = new Point(15, 18);
            cmbBoxAppUserRoleSelect.Name = "cmbBoxAppUserRoleSelect";
            cmbBoxAppUserRoleSelect.Size = new Size(200, 23);
            cmbBoxAppUserRoleSelect.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 24;
            label2.Text = "Yetki Adı :";
            // 
            // AppUserRoleComboBoxControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbBoxAppUserRoleSelect);
            Controls.Add(label2);
            Name = "AppUserRoleComboBoxControl";
            Size = new Size(229, 44);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBoxAppUserRoleSelect;
        private Label label2;
    }
}
