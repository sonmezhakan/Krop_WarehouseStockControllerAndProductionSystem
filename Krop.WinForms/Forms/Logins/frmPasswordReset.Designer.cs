namespace Krop.WinForms.Forms.Logins
{
    partial class frmPasswordReset
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
            panelBottom = new System.Windows.Forms.Panel();
            bttnPasswordSave = new Button();
            panelMid = new System.Windows.Forms.Panel();
            label3 = new Label();
            txtPassword = new TextBox();
            label2 = new Label();
            txtResetToken = new TextBox();
            panelTop = new System.Windows.Forms.Panel();
            bttnPasswordResetMailSender = new Button();
            label1 = new Label();
            txtEmail = new TextBox();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnPasswordSave);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 233);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(30, 0, 30, 0);
            panelBottom.Size = new Size(269, 43);
            panelBottom.TabIndex = 3;
            // 
            // bttnPasswordSave
            // 
            bttnPasswordSave.Dock = DockStyle.Fill;
            bttnPasswordSave.Location = new Point(30, 0);
            bttnPasswordSave.Name = "bttnPasswordSave";
            bttnPasswordSave.Size = new Size(209, 43);
            bttnPasswordSave.TabIndex = 6;
            bttnPasswordSave.Text = "Şifreyi Kaydet";
            bttnPasswordSave.UseVisualStyleBackColor = true;
            bttnPasswordSave.Click += bttnPasswordSave_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(label3);
            panelMid.Controls.Add(txtPassword);
            panelMid.Controls.Add(label2);
            panelMid.Controls.Add(txtResetToken);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 111);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(269, 165);
            panelMid.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 64);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 3;
            label3.Text = "Yeni Şifre :";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(30, 82);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Yeni Şifre..";
            txtPassword.Size = new Size(209, 23);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 20);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 1;
            label2.Text = "Şifre Sıfırlama Kodu :";
            // 
            // txtResetToken
            // 
            txtResetToken.Location = new Point(30, 38);
            txtResetToken.Name = "txtResetToken";
            txtResetToken.PlaceholderText = "Şifre Sıfırlama Kodu..";
            txtResetToken.Size = new Size(209, 23);
            txtResetToken.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(bttnPasswordResetMailSender);
            panelTop.Controls.Add(label1);
            panelTop.Controls.Add(txtEmail);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(269, 111);
            panelTop.TabIndex = 4;
            // 
            // bttnPasswordResetMailSender
            // 
            bttnPasswordResetMailSender.Location = new Point(30, 56);
            bttnPasswordResetMailSender.Name = "bttnPasswordResetMailSender";
            bttnPasswordResetMailSender.Size = new Size(209, 45);
            bttnPasswordResetMailSender.TabIndex = 8;
            bttnPasswordResetMailSender.Text = "Şifre Sıfırlama Mailini Gönder";
            bttnPasswordResetMailSender.UseVisualStyleBackColor = true;
            bttnPasswordResetMailSender.Click += bttnPasswordResetMailSender_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 9);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 6;
            label1.Text = "Email :";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(30, 27);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email...";
            txtEmail.Size = new Size(209, 23);
            txtEmail.TabIndex = 5;
            // 
            // frmPasswordReset
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(269, 276);
            Controls.Add(panelBottom);
            Controls.Add(panelMid);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmPasswordReset";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Şifre Sıfırlama";
            Load += frmPasswordReset_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private Button bttnPasswordSave;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panelTop;
        private Label label3;
        private TextBox txtPassword;
        private Label label2;
        private TextBox txtResetToken;
        private Label label1;
        private TextBox txtEmail;
        private Button bttnPasswordResetMailSender;
    }
}