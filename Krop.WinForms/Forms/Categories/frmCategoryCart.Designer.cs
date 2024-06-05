namespace Krop.WinForms.Categories
{
    partial class frmCategoryCart
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
            categoryComboBoxControl = new UserControllers.Categories.CategoryComboBoxControl();
            SuspendLayout();
            // 
            // categoryComboBoxControl
            // 
            categoryComboBoxControl.Location = new Point(0, 12);
            categoryComboBoxControl.Name = "categoryComboBoxControl";
            categoryComboBoxControl.Size = new Size(240, 51);
            categoryComboBoxControl.TabIndex = 0;
            // 
            // frmCategoryCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(242, 84);
            Controls.Add(categoryComboBoxControl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCategoryCart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kategori Kartı";
            Load += frmCategoryCart_Load;
            ResumeLayout(false);
        }

        #endregion

        private UserControllers.Categories.CategoryComboBoxControl categoryComboBoxControl;
    }
}