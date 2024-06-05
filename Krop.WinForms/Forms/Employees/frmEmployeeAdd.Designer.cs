namespace Krop.WinForms.Forms.Employees
{
    partial class frmEmployeeAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeAdd));
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
            panelMid = new System.Windows.Forms.Panel();
            branchComboBoxControl = new UserControllers.Branches.BranchComboBoxControl();
            departmentComboBoxControl = new UserControllers.Departments.DepartmentComboBoxControl();
            appUserComboBoxControl = new UserControllers.AppUsers.AppUserComboBoxControl();
            panelBottom = new System.Windows.Forms.Panel();
            bttnAdd = new Button();
            panelMid.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
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
            label7.Location = new Point(204, 172);
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
            checkDateTimePickerEndEnable.Location = new Point(221, 262);
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
            // panelMid
            // 
            panelMid.Controls.Add(branchComboBoxControl);
            panelMid.Controls.Add(departmentComboBoxControl);
            panelMid.Controls.Add(appUserComboBoxControl);
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
            panelMid.Size = new Size(247, 350);
            panelMid.TabIndex = 3;
            // 
            // branchComboBoxControl
            // 
            branchComboBoxControl.Location = new Point(0, 109);
            branchComboBoxControl.Name = "branchComboBoxControl";
            branchComboBoxControl.Size = new Size(248, 54);
            branchComboBoxControl.TabIndex = 19;
            // 
            // departmentComboBoxControl
            // 
            departmentComboBoxControl.Location = new Point(0, 59);
            departmentComboBoxControl.Name = "departmentComboBoxControl";
            departmentComboBoxControl.Size = new Size(241, 46);
            departmentComboBoxControl.TabIndex = 18;
            // 
            // appUserComboBoxControl
            // 
            appUserComboBoxControl.Location = new Point(0, 3);
            appUserComboBoxControl.Name = "appUserComboBoxControl";
            appUserComboBoxControl.Size = new Size(232, 50);
            appUserComboBoxControl.TabIndex = 17;
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 350);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(247, 41);
            panelBottom.TabIndex = 2;
            // 
            // bttnAdd
            // 
            bttnAdd.Dock = DockStyle.Right;
            bttnAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAdd.Image = (Image)resources.GetObject("bttnAdd.Image");
            bttnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            bttnAdd.Location = new Point(148, 0);
            bttnAdd.Name = "bttnAdd";
            bttnAdd.Size = new Size(87, 39);
            bttnAdd.TabIndex = 0;
            bttnAdd.Text = "Ekle";
            bttnAdd.UseVisualStyleBackColor = true;
            bttnAdd.Click += bttnAdd_Click;
            // 
            // frmEmployeeAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(247, 391);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmEmployeeAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Çalışan Ekle";
            Load += frmEmployeeAdd_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

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
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnAdd;
        private UserControllers.Branches.BranchComboBoxControl branchComboBoxControl;
        private UserControllers.Departments.DepartmentComboBoxControl departmentComboBoxControl;
        private UserControllers.AppUsers.AppUserComboBoxControl appUserComboBoxControl;
    }
}