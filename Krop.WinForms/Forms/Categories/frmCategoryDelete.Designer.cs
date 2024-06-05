namespace Krop.WinForms.Categories
{
    partial class frmCategoryDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoryDelete));
            panelMid = new System.Windows.Forms.Panel();
            categoryComboBoxControl = new UserControllers.Categories.CategoryComboBoxControl();
            panelBottom = new System.Windows.Forms.Panel();
            bttnCategoryDelete = new Button();
            panelMid.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelMid
            // 
            panelMid.Controls.Add(categoryComboBoxControl);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(234, 63);
            panelMid.TabIndex = 5;
            // 
            // categoryComboBoxControl
            // 
            categoryComboBoxControl.Location = new Point(0, 3);
            categoryComboBoxControl.Name = "categoryComboBoxControl";
            categoryComboBoxControl.Size = new Size(271, 51);
            categoryComboBoxControl.TabIndex = 1;
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnCategoryDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 63);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 15, 0);
            panelBottom.Size = new Size(234, 41);
            panelBottom.TabIndex = 4;
            // 
            // bttnCategoryDelete
            // 
            bttnCategoryDelete.Dock = DockStyle.Right;
            bttnCategoryDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnCategoryDelete.Image = (Image)resources.GetObject("bttnCategoryDelete.Image");
            bttnCategoryDelete.Location = new Point(110, 0);
            bttnCategoryDelete.Name = "bttnCategoryDelete";
            bttnCategoryDelete.Size = new Size(107, 39);
            bttnCategoryDelete.TabIndex = 1;
            bttnCategoryDelete.Text = "Sil";
            bttnCategoryDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnCategoryDelete.UseVisualStyleBackColor = true;
            bttnCategoryDelete.Click += bttnCategoryDelete_Click;
            // 
            // frmCategoryDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 104);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCategoryDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kategori Sil";
            Load += frmCategoryDelete_Load;
            panelMid.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnCategoryDelete;
        private UserControllers.Categories.CategoryComboBoxControl categoryComboBoxControl;
    }
}