namespace Krop.WinForms.UserControllers.Categories
{
    partial class CategoryListControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgwCategoryList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwCategoryList).BeginInit();
            SuspendLayout();
            // 
            // dgwCategoryList
            // 
            dgwCategoryList.AllowUserToAddRows = false;
            dgwCategoryList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwCategoryList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwCategoryList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwCategoryList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwCategoryList.BackgroundColor = SystemColors.Control;
            dgwCategoryList.BorderStyle = BorderStyle.None;
            dgwCategoryList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwCategoryList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwCategoryList.Dock = DockStyle.Fill;
            dgwCategoryList.Location = new Point(0, 0);
            dgwCategoryList.Name = "dgwCategoryList";
            dgwCategoryList.ReadOnly = true;
            dgwCategoryList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwCategoryList.RowTemplate.Height = 25;
            dgwCategoryList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwCategoryList.Size = new Size(749, 465);
            dgwCategoryList.TabIndex = 9;
            // 
            // CategoryListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwCategoryList);
            Name = "CategoryListControl";
            Size = new Size(749, 465);
            ((System.ComponentModel.ISupportInitialize)dgwCategoryList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwCategoryList;
    }
}
