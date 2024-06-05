namespace Krop.WinForms.UserControllers.StockTransfers
{
    partial class StockTransferListControl
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
            dgwStockTransferList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwStockTransferList).BeginInit();
            SuspendLayout();
            // 
            // dgwStockTransferList
            // 
            dgwStockTransferList.AllowUserToAddRows = false;
            dgwStockTransferList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwStockTransferList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwStockTransferList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwStockTransferList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwStockTransferList.BackgroundColor = SystemColors.Control;
            dgwStockTransferList.BorderStyle = BorderStyle.None;
            dgwStockTransferList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwStockTransferList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwStockTransferList.Dock = DockStyle.Fill;
            dgwStockTransferList.Location = new Point(0, 0);
            dgwStockTransferList.MultiSelect = false;
            dgwStockTransferList.Name = "dgwStockTransferList";
            dgwStockTransferList.ReadOnly = true;
            dgwStockTransferList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwStockTransferList.RowTemplate.Height = 25;
            dgwStockTransferList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwStockTransferList.Size = new Size(807, 467);
            dgwStockTransferList.TabIndex = 16;
            // 
            // StockTransferListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwStockTransferList);
            Name = "StockTransferListControl";
            Size = new Size(807, 467);
            ((System.ComponentModel.ISupportInitialize)dgwStockTransferList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwStockTransferList;
    }
}
