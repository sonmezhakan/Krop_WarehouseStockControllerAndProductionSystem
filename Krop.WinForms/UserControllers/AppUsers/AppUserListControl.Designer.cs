namespace Krop.WinForms.UserControllers.AppUsers
{
    partial class AppUserListControl
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
            dgwAppUserList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwAppUserList).BeginInit();
            SuspendLayout();
            // 
            // dgwAppUserList
            // 
            dgwAppUserList.AllowUserToAddRows = false;
            dgwAppUserList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwAppUserList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwAppUserList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwAppUserList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwAppUserList.BackgroundColor = SystemColors.Control;
            dgwAppUserList.BorderStyle = BorderStyle.None;
            dgwAppUserList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwAppUserList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwAppUserList.Dock = DockStyle.Fill;
            dgwAppUserList.Location = new Point(0, 0);
            dgwAppUserList.Name = "dgwAppUserList";
            dgwAppUserList.ReadOnly = true;
            dgwAppUserList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwAppUserList.RowTemplate.Height = 25;
            dgwAppUserList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwAppUserList.Size = new Size(771, 461);
            dgwAppUserList.TabIndex = 14;
            // 
            // AppUserListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwAppUserList);
            Name = "AppUserListControl";
            Size = new Size(771, 461);
            Load += AppUserListControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgwAppUserList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwAppUserList;
    }
}
