namespace Krop.WinForms.UserControllers.Products
{
    partial class ProductListControl
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
            dgwProductList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwProductList).BeginInit();
            SuspendLayout();
            // 
            // dgwProductList
            // 
            dgwProductList.AllowUserToAddRows = false;
            dgwProductList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwProductList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwProductList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwProductList.BackgroundColor = SystemColors.Control;
            dgwProductList.BorderStyle = BorderStyle.None;
            dgwProductList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwProductList.Dock = DockStyle.Fill;
            dgwProductList.Location = new Point(0, 0);
            dgwProductList.MultiSelect = false;
            dgwProductList.Name = "dgwProductList";
            dgwProductList.ReadOnly = true;
            dgwProductList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductList.RowTemplate.Height = 25;
            dgwProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwProductList.Size = new Size(1055, 542);
            dgwProductList.TabIndex = 8;
            // 
            // ProductListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwProductList);
            Name = "ProductListControl";
            Size = new Size(1055, 542);
            ((System.ComponentModel.ISupportInitialize)dgwProductList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwProductList;
    }
}
