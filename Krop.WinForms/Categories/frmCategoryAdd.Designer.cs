namespace Krop.WinForms.Categories
{
    partial class frmCategoryAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoryAdd));
            panelBottom = new System.Windows.Forms.Panel();
            bttnAppUserRoleAdd = new Button();
            panelMid = new System.Windows.Forms.Panel();
            txtAppUserRoleName = new TextBox();
            label1 = new Label();
            bttnCategoryAddRange = new Button();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnCategoryAddRange);
            panelBottom.Controls.Add(bttnAppUserRoleAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 93);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(10, 0, 10, 0);
            panelBottom.Size = new Size(270, 41);
            panelBottom.TabIndex = 0;
            // 
            // bttnAppUserRoleAdd
            // 
            bttnAppUserRoleAdd.Dock = DockStyle.Right;
            bttnAppUserRoleAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAppUserRoleAdd.Image = (Image)resources.GetObject("bttnAppUserRoleAdd.Image");
            bttnAppUserRoleAdd.Location = new Point(166, 0);
            bttnAppUserRoleAdd.Name = "bttnAppUserRoleAdd";
            bttnAppUserRoleAdd.Size = new Size(92, 39);
            bttnAppUserRoleAdd.TabIndex = 1;
            bttnAppUserRoleAdd.Text = "Ekle";
            bttnAppUserRoleAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnAppUserRoleAdd.UseVisualStyleBackColor = true;
            bttnAppUserRoleAdd.Click += bttnCategoryAdd_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(txtAppUserRoleName);
            panelMid.Controls.Add(label1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(270, 93);
            panelMid.TabIndex = 1;
            // 
            // txtAppUserRoleName
            // 
            txtAppUserRoleName.Location = new Point(12, 37);
            txtAppUserRoleName.Name = "txtAppUserRoleName";
            txtAppUserRoleName.PlaceholderText = "Kategori Adı...";
            txtAppUserRoleName.Size = new Size(246, 23);
            txtAppUserRoleName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 0;
            label1.Text = "Kategori Adı:";
            // 
            // bttnCategoryAddRange
            // 
            bttnCategoryAddRange.Dock = DockStyle.Left;
            bttnCategoryAddRange.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnCategoryAddRange.Location = new Point(10, 0);
            bttnCategoryAddRange.Name = "bttnCategoryAddRange";
            bttnCategoryAddRange.Size = new Size(87, 39);
            bttnCategoryAddRange.TabIndex = 2;
            bttnCategoryAddRange.Text = "Çoklu Ekle";
            bttnCategoryAddRange.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnCategoryAddRange.UseVisualStyleBackColor = true;
            bttnCategoryAddRange.Click += bttnCategoryAddRange_Click;
            // 
            // frmCategoryAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(270, 134);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCategoryAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kategori Ekle";
            Load += frmCategoryAdd_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMid;
        private Label label1;
        private TextBox txtAppUserRoleName;
        private Button bttnAppUserRoleAdd;
        private Button bttnCategoryAddRange;
    }
}