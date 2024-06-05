namespace Krop.WinForms.UserControllers
{
    partial class StockInputListControl
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
            dgwStockInputList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwStockInputList).BeginInit();
            SuspendLayout();
            // 
            // dgwStockInputList
            // 
            dgwStockInputList.AllowUserToAddRows = false;
            dgwStockInputList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwStockInputList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwStockInputList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwStockInputList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwStockInputList.BackgroundColor = SystemColors.Control;
            dgwStockInputList.BorderStyle = BorderStyle.None;
            dgwStockInputList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwStockInputList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwStockInputList.Dock = DockStyle.Fill;
            dgwStockInputList.Location = new Point(0, 0);
            dgwStockInputList.MultiSelect = false;
            dgwStockInputList.Name = "dgwStockInputList";
            dgwStockInputList.ReadOnly = true;
            dgwStockInputList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwStockInputList.RowTemplate.Height = 25;
            dgwStockInputList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwStockInputList.Size = new Size(954, 544);
            dgwStockInputList.TabIndex = 15;
            // 
            // StockInputListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwStockInputList);
            Name = "StockInputListControl";
            Size = new Size(954, 544);
            ((System.ComponentModel.ISupportInitialize)dgwStockInputList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwStockInputList;
    }
}
