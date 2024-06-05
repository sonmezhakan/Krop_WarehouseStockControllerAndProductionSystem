namespace Krop.WinForms.UserControllers.Customers
{
    partial class CustomerListControl
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
            dgwCustomerList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwCustomerList).BeginInit();
            SuspendLayout();
            // 
            // dgwCustomerList
            // 
            dgwCustomerList.AllowUserToAddRows = false;
            dgwCustomerList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwCustomerList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwCustomerList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwCustomerList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwCustomerList.BackgroundColor = SystemColors.Control;
            dgwCustomerList.BorderStyle = BorderStyle.None;
            dgwCustomerList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwCustomerList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwCustomerList.Dock = DockStyle.Fill;
            dgwCustomerList.Location = new Point(0, 0);
            dgwCustomerList.Name = "dgwCustomerList";
            dgwCustomerList.ReadOnly = true;
            dgwCustomerList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwCustomerList.RowTemplate.Height = 25;
            dgwCustomerList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwCustomerList.Size = new Size(891, 483);
            dgwCustomerList.TabIndex = 14;
            // 
            // CustomerListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwCustomerList);
            Name = "CustomerListControl";
            Size = new Size(891, 483);
            ((System.ComponentModel.ISupportInitialize)dgwCustomerList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwCustomerList;
    }
}
