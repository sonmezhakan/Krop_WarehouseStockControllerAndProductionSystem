namespace Krop.WinForms.UserControllers.Productions
{
    partial class ProductionListControl
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
            dgwProductionList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwProductionList).BeginInit();
            SuspendLayout();
            // 
            // dgwProductionList
            // 
            dgwProductionList.AllowUserToAddRows = false;
            dgwProductionList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dgwProductionList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgwProductionList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwProductionList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwProductionList.BackgroundColor = SystemColors.Control;
            dgwProductionList.BorderStyle = BorderStyle.None;
            dgwProductionList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductionList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwProductionList.Dock = DockStyle.Fill;
            dgwProductionList.Location = new Point(0, 0);
            dgwProductionList.Name = "dgwProductionList";
            dgwProductionList.ReadOnly = true;
            dgwProductionList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgwProductionList.RowTemplate.Height = 25;
            dgwProductionList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwProductionList.Size = new Size(1008, 482);
            dgwProductionList.TabIndex = 11;
            // 
            // ProductionListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgwProductionList);
            Name = "ProductionListControl";
            Size = new Size(1008, 482);
            ((System.ComponentModel.ISupportInitialize)dgwProductionList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwProductionList;
    }
}
