namespace Krop.WinForms.Products
{
    partial class frmProductDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductDelete));
            panelBottom = new System.Windows.Forms.Panel();
            bttnProductDelete = new Button();
            productComboBoxControl = new UserControllers.Products.ProductComboBoxControl();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnProductDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 117);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 15, 0);
            panelBottom.Size = new Size(244, 41);
            panelBottom.TabIndex = 21;
            // 
            // bttnProductDelete
            // 
            bttnProductDelete.Dock = DockStyle.Right;
            bttnProductDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnProductDelete.Image = (Image)resources.GetObject("bttnProductDelete.Image");
            bttnProductDelete.Location = new Point(135, 0);
            bttnProductDelete.Name = "bttnProductDelete";
            bttnProductDelete.Size = new Size(92, 39);
            bttnProductDelete.TabIndex = 0;
            bttnProductDelete.Text = "Sil";
            bttnProductDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnProductDelete.UseVisualStyleBackColor = true;
            bttnProductDelete.Click += bttnProductDelete_Click;
            // 
            // productComboBoxControl
            // 
            productComboBoxControl.Location = new Point(0, 12);
            productComboBoxControl.Name = "productComboBoxControl";
            productComboBoxControl.Size = new Size(245, 88);
            productComboBoxControl.TabIndex = 35;
            // 
            // frmProductDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(244, 158);
            Controls.Add(productComboBoxControl);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmProductDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ürün Sil";
            Load += frmProductDelete_Load;
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private Button bttnProductDelete;
        private UserControllers.Products.ProductComboBoxControl productComboBoxControl;
    }
}