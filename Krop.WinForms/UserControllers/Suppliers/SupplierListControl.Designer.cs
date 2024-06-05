namespace Krop.WinForms.UserControllers.Suppliers
{
    partial class SupplierListControl
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
            dgwSupplierList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwSupplierList).BeginInit();
            SuspendLayout();
            // 
            // dgwSupplierList
            // 
            dgwSupplierList.AllowUserToAddRows = false;
            dgwSupplierList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwSupplierList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwSupplierList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwSupplierList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwSupplierList.BackgroundColor = SystemColors.Control;
            dgwSupplierList.BorderStyle = BorderStyle.None;
            dgwSupplierList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwSupplierList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwSupplierList.Dock = DockStyle.Fill;
            dgwSupplierList.Location = new Point(0, 0);
            dgwSupplierList.Name = "dgwSupplierList";
            dgwSupplierList.ReadOnly = true;
            dgwSupplierList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwSupplierList.RowTemplate.Height = 25;
            dgwSupplierList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwSupplierList.Size = new Size(822, 504);
            dgwSupplierList.TabIndex = 14;
            // 
            // SupplierListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwSupplierList);
            Name = "SupplierListControl";
            Size = new Size(822, 504);
            ((System.ComponentModel.ISupportInitialize)dgwSupplierList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwSupplierList;
    }
}
