namespace Krop.WinForms.UserControllers.Employees
{
    partial class EmployeeListControl
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
            dgwEmployeeList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwEmployeeList).BeginInit();
            SuspendLayout();
            // 
            // dgwEmployeeList
            // 
            dgwEmployeeList.AllowUserToAddRows = false;
            dgwEmployeeList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwEmployeeList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwEmployeeList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwEmployeeList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwEmployeeList.BackgroundColor = SystemColors.Control;
            dgwEmployeeList.BorderStyle = BorderStyle.None;
            dgwEmployeeList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwEmployeeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwEmployeeList.Dock = DockStyle.Fill;
            dgwEmployeeList.Location = new Point(0, 0);
            dgwEmployeeList.Name = "dgwEmployeeList";
            dgwEmployeeList.ReadOnly = true;
            dgwEmployeeList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwEmployeeList.RowTemplate.Height = 25;
            dgwEmployeeList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwEmployeeList.Size = new Size(768, 430);
            dgwEmployeeList.TabIndex = 18;
            // 
            // EmployeeListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwEmployeeList);
            Name = "EmployeeListControl";
            Size = new Size(768, 430);
            ((System.ComponentModel.ISupportInitialize)dgwEmployeeList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwEmployeeList;
    }
}
