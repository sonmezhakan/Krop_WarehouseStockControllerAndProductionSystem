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
            bttnSelect = new Button();
            cmbBoxCategorySelect = new ComboBox();
            label2 = new Label();
            panelBottom = new System.Windows.Forms.Panel();
            bttnCategoryDelete = new Button();
            panelMid.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelMid
            // 
            panelMid.Controls.Add(bttnSelect);
            panelMid.Controls.Add(cmbBoxCategorySelect);
            panelMid.Controls.Add(label2);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(306, 90);
            panelMid.TabIndex = 5;
            // 
            // bttnSelect
            // 
            bttnSelect.Location = new Point(264, 37);
            bttnSelect.Name = "bttnSelect";
            bttnSelect.Size = new Size(31, 23);
            bttnSelect.TabIndex = 21;
            bttnSelect.Text = "...";
            bttnSelect.UseVisualStyleBackColor = true;
            bttnSelect.Visible = false;
            // 
            // cmbBoxCategorySelect
            // 
            cmbBoxCategorySelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxCategorySelect.AutoCompleteSource = AutoCompleteSource.ListItems;
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
            label2.Size = new Size(106, 15);
            label2.TabIndex = 2;
            label2.Text = "Silinecek Kategori :";
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnCategoryDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 90);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 15, 0);
            panelBottom.Size = new Size(306, 41);
            panelBottom.TabIndex = 4;
            // 
            // bttnCategoryDelete
            // 
            bttnCategoryDelete.Dock = DockStyle.Right;
            bttnCategoryDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnCategoryDelete.Image = (Image)resources.GetObject("bttnCategoryDelete.Image");
            bttnCategoryDelete.Location = new Point(182, 0);
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
            ClientSize = new Size(306, 131);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCategoryDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kategori Sil";
            Load += frmCategoryDelete_Load;
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMid;
        private ComboBox cmbBoxCategorySelect;
        private Label label2;
        private System.Windows.Forms.Panel panelBottom;
        private Button bttnCategoryDelete;
        private Button bttnSelect;
    }
}