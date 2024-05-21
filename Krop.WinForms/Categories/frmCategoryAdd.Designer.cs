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
            bttnCategoryAdd = new Button();
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
            panelBottom.Controls.Add(bttnCategoryAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 93);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(270, 41);
            panelBottom.TabIndex = 0;
            // 
            // bttnCategoryAdd
            // 
            bttnCategoryAdd.Dock = DockStyle.Right;
            bttnCategoryAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnCategoryAdd.Image = (Image)resources.GetObject("bttnCategoryAdd.Image");
            bttnCategoryAdd.Location = new Point(166, 0);
            bttnCategoryAdd.Name = "bttnCategoryAdd";
            bttnCategoryAdd.Size = new Size(92, 39);
            bttnCategoryAdd.TabIndex = 1;
            bttnCategoryAdd.Text = "Ekle";
            bttnCategoryAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnCategoryAdd.UseVisualStyleBackColor = true;
            bttnCategoryAdd.Click += bttnCategoryAdd_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(txtCategoryName);
            panelMid.Controls.Add(label1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(270, 93);
            panelMid.TabIndex = 1;
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
            label1.Size = new Size(75, 15);
            label1.TabIndex = 0;
            label1.Text = "Kategori Adı:";
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
        private TextBox txtCategoryName;
        private Button bttnCategoryAdd;
    }
}