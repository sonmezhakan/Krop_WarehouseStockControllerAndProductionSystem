namespace Krop.WinForms.Brands
{
    partial class frmBrandDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrandDelete));
            panelMid = new System.Windows.Forms.Panel();
            brandComboBoxControl = new UserControllers.Brands.BrandComboBoxControl();
            panelBottom = new System.Windows.Forms.Panel();
            bttnBrandDelete = new Button();
            panelMid.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelMid
            // 
            panelMid.Controls.Add(brandComboBoxControl);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(227, 83);
            panelMid.TabIndex = 5;
            // 
            // brandComboBoxControl
            // 
            brandComboBoxControl.Location = new Point(0, 3);
            brandComboBoxControl.Name = "brandComboBoxControl";
            brandComboBoxControl.Size = new Size(224, 65);
            brandComboBoxControl.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnBrandDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 83);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(227, 41);
            panelBottom.TabIndex = 4;
            // 
            // bttnBrandDelete
            // 
            bttnBrandDelete.Dock = DockStyle.Right;
            bttnBrandDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnBrandDelete.Image = (Image)resources.GetObject("bttnBrandDelete.Image");
            bttnBrandDelete.Location = new Point(112, 0);
            bttnBrandDelete.Name = "bttnBrandDelete";
            bttnBrandDelete.Size = new Size(105, 41);
            bttnBrandDelete.TabIndex = 1;
            bttnBrandDelete.Text = "Sil";
            bttnBrandDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnBrandDelete.UseVisualStyleBackColor = true;
            bttnBrandDelete.Click += bttnBrandDelete_Click;
            // 
            // frmBrandDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(227, 124);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmBrandDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marka Sil";
            Load += frmBrandDelete_Load;
            panelMid.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnBrandDelete;
        private UserControllers.Brands.BrandComboBoxControl brandComboBoxControl;
    }
}