namespace Krop.WinForms.Forms.Employees
{
    partial class frmEmployeeCart
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
            panelBottom = new System.Windows.Forms.Panel();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            cmbBoxAppUserSelect = new ComboBox();
            label1 = new Label();
            panelMid = new System.Windows.Forms.Panel();
            txtDepartmentName = new TextBox();
            txtBranchName = new TextBox();
            label7 = new Label();
            radioButtonPassive = new RadioButton();
            radioButtonActive = new RadioButton();
            txtSalary = new TextBox();
            dateTimePickerEnd = new DateTimePicker();
            dateTimePickerStart = new DateTimePicker();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 345);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(244, 41);
            panelBottom.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 289);
            label8.Name = "label8";
            label8.Size = new Size(102, 15);
            label8.TabIndex = 16;
            label8.Text = "Çalışma Durumu :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 151);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 12;
            label6.Text = "Maaş :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 239);
            label5.Name = "label5";
            label5.Size = new Size(97, 15);
            label5.TabIndex = 9;
            label5.Text = "İşten Çıkış Tarihi :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 195);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 8;
            label4.Text = "İşe Başlama Tarihi :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 104);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Şube :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 55);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 2;
            label2.Text = "Departman :";
            // 
            // cmbBoxAppUserSelect
            // 
            cmbBoxAppUserSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxAppUserSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBoxAppUserSelect.FormattingEnabled = true;
            cmbBoxAppUserSelect.Location = new Point(12, 27);
            cmbBoxAppUserSelect.Name = "cmbBoxAppUserSelect";
            cmbBoxAppUserSelect.Size = new Size(202, 23);
            cmbBoxAppUserSelect.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 0;
            label1.Text = "Çalışanın Kullanıcı Adı :";
            // 
            // panelMid
            // 
            panelMid.Controls.Add(txtDepartmentName);
            panelMid.Controls.Add(txtBranchName);
            panelMid.Controls.Add(label7);
            panelMid.Controls.Add(radioButtonPassive);
            panelMid.Controls.Add(radioButtonActive);
            panelMid.Controls.Add(txtSalary);
            panelMid.Controls.Add(dateTimePickerEnd);
            panelMid.Controls.Add(dateTimePickerStart);
            panelMid.Controls.Add(label8);
            panelMid.Controls.Add(label6);
            panelMid.Controls.Add(label5);
            panelMid.Controls.Add(label4);
            panelMid.Controls.Add(label3);
            panelMid.Controls.Add(label2);
            panelMid.Controls.Add(cmbBoxAppUserSelect);
            panelMid.Controls.Add(label1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(244, 386);
            panelMid.TabIndex = 7;
            // 
            // txtDepartmentName
            // 
            txtDepartmentName.Enabled = false;
            txtDepartmentName.Location = new Point(12, 73);
            txtDepartmentName.Name = "txtDepartmentName";
            txtDepartmentName.ReadOnly = true;
            txtDepartmentName.Size = new Size(202, 23);
            txtDepartmentName.TabIndex = 24;
            // 
            // txtBranchName
            // 
            txtBranchName.Enabled = false;
            txtBranchName.Location = new Point(12, 125);
            txtBranchName.Name = "txtBranchName";
            txtBranchName.ReadOnly = true;
            txtBranchName.Size = new Size(202, 23);
            txtBranchName.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(199, 172);
            label7.Name = "label7";
            label7.Size = new Size(13, 15);
            label7.TabIndex = 22;
            label7.Text = "₺";
            // 
            // radioButtonPassive
            // 
            radioButtonPassive.AutoSize = true;
            radioButtonPassive.Checked = true;
            radioButtonPassive.Enabled = false;
            radioButtonPassive.Location = new Point(12, 307);
            radioButtonPassive.Name = "radioButtonPassive";
            radioButtonPassive.Size = new Size(50, 19);
            radioButtonPassive.TabIndex = 21;
            radioButtonPassive.TabStop = true;
            radioButtonPassive.Text = "Pasif";
            radioButtonPassive.UseVisualStyleBackColor = true;
            // 
            // radioButtonActive
            // 
            radioButtonActive.AutoSize = true;
            radioButtonActive.Enabled = false;
            radioButtonActive.Location = new Point(64, 307);
            radioButtonActive.Name = "radioButtonActive";
            radioButtonActive.Size = new Size(50, 19);
            radioButtonActive.TabIndex = 20;
            radioButtonActive.Text = "Aktif";
            radioButtonActive.UseVisualStyleBackColor = true;
            // 
            // txtSalary
            // 
            txtSalary.Enabled = false;
            txtSalary.Location = new Point(12, 169);
            txtSalary.Name = "txtSalary";
            txtSalary.ReadOnly = true;
            txtSalary.Size = new Size(183, 23);
            txtSalary.TabIndex = 19;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Enabled = false;
            dateTimePickerEnd.Location = new Point(12, 257);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(200, 23);
            dateTimePickerEnd.TabIndex = 18;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Enabled = false;
            dateTimePickerStart.Location = new Point(12, 213);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(200, 23);
            dateTimePickerStart.TabIndex = 17;
            // 
            // frmEmployeeCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(244, 386);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmEmployeeCart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Çalışan Kartı";
            Load += frmEmployeeCart_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private Label label8;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox cmbBoxAppUserSelect;
        private Label label1;
        private System.Windows.Forms.Panel panelMid;
        private RadioButton radioButtonPassive;
        private RadioButton radioButtonActive;
        private TextBox txtSalary;
        private DateTimePicker dateTimePickerEnd;
        private DateTimePicker dateTimePickerStart;
        private TextBox txtDepartmentName;
        private TextBox txtBranchName;
        private Label label7;
    }
}