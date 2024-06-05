namespace Krop.WinForms.AppUserRoles
{
    partial class frmAppUserRoleUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppUserRoleUpdate));
            panelBottom = new System.Windows.Forms.Panel();
            bttnAppUserRoleUpdate = new Button();
            panelMid = new System.Windows.Forms.Panel();
            txtAppUserRoleName = new TextBox();
            label1 = new Label();
            appUserRoleComboBoxListControl = new UserControllers.AppUserRoles.AppUserRoleComboBoxControl();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnAppUserRoleUpdate);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 111);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(235, 41);
            panelBottom.TabIndex = 4;
            // 
            // bttnAppUserRoleUpdate
            // 
            bttnAppUserRoleUpdate.Dock = DockStyle.Right;
            bttnAppUserRoleUpdate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAppUserRoleUpdate.Image = (Image)resources.GetObject("bttnAppUserRoleUpdate.Image");
            bttnAppUserRoleUpdate.Location = new Point(116, 0);
            bttnAppUserRoleUpdate.Name = "bttnAppUserRoleUpdate";
            bttnAppUserRoleUpdate.Size = new Size(107, 39);
            bttnAppUserRoleUpdate.TabIndex = 1;
            bttnAppUserRoleUpdate.Text = "Güncelle";
            bttnAppUserRoleUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnAppUserRoleUpdate.UseVisualStyleBackColor = true;
            bttnAppUserRoleUpdate.Click += bttnAppUserRoleUpdate_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(txtAppUserRoleName);
            panelMid.Controls.Add(label1);
            panelMid.Controls.Add(appUserRoleComboBoxListControl);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(235, 152);
            panelMid.TabIndex = 5;
            // 
            // txtAppUserRoleName
            // 
            txtAppUserRoleName.Location = new Point(15, 74);
            txtAppUserRoleName.Name = "txtAppUserRoleName";
            txtAppUserRoleName.Size = new Size(200, 23);
            txtAppUserRoleName.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 56);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 25;
            label1.Text = "Yetki Adı :";
            // 
            // appUserRoleComboBoxListControl
            // 
            appUserRoleComboBoxListControl.Location = new Point(0, 12);
            appUserRoleComboBoxListControl.Name = "appUserRoleComboBoxListControl";
            appUserRoleComboBoxListControl.Size = new Size(232, 44);
            appUserRoleComboBoxListControl.TabIndex = 24;
            // 
            // frmAppUserRoleUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(235, 152);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmAppUserRoleUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yetki Güncelle";
            Load += frmAppUserRoleUpdate_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private Button bttnAppUserRoleUpdate;
        private System.Windows.Forms.Panel panelMid;
        private UserControllers.AppUserRoles.AppUserRoleComboBoxControl appUserRoleComboBoxListControl;
        private TextBox txtAppUserRoleName;
        private Label label1;
    }
}