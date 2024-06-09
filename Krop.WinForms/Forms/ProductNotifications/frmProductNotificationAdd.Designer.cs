﻿namespace Krop.WinForms.Forms.ProductNotifications
{
    partial class frmProductNotificationAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductNotificationAdd));
            panelBottom = new System.Windows.Forms.Panel();
            bttnAdd = new Button();
            panelMid = new System.Windows.Forms.Panel();
            branchComboBoxControl = new UserControllers.Branches.BranchComboBoxControl();
            productComboBoxControl = new UserControllers.Products.ProductComboBoxControl();
            employeeComboBoxControl = new UserControllers.Employees.EmployeeComboBoxControl();
            txtDescription = new TextBox();
            label2 = new Label();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 360);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(239, 41);
            panelBottom.TabIndex = 2;
            // 
            // bttnAdd
            // 
            bttnAdd.Dock = DockStyle.Right;
            bttnAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAdd.Image = (Image)resources.GetObject("bttnAdd.Image");
            bttnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            bttnAdd.Location = new Point(55, 0);
            bttnAdd.Name = "bttnAdd";
            bttnAdd.Size = new Size(174, 41);
            bttnAdd.TabIndex = 0;
            bttnAdd.Text = "Bildirimde Bulun";
            bttnAdd.UseVisualStyleBackColor = true;
            bttnAdd.Click += bttnAdd_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(branchComboBoxControl);
            panelMid.Controls.Add(productComboBoxControl);
            panelMid.Controls.Add(employeeComboBoxControl);
            panelMid.Controls.Add(txtDescription);
            panelMid.Controls.Add(label2);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Padding = new Padding(10);
            panelMid.Size = new Size(239, 401);
            panelMid.TabIndex = 3;
            // 
            // branchComboBoxControl
            // 
            branchComboBoxControl.Location = new Point(-1, 63);
            branchComboBoxControl.Name = "branchComboBoxControl";
            branchComboBoxControl.Size = new Size(227, 54);
            branchComboBoxControl.TabIndex = 7;
            // 
            // productComboBoxControl
            // 
            productComboBoxControl.Location = new Point(0, 117);
            productComboBoxControl.Name = "productComboBoxControl";
            productComboBoxControl.Size = new Size(231, 88);
            productComboBoxControl.TabIndex = 6;
            // 
            // employeeComboBoxControl
            // 
            employeeComboBoxControl.Location = new Point(0, 13);
            employeeComboBoxControl.Name = "employeeComboBoxControl";
            employeeComboBoxControl.Size = new Size(226, 53);
            employeeComboBoxControl.TabIndex = 5;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(15, 227);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(200, 111);
            txtDescription.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 209);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 2;
            label2.Text = "Açıklama :";
            // 
            // frmProductNotificationAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(239, 401);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmProductNotificationAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ürün Bildirimi Yap";
            Load += frmProductNotificationAdd_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private Button bttnAdd;
        private System.Windows.Forms.Panel panelMid;
        private UserControllers.Products.ProductComboBoxControl productComboBoxControl;
        private UserControllers.Employees.EmployeeComboBoxControl employeeComboBoxControl;
        private TextBox txtDescription;
        private Label label2;
        private UserControllers.Branches.BranchComboBoxControl branchComboBoxControl;
    }
}