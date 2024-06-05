namespace Krop.WinForms.Forms.Employees
{
    partial class frmEmployeeUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeUpdate));
            panelMid = new System.Windows.Forms.Panel();
            branchComboBoxControl = new UserControllers.Branches.BranchComboBoxControl();
            departmentComboBoxControl = new UserControllers.Departments.DepartmentComboBoxControl();
            employeeComboBoxControl = new UserControllers.Employees.EmployeeComboBoxControl();
            label8 = new Label();
            radioButtonPassive = new RadioButton();
            radioButtonActive = new RadioButton();
            label7 = new Label();
            label6 = new Label();
            txtSalary = new TextBox();
            checkDateTimePickerEndEnable = new CheckBox();
            label5 = new Label();
            label4 = new Label();
            dateTimePickerEnd = new DateTimePicker();
            dateTimePickerStart = new DateTimePicker();
            panelBottom = new System.Windows.Forms.Panel();
            bttnUpdate = new Button();
            panelMid.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelMid
            // 
            panelMid.Controls.Add(branchComboBoxControl);
            panelMid.Controls.Add(departmentComboBoxControl);
            panelMid.Controls.Add(employeeComboBoxControl);
            panelMid.Controls.Add(label8);
            panelMid.Controls.Add(radioButtonPassive);
            panelMid.Controls.Add(radioButtonActive);
            panelMid.Controls.Add(label7);
            panelMid.Controls.Add(label6);
            panelMid.Controls.Add(txtSalary);
            panelMid.Controls.Add(checkDateTimePickerEndEnable);
            panelMid.Controls.Add(label5);
            panelMid.Controls.Add(label4);
            panelMid.Controls.Add(dateTimePickerEnd);
            panelMid.Controls.Add(dateTimePickerStart);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(237, 351);
            panelMid.TabIndex = 5;
            // 
            // branchComboBoxControl
            // 
            branchComboBoxControl.Location = new Point(0, 98);
            branchComboBoxControl.Name = "branchComboBoxControl";
            branchComboBoxControl.Size = new Size(227, 54);
            branchComboBoxControl.TabIndex = 19;
            // 
            // departmentComboBoxControl
            // 
            departmentComboBoxControl.Location = new Point(0, 53);
            departmentComboBoxControl.Name = "departmentComboBoxControl";
            departmentComboBoxControl.Size = new Size(230, 46);
            departmentComboBoxControl.TabIndex = 18;
            // 
            // employeeComboBoxControl
            // 
            employeeComboBoxControl.Location = new Point(0, 0);
            employeeComboBoxControl.Name = "employeeComboBoxControl";
            employeeComboBoxControl.Size = new Size(226, 53);
            employeeComboBoxControl.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 289);
            label8.Name = "label8";
            label8.Size = new Size(102, 15);
            label8.TabIndex = 16;
            label8.Text = "Çalışma Durumu :";
            // 
            // radioButtonPassive
            // 
            radioButtonPassive.AutoSize = true;
            radioButtonPassive.Checked = true;
            radioButtonPassive.Location = new Point(15, 307);
            radioButtonPassive.Name = "radioButtonPassive";
            radioButtonPassive.Size = new Size(50, 19);
            radioButtonPassive.TabIndex = 15;
            radioButtonPassive.TabStop = true;
            radioButtonPassive.Text = "Pasif";
            radioButtonPassive.UseVisualStyleBackColor = true;
            // 
            // radioButtonActive
            // 
            radioButtonActive.AutoSize = true;
            radioButtonActive.Location = new Point(67, 307);
            radioButtonActive.Name = "radioButtonActive";
            radioButtonActive.Size = new Size(50, 19);
            radioButtonActive.TabIndex = 14;
            radioButtonActive.Text = "Aktif";
            radioButtonActive.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(201, 172);
            label7.Name = "label7";
            label7.Size = new Size(13, 15);
            label7.TabIndex = 13;
            label7.Text = "₺";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 151);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 12;
            label6.Text = "Maaş :";
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(15, 169);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(183, 23);
            txtSalary.TabIndex = 11;
            // 
            // checkDateTimePickerEndEnable
            // 
            checkDateTimePickerEndEnable.AutoSize = true;
            checkDateTimePickerEndEnable.Location = new Point(219, 262);
            checkDateTimePickerEndEnable.Name = "checkDateTimePickerEndEnable";
            checkDateTimePickerEndEnable.Size = new Size(15, 14);
            checkDateTimePickerEndEnable.TabIndex = 10;
            checkDateTimePickerEndEnable.UseVisualStyleBackColor = true;
            checkDateTimePickerEndEnable.CheckedChanged += checkDateTimePickerEndEnable_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 239);
            label5.Name = "label5";
            label5.Size = new Size(97, 15);
            label5.TabIndex = 9;
            label5.Text = "İşten Çıkış Tarihi :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 195);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 8;
            label4.Text = "İşe Başlama Tarihi :";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Enabled = false;
            dateTimePickerEnd.Location = new Point(15, 257);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(200, 23);
            dateTimePickerEnd.TabIndex = 7;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(15, 213);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(200, 23);
            dateTimePickerStart.TabIndex = 6;
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnUpdate);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 351);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(237, 41);
            panelBottom.TabIndex = 4;
            // 
            // bttnUpdate
            // 
            bttnUpdate.Dock = DockStyle.Right;
            bttnUpdate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnUpdate.Image = (Image)resources.GetObject("bttnUpdate.Image");
            bttnUpdate.ImageAlign = ContentAlignment.MiddleLeft;
            bttnUpdate.Location = new Point(106, 0);
            bttnUpdate.Name = "bttnUpdate";
            bttnUpdate.Size = new Size(119, 39);
            bttnUpdate.TabIndex = 0;
            bttnUpdate.Text = "Güncelle";
            bttnUpdate.UseVisualStyleBackColor = true;
            bttnUpdate.Click += bttnUpdate_Click;
            // 
            // frmEmployeeUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(237, 392);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmEmployeeUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Çalışan Güncelle";
            Load += frmEmployeeUpdate_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMid;
        private Label label8;
        private RadioButton radioButtonPassive;
        private RadioButton radioButtonActive;
        private Label label7;
        private Label label6;
        private TextBox txtSalary;
        private CheckBox checkDateTimePickerEndEnable;
        private Label label5;
        private Label label4;
        private DateTimePicker dateTimePickerEnd;
        private DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnUpdate;
        private UserControllers.Branches.BranchComboBoxControl branchComboBoxControl;
        private UserControllers.Departments.DepartmentComboBoxControl departmentComboBoxControl;
        private UserControllers.Employees.EmployeeComboBoxControl employeeComboBoxControl;
    }
}