namespace Krop.WinForms.Forms.Departments
{
    partial class frmDepartmentDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepartmentDelete));
            label3 = new Label();
            cmbBoxDepartmentSelect = new ComboBox();
            panelMid = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            bttnDelete = new Button();
            panelMid.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 9);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 5;
            label3.Text = "Departman Adı :";
            // 
            // cmbBoxDepartmentSelect
            // 
            cmbBoxDepartmentSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxDepartmentSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxDepartmentSelect.FormattingEnabled = true;
            cmbBoxDepartmentSelect.Location = new Point(17, 28);
            cmbBoxDepartmentSelect.Name = "cmbBoxDepartmentSelect";
            cmbBoxDepartmentSelect.Size = new Size(211, 23);
            cmbBoxDepartmentSelect.TabIndex = 4;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(label3);
            panelMid.Controls.Add(cmbBoxDepartmentSelect);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(259, 68);
            panelMid.TabIndex = 7;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 68);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(259, 41);
            panelBottom.TabIndex = 6;
            // 
            // bttnDelete
            // 
            bttnDelete.Dock = DockStyle.Right;
            bttnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnDelete.Image = (Image)resources.GetObject("bttnDelete.Image");
            bttnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            bttnDelete.Location = new Point(152, 0);
            bttnDelete.Name = "bttnDelete";
            bttnDelete.Size = new Size(97, 41);
            bttnDelete.TabIndex = 1;
            bttnDelete.Text = "Sil";
            bttnDelete.UseVisualStyleBackColor = true;
            bttnDelete.Click += bttnDelete_Click;
            // 
            // frmDepartmentDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(259, 109);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmDepartmentDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Departman Sil";
            Load += frmDepartmentDelete_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private ComboBox cmbBoxDepartmentSelect;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnDelete;
    }
}