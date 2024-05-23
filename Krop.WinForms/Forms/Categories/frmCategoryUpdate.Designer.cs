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
            bttnSelect = new Button();
            cmbBoxCategorySelect = new ComboBox();
            label2 = new Label();
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
            panelMid.Controls.Add(bttnSelect);
            panelMid.Controls.Add(cmbBoxCategorySelect);
            panelMid.Controls.Add(label2);
            panelMid.Controls.Add(txtCategoryName);
            panelMid.Controls.Add(label1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(309, 135);
            panelMid.TabIndex = 3;
            // 
            // bttnSelect
            // 
            bttnSelect.Location = new Point(267, 37);
            bttnSelect.Name = "bttnSelect";
            bttnSelect.Size = new Size(31, 23);
            bttnSelect.TabIndex = 21;
            bttnSelect.Text = "...";
            bttnSelect.UseVisualStyleBackColor = true;
            bttnSelect.Visible = false;
            // 
            // cmbBoxCategorySelect
            // 
            cmbBoxCategorySelect.FormattingEnabled = true;
            cmbBoxCategorySelect.Location = new Point(12, 37);
            cmbBoxCategorySelect.Name = "cmbBoxCategorySelect";
            cmbBoxCategorySelect.Size = new Size(246, 23);
            cmbBoxCategorySelect.TabIndex = 3;
            cmbBoxCategorySelect.SelectedIndexChanged += cmbBoxCategorySelect_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 19);
            label2.Name = "label2";
            label2.Size = new Size(137, 15);
            label2.TabIndex = 2;
            label2.Text = "Güncellenecek Kategori :";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(12, 81);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(246, 23);
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
            panelBottom.Location = new Point(0, 135);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 15, 0);
            panelBottom.Size = new Size(309, 41);
            panelBottom.TabIndex = 2;
            // 
            // bttnCategoryUpdate
            // 
            bttnCategoryUpdate.Dock = DockStyle.Right;
            bttnCategoryUpdate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnCategoryUpdate.Image = (Image)resources.GetObject("bttnCategoryUpdate.Image");
            bttnCategoryUpdate.Location = new Point(185, 0);
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
            ClientSize = new Size(309, 176);
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
        private Label label2;
        private TextBox txtCategoryName;
        private Label label1;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnCategoryUpdate;
        private Button bttnSelect;
        private ComboBox cmbBoxCategorySelect;
    }
}