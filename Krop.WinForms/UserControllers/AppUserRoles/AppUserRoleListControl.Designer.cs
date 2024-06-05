namespace Krop.WinForms.UserControllers.AppUserRoles
{
    partial class AppUserRoleListControl
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
            dgwAppUserRoleList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwAppUserRoleList).BeginInit();
            SuspendLayout();
            // 
            // dgwAppUserRoleList
            // 
            dgwAppUserRoleList.AllowUserToAddRows = false;
            dgwAppUserRoleList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwAppUserRoleList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwAppUserRoleList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwAppUserRoleList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwAppUserRoleList.BackgroundColor = SystemColors.Control;
            dgwAppUserRoleList.BorderStyle = BorderStyle.None;
            dgwAppUserRoleList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwAppUserRoleList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwAppUserRoleList.Dock = DockStyle.Fill;
            dgwAppUserRoleList.Location = new Point(0, 0);
            dgwAppUserRoleList.Name = "dgwAppUserRoleList";
            dgwAppUserRoleList.ReadOnly = true;
            dgwAppUserRoleList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwAppUserRoleList.RowTemplate.Height = 25;
            dgwAppUserRoleList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwAppUserRoleList.Size = new Size(862, 427);
            dgwAppUserRoleList.TabIndex = 15;
            // 
            // AppUserRoleListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwAppUserRoleList);
            Name = "AppUserRoleListControl";
            Size = new Size(862, 427);
            ((System.ComponentModel.ISupportInitialize)dgwAppUserRoleList).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgwAppUserRoleList;
    }
}
