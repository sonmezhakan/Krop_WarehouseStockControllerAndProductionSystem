namespace Krop.WinForms.UserControllers.Brands
{
    partial class BrandListControl
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
            dgwBrandList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwBrandList).BeginInit();
            SuspendLayout();
            // 
            // dgwBrandList
            // 
            dgwBrandList.AllowUserToAddRows = false;
            dgwBrandList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwBrandList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwBrandList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwBrandList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwBrandList.BackgroundColor = SystemColors.Control;
            dgwBrandList.BorderStyle = BorderStyle.None;
            dgwBrandList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwBrandList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwBrandList.Dock = DockStyle.Fill;
            dgwBrandList.Location = new Point(0, 0);
            dgwBrandList.Name = "dgwBrandList";
            dgwBrandList.ReadOnly = true;
            dgwBrandList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwBrandList.RowTemplate.Height = 25;
            dgwBrandList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwBrandList.Size = new Size(728, 480);
            dgwBrandList.TabIndex = 13;
            // 
            // BrandListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwBrandList);
            Name = "BrandListControl";
            Size = new Size(728, 480);
            ((System.ComponentModel.ISupportInitialize)dgwBrandList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwBrandList;
    }
}
