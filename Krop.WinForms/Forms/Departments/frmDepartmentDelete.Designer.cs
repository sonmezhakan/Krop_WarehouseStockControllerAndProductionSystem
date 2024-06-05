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
            panelMid = new System.Windows.Forms.Panel();
            departmentComboBoxControl = new UserControllers.Departments.DepartmentComboBoxControl();
            panelBottom = new System.Windows.Forms.Panel();
            bttnDelete = new Button();
            panelMid.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelMid
            // 
            panelMid.Controls.Add(departmentComboBoxControl);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(235, 61);
            panelMid.TabIndex = 7;
            // 
            // departmentComboBoxControl
            // 
            departmentComboBoxControl.Location = new Point(0, 9);
            departmentComboBoxControl.Name = "departmentComboBoxControl";
            departmentComboBoxControl.Size = new Size(241, 46);
            departmentComboBoxControl.TabIndex = 5;
            departmentComboBoxControl.Load += departmentComboBoxControl_Load;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 61);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(235, 41);
            panelBottom.TabIndex = 6;
            // 
            // bttnDelete
            // 
            bttnDelete.Dock = DockStyle.Right;
            bttnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnDelete.Image = (Image)resources.GetObject("bttnDelete.Image");
            bttnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            bttnDelete.Location = new Point(128, 0);
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
            ClientSize = new Size(235, 102);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmDepartmentDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Departman Sil";
            Load += frmDepartmentDelete_Load;
            panelMid.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnDelete;
        private UserControllers.Departments.DepartmentComboBoxControl departmentComboBoxControl;
    }
}