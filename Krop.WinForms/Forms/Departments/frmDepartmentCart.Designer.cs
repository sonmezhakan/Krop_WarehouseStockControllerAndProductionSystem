namespace Krop.WinForms.Forms.Departments
{
    partial class frmDepartmentCart
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
            panelMid = new System.Windows.Forms.Panel();
            departmentComboBoxControl = new UserControllers.Departments.DepartmentComboBoxControl();
            txtDescription = new TextBox();
            label2 = new Label();
            panelBottom = new System.Windows.Forms.Panel();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelMid
            // 
            panelMid.Controls.Add(departmentComboBoxControl);
            panelMid.Controls.Add(txtDescription);
            panelMid.Controls.Add(label2);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(237, 205);
            panelMid.TabIndex = 5;
            // 
            // departmentComboBoxControl
            // 
            departmentComboBoxControl.Location = new Point(0, 7);
            departmentComboBoxControl.Name = "departmentComboBoxControl";
            departmentComboBoxControl.Size = new Size(241, 46);
            departmentComboBoxControl.TabIndex = 4;
            // 
            // txtDescription
            // 
            txtDescription.Enabled = false;
            txtDescription.Location = new Point(15, 72);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(200, 111);
            txtDescription.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 54);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 2;
            label2.Text = "Açıklama :";
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 205);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(237, 41);
            panelBottom.TabIndex = 4;
            // 
            // frmDepartmentCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(237, 246);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmDepartmentCart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Departman Kartı";
            Load += frmDepartmentCart_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMid;
        private TextBox txtDescription;
        private Label label2;
        private System.Windows.Forms.Panel panelBottom;
        private UserControllers.Departments.DepartmentComboBoxControl departmentComboBoxControl;
    }
}