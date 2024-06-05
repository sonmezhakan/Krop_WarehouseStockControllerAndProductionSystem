namespace Krop.WinForms.UserControllers.Branches
{
    partial class BranchListControl
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
            dgwBranchList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwBranchList).BeginInit();
            SuspendLayout();
            // 
            // dgwBranchList
            // 
            dgwBranchList.AllowUserToAddRows = false;
            dgwBranchList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwBranchList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwBranchList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwBranchList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwBranchList.BackgroundColor = SystemColors.Control;
            dgwBranchList.BorderStyle = BorderStyle.None;
            dgwBranchList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwBranchList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwBranchList.Dock = DockStyle.Fill;
            dgwBranchList.Location = new Point(0, 0);
            dgwBranchList.Name = "dgwBranchList";
            dgwBranchList.ReadOnly = true;
            dgwBranchList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwBranchList.RowTemplate.Height = 25;
            dgwBranchList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwBranchList.Size = new Size(805, 520);
            dgwBranchList.TabIndex = 17;
            // 
            // BranchListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwBranchList);
            Name = "BranchListControl";
            Size = new Size(805, 520);
            ((System.ComponentModel.ISupportInitialize)dgwBranchList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwBranchList;
    }
}
