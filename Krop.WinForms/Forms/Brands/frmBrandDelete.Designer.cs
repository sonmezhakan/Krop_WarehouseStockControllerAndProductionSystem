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
            bttnSelect = new Button();
            cmbBoxBrandSelect = new ComboBox();
            label4 = new Label();
            panelBottom = new System.Windows.Forms.Panel();
            bttnBrandDelete = new Button();
            panelMid.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelMid
            // 
            panelMid.Controls.Add(bttnSelect);
            panelMid.Controls.Add(cmbBoxBrandSelect);
            panelMid.Controls.Add(label4);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(270, 83);
            panelMid.TabIndex = 5;
            // 
            // bttnSelect
            // 
            bttnSelect.Location = new Point(224, 36);
            bttnSelect.Name = "bttnSelect";
            bttnSelect.Size = new Size(31, 23);
            bttnSelect.TabIndex = 21;
            bttnSelect.Text = "...";
            bttnSelect.UseVisualStyleBackColor = true;
            bttnSelect.Visible = false;
            // 
            // cmbBoxBrandSelect
            // 
            cmbBoxBrandSelect.FormattingEnabled = true;
            cmbBoxBrandSelect.Location = new Point(12, 36);
            cmbBoxBrandSelect.Name = "cmbBoxBrandSelect";
            cmbBoxBrandSelect.Size = new Size(206, 23);
            cmbBoxBrandSelect.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 18);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 6;
            label4.Text = "Silinecek Marka :";
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnBrandDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 83);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(270, 41);
            panelBottom.TabIndex = 4;
            // 
            // bttnBrandDelete
            // 
            bttnBrandDelete.Dock = DockStyle.Right;
            bttnBrandDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnBrandDelete.Image = (Image)resources.GetObject("bttnBrandDelete.Image");
            bttnBrandDelete.Location = new Point(155, 0);
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
            ClientSize = new Size(270, 124);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmBrandDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marka Sil";
            Load += frmBrandDelete_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMid;
        private ComboBox cmbBoxBrandSelect;
        private Label label4;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnBrandDelete;
        private Button bttnSelect;
    }
}