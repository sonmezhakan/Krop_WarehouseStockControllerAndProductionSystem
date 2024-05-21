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
            bttnAppUserRoleAdd = new Button();
            panelMid = new System.Windows.Forms.Panel();
            bttnSelect = new Button();
            cmbBoxAppUserRoleSelect = new ComboBox();
            label2 = new Label();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnAppUserRoleAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 85);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(308, 41);
            panelBottom.TabIndex = 6;
            // 
            // bttnAppUserRoleAdd
            // 
            bttnAppUserRoleAdd.Dock = DockStyle.Right;
            bttnAppUserRoleAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAppUserRoleAdd.Image = (Image)resources.GetObject("bttnAppUserRoleAdd.Image");
            bttnAppUserRoleAdd.Location = new Point(189, 0);
            bttnAppUserRoleAdd.Name = "bttnAppUserRoleAdd";
            bttnAppUserRoleAdd.Size = new Size(107, 39);
            bttnAppUserRoleAdd.TabIndex = 1;
            bttnAppUserRoleAdd.Text = "Sil";
            bttnAppUserRoleAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnAppUserRoleAdd.UseVisualStyleBackColor = true;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(bttnSelect);
            panelMid.Controls.Add(cmbBoxAppUserRoleSelect);
            panelMid.Controls.Add(label2);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(308, 126);
            panelMid.TabIndex = 7;
            // 
            // bttnSelect
            // 
            bttnSelect.Location = new Point(267, 38);
            bttnSelect.Name = "bttnSelect";
            bttnSelect.Size = new Size(31, 23);
            bttnSelect.TabIndex = 24;
            bttnSelect.Text = "...";
            bttnSelect.UseVisualStyleBackColor = true;
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
            ClientSize = new Size(308, 126);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmAppUserRoleDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yetki Sil";
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private Button bttnAppUserRoleAdd;
        private System.Windows.Forms.Panel panelMid;
        private Button bttnSelect;
        private ComboBox cmbBoxAppUserRoleSelect;
        private Label label2;
    }
}