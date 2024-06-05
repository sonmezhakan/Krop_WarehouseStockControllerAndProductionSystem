namespace Krop.WinForms.UserControllers.AppUsers
{
    partial class AppUserComboBoxControl
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
            cmbBoxAppUserSelect.FormattingEnabled = true;
            cmbBoxAppUserSelect.Location = new Point(15, 24);
            cmbBoxAppUserSelect.Name = "cmbBoxAppUserSelect";
            cmbBoxAppUserSelect.Size = new Size(200, 23);
            cmbBoxAppUserSelect.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 6);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 19;
            label1.Text = "Kullanıcı Adı :";
            // 
            // AppUserComboBoxControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbBoxAppUserSelect);
            Controls.Add(label1);
            Name = "AppUserComboBoxControl";
            Size = new Size(230, 50);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBoxAppUserSelect;
        private Label label1;
    }
}
