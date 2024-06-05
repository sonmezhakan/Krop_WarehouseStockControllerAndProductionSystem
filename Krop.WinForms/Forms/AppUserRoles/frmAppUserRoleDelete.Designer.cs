namespace Krop.WinForms.AppUserRoles
{
    partial class frmAppUserRoleDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppUserRoleDelete));
            panelBottom = new System.Windows.Forms.Panel();
            bttnAppUserRoleDelete = new Button();
            panelMid = new System.Windows.Forms.Panel();
            appUserRoleComboBoxListControl = new UserControllers.AppUserRoles.AppUserRoleComboBoxControl();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnAppUserRoleDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 71);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(234, 41);
            panelBottom.TabIndex = 6;
            // 
            // bttnAppUserRoleDelete
            // 
            bttnAppUserRoleDelete.Dock = DockStyle.Right;
            bttnAppUserRoleDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAppUserRoleDelete.Image = (Image)resources.GetObject("bttnAppUserRoleDelete.Image");
            bttnAppUserRoleDelete.Location = new Point(115, 0);
            bttnAppUserRoleDelete.Name = "bttnAppUserRoleDelete";
            bttnAppUserRoleDelete.Size = new Size(107, 39);
            bttnAppUserRoleDelete.TabIndex = 1;
            bttnAppUserRoleDelete.Text = "Sil";
            bttnAppUserRoleDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnAppUserRoleDelete.UseVisualStyleBackColor = true;
            bttnAppUserRoleDelete.Click += bttnAppUserRoleDelete_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(appUserRoleComboBoxListControl);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(234, 112);
            panelMid.TabIndex = 7;
            // 
            // appUserRoleComboBoxListControl
            // 
            appUserRoleComboBoxListControl.Location = new Point(0, 12);
            appUserRoleComboBoxListControl.Name = "appUserRoleComboBoxListControl";
            appUserRoleComboBoxListControl.Size = new Size(258, 44);
            appUserRoleComboBoxListControl.TabIndex = 24;
            // 
            // frmAppUserRoleDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 112);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmAppUserRoleDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yetki Sil";
            Load += frmAppUserRoleDelete_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private Button bttnAppUserRoleDelete;
        private System.Windows.Forms.Panel panelMid;
        private UserControllers.AppUserRoles.AppUserRoleComboBoxControl appUserRoleComboBoxListControl;
    }
}