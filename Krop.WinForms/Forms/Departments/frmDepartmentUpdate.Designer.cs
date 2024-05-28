namespace Krop.WinForms.Forms.Departments
{
    partial class frmDepartmentUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepartmentUpdate));
            bttnUpdate = new Button();
            panelMid = new System.Windows.Forms.Panel();
            label3 = new Label();
            cmbBoxDepartmentSelect = new ComboBox();
            txtDescription = new TextBox();
            label2 = new Label();
            txtDepartmentName = new TextBox();
            label1 = new Label();
            panelBottom = new System.Windows.Forms.Panel();
            panelMid.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // bttnUpdate
            // 
            bttnUpdate.Dock = DockStyle.Right;
            bttnUpdate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnUpdate.Image = (Image)resources.GetObject("bttnUpdate.Image");
            bttnUpdate.ImageAlign = ContentAlignment.MiddleLeft;
            bttnUpdate.Location = new Point(103, 0);
            bttnUpdate.Name = "bttnUpdate";
            bttnUpdate.Size = new Size(122, 41);
            bttnUpdate.TabIndex = 0;
            bttnUpdate.Text = "Güncelle";
            bttnUpdate.UseVisualStyleBackColor = true;
            bttnUpdate.Click += bttnUpdate_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(label3);
            panelMid.Controls.Add(cmbBoxDepartmentSelect);
            panelMid.Controls.Add(txtDescription);
            panelMid.Controls.Add(label2);
            panelMid.Controls.Add(txtDepartmentName);
            panelMid.Controls.Add(label1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(235, 256);
            panelMid.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 19);
            label3.Name = "label3";
            label3.Size = new Size(173, 15);
            label3.TabIndex = 5;
            label3.Text = "Güncellenecek Departman Adı :";
            // 
            // cmbBoxDepartmentSelect
            // 
            cmbBoxDepartmentSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxDepartmentSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxDepartmentSelect.FormattingEnabled = true;
            cmbBoxDepartmentSelect.Location = new Point(13, 37);
            cmbBoxDepartmentSelect.Name = "cmbBoxDepartmentSelect";
            cmbBoxDepartmentSelect.Size = new Size(211, 23);
            cmbBoxDepartmentSelect.TabIndex = 4;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(13, 126);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(211, 111);
            txtDescription.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 108);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 2;
            label2.Text = "Açıklama :";
            // 
            // txtDepartmentName
            // 
            txtDepartmentName.Location = new Point(13, 81);
            txtDepartmentName.Name = "txtDepartmentName";
            txtDepartmentName.Size = new Size(211, 23);
            txtDepartmentName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 63);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 0;
            label1.Text = "⁬Departman Adı :";
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnUpdate);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 256);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(235, 41);
            panelBottom.TabIndex = 2;
            // 
            // frmDepartmentUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(235, 297);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmDepartmentUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Departman Güncelle";
            Load += frmDepartmentUpdate_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button bttnUpdate;
        private System.Windows.Forms.Panel panelMid;
        private Label label3;
        private ComboBox cmbBoxDepartmentSelect;
        private TextBox txtDescription;
        private Label label2;
        private TextBox txtDepartmentName;
        private Label label1;
        private System.Windows.Forms.Panel panelBottom;
    }
}