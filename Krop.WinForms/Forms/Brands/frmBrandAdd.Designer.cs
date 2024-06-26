﻿namespace Krop.WinForms.Brands
{
    partial class frmBrandAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrandAdd));
            panelBottom = new System.Windows.Forms.Panel();
            bttnBrandAdd = new Button();
            panelMid = new System.Windows.Forms.Panel();
            txtEmail = new TextBox();
            txtPhoneNumber = new TextBox();
            txtBrandName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnBrandAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 181);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(240, 41);
            panelBottom.TabIndex = 0;
            // 
            // bttnBrandAdd
            // 
            bttnBrandAdd.Dock = DockStyle.Right;
            bttnBrandAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnBrandAdd.Image = (Image)resources.GetObject("bttnBrandAdd.Image");
            bttnBrandAdd.Location = new Point(136, 0);
            bttnBrandAdd.Name = "bttnBrandAdd";
            bttnBrandAdd.Size = new Size(92, 39);
            bttnBrandAdd.TabIndex = 1;
            bttnBrandAdd.Text = "Ekle";
            bttnBrandAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnBrandAdd.UseVisualStyleBackColor = true;
            bttnBrandAdd.Click += bttnBrandAdd_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(txtEmail);
            panelMid.Controls.Add(txtPhoneNumber);
            panelMid.Controls.Add(txtBrandName);
            panelMid.Controls.Add(label3);
            panelMid.Controls.Add(label2);
            panelMid.Controls.Add(label1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(240, 181);
            panelMid.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(15, 124);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email...";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 5;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(15, 80);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "Telefon Numarası...";
            txtPhoneNumber.Size = new Size(200, 23);
            txtPhoneNumber.TabIndex = 4;
            // 
            // txtBrandName
            // 
            txtBrandName.Location = new Point(15, 36);
            txtBrandName.Name = "txtBrandName";
            txtBrandName.PlaceholderText = "Marka Adı...";
            txtBrandName.Size = new Size(200, 23);
            txtBrandName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 106);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Email :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 62);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 1;
            label2.Text = "Telefon Numarası :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 18);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 0;
            label1.Text = "Marka Adı :";
            // 
            // frmBrandAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(240, 222);
            Controls.Add(panelMid);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmBrandAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marka Ekle";
            Load += frmBrandAdd_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMid;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtEmail;
        private TextBox txtPhoneNumber;
        private TextBox txtBrandName;
        private Button bttnBrandAdd;
    }
}