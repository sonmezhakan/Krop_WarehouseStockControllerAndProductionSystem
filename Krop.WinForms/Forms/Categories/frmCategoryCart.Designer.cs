﻿namespace Krop.WinForms.Categories
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
            label1 = new Label();
            cmbBoxCategorySelect = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 2;
            label1.Text = "Kategori Adı:";
            // 
            // cmbBoxCategorySelect
            // 
            cmbBoxCategorySelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxCategorySelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxCategorySelect.FormattingEnabled = true;
            cmbBoxCategorySelect.Location = new Point(12, 34);
            cmbBoxCategorySelect.Name = "cmbBoxCategorySelect";
            cmbBoxCategorySelect.Size = new Size(251, 23);
            cmbBoxCategorySelect.TabIndex = 3;
            cmbBoxCategorySelect.SelectedIndexChanged += cmbCategorySelect_SelectedIndexChanged;
            // 
            // frmCategoryCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(275, 84);
            Controls.Add(cmbBoxCategorySelect);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCategoryCart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kategori Kartı";
            Load += frmCategoryCart_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ComboBox cmbBoxCategorySelect;
    }
}