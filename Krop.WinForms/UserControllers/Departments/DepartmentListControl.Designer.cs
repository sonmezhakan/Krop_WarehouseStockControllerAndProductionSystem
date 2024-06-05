namespace Krop.WinForms.UserControllers.Departments
{
    partial class DepartmentListControl
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
            dgwDepartmentList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwDepartmentList).BeginInit();
            SuspendLayout();
            // 
            // dgwDepartmentList
            // 
            dgwDepartmentList.AllowUserToAddRows = false;
            dgwDepartmentList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwDepartmentList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwDepartmentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwDepartmentList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwDepartmentList.BackgroundColor = SystemColors.Control;
            dgwDepartmentList.BorderStyle = BorderStyle.None;
            dgwDepartmentList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwDepartmentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwDepartmentList.Dock = DockStyle.Fill;
            dgwDepartmentList.Location = new Point(0, 0);
            dgwDepartmentList.Name = "dgwDepartmentList";
            dgwDepartmentList.ReadOnly = true;
            dgwDepartmentList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwDepartmentList.RowTemplate.Height = 25;
            dgwDepartmentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwDepartmentList.Size = new Size(814, 539);
            dgwDepartmentList.TabIndex = 14;
            // 
            // DepartmentListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwDepartmentList);
            Name = "DepartmentListControl";
            Size = new Size(814, 539);
            ((System.ComponentModel.ISupportInitialize)dgwDepartmentList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwDepartmentList;
    }
}
