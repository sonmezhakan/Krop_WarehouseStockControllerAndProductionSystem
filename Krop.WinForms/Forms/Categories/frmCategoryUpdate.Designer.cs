namespace Krop.WinForms.Categories
{
    partial class frmCategoryUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoryUpdate));
            panelMid = new System.Windows.Forms.Panel();
            categoryComboBoxControl = new UserControllers.Categories.CategoryComboBoxControl();
            txtCategoryName = new TextBox();
            label1 = new Label();
            panelBottom = new System.Windows.Forms.Panel();
            bttnCategoryUpdate = new Button();
            panelMid.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelMid
            // 
            panelMid.Controls.Add(categoryComboBoxControl);
            panelMid.Controls.Add(txtCategoryName);
            panelMid.Controls.Add(label1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(230, 130);
            panelMid.TabIndex = 3;
            // 
            // categoryComboBoxControl
            // 
            categoryComboBoxControl.Location = new Point(0, 12);
            categoryComboBoxControl.Name = "categoryComboBoxControl";
            categoryComboBoxControl.Size = new Size(271, 51);
            categoryComboBoxControl.TabIndex = 2;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(15, 81);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(200, 23);
            txtCategoryName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 63);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 0;
            label1.Text = "Kategori Adı:";
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnCategoryUpdate);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 130);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 15, 0);
            panelBottom.Size = new Size(230, 41);
            panelBottom.TabIndex = 2;
            // 
            // bttnCategoryUpdate
            // 
            bttnCategoryUpdate.Dock = DockStyle.Right;
            bttnCategoryUpdate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnCategoryUpdate.Image = (Image)resources.GetObject("bttnCategoryUpdate.Image");
            bttnCategoryUpdate.Location = new Point(106, 0);
            bttnCategoryUpdate.Name = "bttnCategoryUpdate";
            bttnCategoryUpdate.Size = new Size(107, 39);
            bttnCategoryUpdate.TabIndex = 1;
            bttnCategoryUpdate.Text = "Güncelle";
            bttnCategoryUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnCategoryUpdate.UseVisualStyleBackColor = true;
            bttnCategoryUpdate.Click += bttnCategoryUpdate_Click;
            // 
            // frmCategoryUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(230, 171);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCategoryUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kategori Güncelle";
            Load += frmCategoryUpdate_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMid;
        private TextBox txtCategoryName;
        private Label label1;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnCategoryUpdate;
        private UserControllers.Categories.CategoryComboBoxControl categoryComboBoxControl;
    }
}