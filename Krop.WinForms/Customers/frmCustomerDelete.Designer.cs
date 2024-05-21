﻿namespace Krop.WinForms.Customers
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
            bttnCustomerAdd = new Button();
            panelBottom = new System.Windows.Forms.Panel();
            panelMid = new System.Windows.Forms.Panel();
            cmbBoxCustomerSelect = new ComboBox();
            label9 = new Label();
            bttnSelect = new Button();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // bttnCustomerAdd
            // 
            bttnCustomerAdd.Dock = DockStyle.Right;
            bttnCustomerAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            bttnCustomerAdd.Image = (Image)resources.GetObject("bttnCustomerAdd.Image");
            bttnCustomerAdd.Location = new Point(192, 0);
            bttnCustomerAdd.Name = "bttnCustomerAdd";
            bttnCustomerAdd.Size = new Size(109, 39);
            bttnCustomerAdd.TabIndex = 1;
            bttnCustomerAdd.Text = "Sil";
            bttnCustomerAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            bttnCustomerAdd.UseVisualStyleBackColor = true;
            // 
            // panelBottom
            // 
            panelBottom.BorderStyle = BorderStyle.FixedSingle;
            panelBottom.Controls.Add(bttnCustomerAdd);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 91);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(0, 0, 10, 0);
            panelBottom.Size = new Size(313, 41);
            panelBottom.TabIndex = 6;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(bttnSelect);
            panelMid.Controls.Add(cmbBoxCustomerSelect);
            panelMid.Controls.Add(label9);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 0);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(313, 132);
            panelMid.TabIndex = 7;
            // 
            // cmbBoxCustomerSelect
            // 
            cmbBoxCustomerSelect.FormattingEnabled = true;
            cmbBoxCustomerSelect.Location = new Point(21, 38);
            cmbBoxCustomerSelect.Name = "cmbBoxCustomerSelect";
            cmbBoxCustomerSelect.Size = new Size(245, 23);
            cmbBoxCustomerSelect.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 20);
            label9.Name = "label9";
            label9.Size = new Size(214, 15);
            label9.TabIndex = 18;
            label9.Text = "Silinecek Müşterinin Telefon Numarası :";
            // 
            // bttnSelect
            // 
            bttnSelect.Location = new Point(272, 38);
            bttnSelect.Name = "bttnSelect";
            bttnSelect.Size = new Size(31, 23);
            bttnSelect.TabIndex = 21;
            bttnSelect.Text = "...";
            bttnSelect.UseVisualStyleBackColor = true;
            // 
            // frmCustomerDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(313, 132);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCustomerDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Müşteri Sil";
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button bttnCustomerAdd;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMid;
        private ComboBox cmbBoxCustomerSelect;
        private Label label9;
        private Button bttnSelect;
    }
}