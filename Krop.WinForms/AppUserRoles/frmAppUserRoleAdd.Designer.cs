﻿namespace Krop.WinForms.AppUserRoles
{
    partial class frmAppUserRoleAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppUserRoleAdd));
            panelBottom = new System.Windows.Forms.Panel();
            bttnAppUserRoleAdd = new Button();
            panelMid = new System.Windows.Forms.Panel();
            txtCategoryName = new TextBox();
            label1 = new Label();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnAppUserRoleAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 76);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(278, 41);
            panelBottom.TabIndex = 2;
            // 
            // bttnAppUserRoleAdd
            // 
            bttnAppUserRoleAdd.Dock = DockStyle.Right;
            bttnAppUserRoleAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAppUserRoleAdd.Image = (Image)resources.GetObject("bttnAppUserRoleAdd.Image");
            bttnAppUserRoleAdd.Location = new Point(174, 0);
            bttnAppUserRoleAdd.Name = "bttnAppUserRoleAdd";
            bttnAppUserRoleAdd.Size = new Size(92, 39);
            bttnAppUserRoleAdd.TabIndex = 1;
            bttnAppUserRoleAdd.Text = "Ekle";
            bttnAppUserRoleAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnAppUserRoleAdd.UseVisualStyleBackColor = true;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(txtCategoryName);
            panelMid.Controls.Add(label1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(278, 117);
            panelMid.TabIndex = 3;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(12, 37);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(246, 23);
            txtCategoryName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Yetki Adı :";
            // 
            // frmAppUserRoleAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(278, 117);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmAppUserRoleAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yetki Ekle";
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private Button bttnAppUserRoleAdd;
        private System.Windows.Forms.Panel panelMid;
        private TextBox txtCategoryName;
        private Label label1;
    }
}