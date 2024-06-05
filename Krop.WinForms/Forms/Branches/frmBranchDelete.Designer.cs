namespace Krop.WinForms.Forms.Branches
{
    partial class frmBranchDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBranchDelete));
            panelBottom = new System.Windows.Forms.Panel();
            bttnBranchDelete = new Button();
            panelMid = new System.Windows.Forms.Panel();
            branchComboBoxControl = new UserControllers.Branches.BranchComboBoxControl();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnBranchDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 69);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(233, 41);
            panelBottom.TabIndex = 4;
            // 
            // bttnBranchDelete
            // 
            bttnBranchDelete.Dock = DockStyle.Right;
            bttnBranchDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnBranchDelete.Image = (Image)resources.GetObject("bttnBranchDelete.Image");
            bttnBranchDelete.Location = new Point(120, 0);
            bttnBranchDelete.Name = "bttnBranchDelete";
            bttnBranchDelete.Size = new Size(103, 41);
            bttnBranchDelete.TabIndex = 2;
            bttnBranchDelete.Text = "Sil";
            bttnBranchDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnBranchDelete.UseVisualStyleBackColor = true;
            bttnBranchDelete.Click += bttnBranchDelete_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(branchComboBoxControl);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(233, 110);
            panelMid.TabIndex = 5;
            // 
            // branchComboBoxControl
            // 
            branchComboBoxControl.Location = new Point(0, 9);
            branchComboBoxControl.Name = "branchComboBoxControl";
            branchComboBoxControl.Size = new Size(248, 54);
            branchComboBoxControl.TabIndex = 0;
            // 
            // frmBranchDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(233, 110);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmBranchDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Şube Sil";
            Load += frmBranchDelete_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnBranchDelete;
        private System.Windows.Forms.Panel panelMid;
        private UserControllers.Branches.BranchComboBoxControl branchComboBoxControl;
    }
}