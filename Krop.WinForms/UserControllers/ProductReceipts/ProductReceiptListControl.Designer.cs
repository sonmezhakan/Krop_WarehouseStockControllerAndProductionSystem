namespace Krop.WinForms.UserControllers.ProductReceipts
{
    partial class ProductReceiptListControl
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
            dgwProductReceiptList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwProductReceiptList).BeginInit();
            SuspendLayout();
            // 
            // dgwProductReceiptList
            // 
            dgwProductReceiptList.AllowUserToAddRows = false;
            dgwProductReceiptList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwProductReceiptList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwProductReceiptList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwProductReceiptList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwProductReceiptList.BackgroundColor = SystemColors.Control;
            dgwProductReceiptList.BorderStyle = BorderStyle.None;
            dgwProductReceiptList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductReceiptList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwProductReceiptList.Dock = DockStyle.Fill;
            dgwProductReceiptList.Location = new Point(0, 0);
            dgwProductReceiptList.Name = "dgwProductReceiptList";
            dgwProductReceiptList.ReadOnly = true;
            dgwProductReceiptList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductReceiptList.RowTemplate.Height = 25;
            dgwProductReceiptList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwProductReceiptList.Size = new Size(978, 555);
            dgwProductReceiptList.TabIndex = 10;
            // 
            // ProductReceiptListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwProductReceiptList);
            Name = "ProductReceiptListControl";
            Size = new Size(978, 555);
            ((System.ComponentModel.ISupportInitialize)dgwProductReceiptList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwProductReceiptList;
    }
}
