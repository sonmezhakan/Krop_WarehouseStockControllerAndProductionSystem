namespace Krop.WinForms.UserControllers.Brands
{
    partial class BrandComboBoxControl
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
            cmbBoxBrandSelect = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // cmbBoxBrandSelect
            // 
            cmbBoxBrandSelect.FormattingEnabled = true;
            cmbBoxBrandSelect.Location = new Point(15, 21);
            cmbBoxBrandSelect.Name = "cmbBoxBrandSelect";
            cmbBoxBrandSelect.Size = new Size(200, 23);
            cmbBoxBrandSelect.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 3);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 8;
            label4.Text = "Marka :";
            // 
            // BrandComboBoxControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbBoxBrandSelect);
            Controls.Add(label4);
            Name = "BrandComboBoxControl";
            Size = new Size(224, 49);
            Load += BrandComboBoxControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBoxBrandSelect;
        private Label label4;
    }
}
