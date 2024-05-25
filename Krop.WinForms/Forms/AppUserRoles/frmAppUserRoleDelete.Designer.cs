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
            cmbBoxAppUserRoleSelect = new ComboBox();
            label2 = new Label();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnAppUserRoleDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 85);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(272, 41);
            panelBottom.TabIndex = 6;
            // 
            // bttnAppUserRoleDelete
            // 
            bttnAppUserRoleDelete.Dock = DockStyle.Right;
            bttnAppUserRoleDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAppUserRoleDelete.Image = (Image)resources.GetObject("bttnAppUserRoleDelete.Image");
            bttnAppUserRoleDelete.Location = new Point(153, 0);
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
            panelMid.Controls.Add(cmbBoxAppUserRoleSelect);
            panelMid.Controls.Add(label2);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(272, 126);
            panelMid.TabIndex = 7;
            // 
            // cmbBoxAppUserRoleSelect
            // 
            cmbBoxAppUserRoleSelect.FormattingEnabled = true;
            cmbBoxAppUserRoleSelect.Location = new Point(12, 38);
            cmbBoxAppUserRoleSelect.Name = "cmbBoxAppUserRoleSelect";
            cmbBoxAppUserRoleSelect.Size = new Size(246, 23);
            cmbBoxAppUserRoleSelect.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 20);
            label2.Name = "label2";
            label2.Size = new Size(139, 15);
            label2.TabIndex = 22;
            label2.Text = "Güncellenecek Yetki Adı :";
            // 
            // frmAppUserRoleDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(272, 126);
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
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private Button bttnAppUserRoleDelete;
        private System.Windows.Forms.Panel panelMid;
        private ComboBox cmbBoxAppUserRoleSelect;
        private Label label2;
    }
}