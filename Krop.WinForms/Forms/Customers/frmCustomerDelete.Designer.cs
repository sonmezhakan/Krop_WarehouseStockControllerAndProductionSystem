namespace Krop.WinForms.Customers
{
    partial class frmCustomerDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerDelete));
            bttnCustomerDelete = new Button();
            panelBottom = new System.Windows.Forms.Panel();
            panelMid = new System.Windows.Forms.Panel();
            customerComboBoxControl = new UserControllers.Customers.CustomerComboBoxControl();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // bttnCustomerDelete
            // 
            bttnCustomerDelete.Dock = DockStyle.Right;
            bttnCustomerDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnCustomerDelete.Image = (Image)resources.GetObject("bttnCustomerDelete.Image");
            bttnCustomerDelete.Location = new Point(122, 0);
            bttnCustomerDelete.Name = "bttnCustomerDelete";
            bttnCustomerDelete.Size = new Size(109, 39);
            bttnCustomerDelete.TabIndex = 1;
            bttnCustomerDelete.Text = "Sil";
            bttnCustomerDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnCustomerDelete.UseVisualStyleBackColor = true;
            bttnCustomerDelete.Click += bttnCustomerDelete_Click;
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnCustomerDelete);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 62);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(243, 41);
            panelBottom.TabIndex = 6;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(customerComboBoxControl);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(243, 103);
            panelMid.TabIndex = 7;
            // 
            // customerComboBoxControl
            // 
            customerComboBoxControl.Location = new Point(0, 3);
            customerComboBoxControl.Name = "customerComboBoxControl";
            customerComboBoxControl.Size = new Size(240, 51);
            customerComboBoxControl.TabIndex = 19;
            // 
            // frmCustomerDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(243, 103);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCustomerDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Müşteri Sil";
            Load += frmCustomerDelete_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button bttnCustomerDelete;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMid;
        private UserControllers.Customers.CustomerComboBoxControl customerComboBoxControl;
    }
}