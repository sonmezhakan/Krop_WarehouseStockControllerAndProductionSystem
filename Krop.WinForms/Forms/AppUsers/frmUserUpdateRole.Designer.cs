namespace Krop.WinForms.Forms.AppUsers
{
    partial class frmUserUpdateRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserUpdateRole));
            panelMid = new System.Windows.Forms.Panel();
            appUserRoleCheckedListBoxControl = new UserControllers.AppUserRoles.AppUserRoleCheckedListBoxControl();
            appUserComboBoxControl = new UserControllers.AppUsers.AppUserComboBoxControl();
            panelBottom = new System.Windows.Forms.Panel();
            bttnUserUpdateRole = new Button();
            panelMid.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelMid
            // 
            panelMid.Controls.Add(appUserRoleCheckedListBoxControl);
            panelMid.Controls.Add(appUserComboBoxControl);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(247, 279);
            panelMid.TabIndex = 3;
            // 
            // appUserRoleCheckedListBoxControl
            // 
            appUserRoleCheckedListBoxControl.Location = new Point(8, 68);
            appUserRoleCheckedListBoxControl.Name = "appUserRoleCheckedListBoxControl";
            appUserRoleCheckedListBoxControl.Size = new Size(231, 207);
            appUserRoleCheckedListBoxControl.TabIndex = 1;
            // 
            // appUserComboBoxControl
            // 
            appUserComboBoxControl.Location = new Point(10, 12);
            appUserComboBoxControl.Name = "appUserComboBoxControl";
            appUserComboBoxControl.Size = new Size(230, 50);
            appUserComboBoxControl.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnUserUpdateRole);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 279);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(247, 41);
            panelBottom.TabIndex = 2;
            // 
            // bttnUserUpdateRole
            // 
            bttnUserUpdateRole.Dock = DockStyle.Right;
            bttnUserUpdateRole.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnUserUpdateRole.Image = (Image)resources.GetObject("bttnUserUpdateRole.Image");
            bttnUserUpdateRole.ImageAlign = ContentAlignment.MiddleLeft;
            bttnUserUpdateRole.Location = new Point(114, 0);
            bttnUserUpdateRole.Name = "bttnUserUpdateRole";
            bttnUserUpdateRole.Size = new Size(123, 41);
            bttnUserUpdateRole.TabIndex = 0;
            bttnUserUpdateRole.Text = "Güncelle";
            bttnUserUpdateRole.UseVisualStyleBackColor = true;
            bttnUserUpdateRole.Click += bttnUserUpdateRole_Click;
            // 
            // frmUserUpdateRole
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(247, 320);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            Name = "frmUserUpdateRole";
            Text = "Kullanıcı Yetki İşlemleri";
            Load += frmUserAddRole_Load;
            panelMid.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMid;
        private UserControllers.AppUsers.AppUserComboBoxControl appUserComboBoxControl;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnUserUpdateRole;
        private UserControllers.AppUserRoles.AppUserRoleCheckedListBoxControl appUserRoleCheckedListBoxControl;
    }
}