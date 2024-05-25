namespace Krop.WinForms.Forms.Branches
{
    partial class frmBranchDelete
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBranchDelete));
            label7 = new Label();
            cmbBoxBranchSelect = new ComboBox();
            panelBottom = new System.Windows.Forms.Panel();
            bttnBranchDelete = new Button();
            panelMid = new System.Windows.Forms.Panel();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 16);
            label7.Name = "label7";
            label7.Size = new Size(109, 15);
            label7.TabIndex = 25;
            label7.Text = "Silinecek Şube Adı :";
            // 
            // cmbBoxBranchSelect
            // 
            cmbBoxBranchSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxBranchSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxBranchSelect.FormattingEnabled = true;
            cmbBoxBranchSelect.Location = new Point(13, 34);
            cmbBoxBranchSelect.Name = "cmbBoxBranchSelect";
            cmbBoxBranchSelect.Size = new Size(227, 23);
            cmbBoxBranchSelect.TabIndex = 24;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnBranchDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 69);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(253, 41);
            panelBottom.TabIndex = 4;
            // 
            // bttnBranchDelete
            // 
            bttnBranchDelete.Dock = DockStyle.Right;
            bttnBranchDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnBranchDelete.Image = (Image)resources.GetObject("bttnBranchDelete.Image");
            bttnBranchDelete.Location = new Point(140, 0);
            bttnBranchDelete.Name = "bttnBranchDelete";
            bttnBranchDelete.Size = new Size(103, 41);
            bttnBranchDelete.TabIndex = 2;
            bttnBranchDelete.Text = "Sil";
            bttnBranchDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnBranchDelete.UseVisualStyleBackColor = true;
            bttnBranchDelete.Click += bttnBranchDelete_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(label7);
            panelMid.Controls.Add(cmbBoxBranchSelect);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(253, 110);
            panelMid.TabIndex = 5;
            // 
            // frmBranchDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(253, 110);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmBranchDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Şube Sil";
            Load += frmBranchDelete_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label7;
        private ComboBox cmbBoxBranchSelect;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnBranchDelete;
        private System.Windows.Forms.Panel panelMid;
    }
}