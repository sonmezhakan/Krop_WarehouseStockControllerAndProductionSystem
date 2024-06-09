namespace Krop.WinForms.UserControllers.Stocks
{
    partial class StockListControl
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
            dgwStockList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwStockList).BeginInit();
            SuspendLayout();
            // 
            // dgwStockList
            // 
            dgwStockList.AllowUserToAddRows = false;
            dgwStockList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwStockList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwStockList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwStockList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwStockList.BackgroundColor = SystemColors.Control;
            dgwStockList.BorderStyle = BorderStyle.None;
            dgwStockList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwStockList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwStockList.Dock = DockStyle.Fill;
            dgwStockList.Location = new Point(0, 0);
            dgwStockList.MultiSelect = false;
            dgwStockList.Name = "dgwStockList";
            dgwStockList.ReadOnly = true;
            dgwStockList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwStockList.RowTemplate.Height = 25;
            dgwStockList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwStockList.Size = new Size(989, 578);
            dgwStockList.TabIndex = 9;
            // 
            // StockListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwStockList);
            Name = "StockListControl";
            Size = new Size(989, 578);
            ((System.ComponentModel.ISupportInitialize)dgwStockList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwStockList;
    }
}
