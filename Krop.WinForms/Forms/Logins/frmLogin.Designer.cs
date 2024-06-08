namespace Krop.WinForms.Forms.Logins
{
    partial class frmLogin
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
            bttnLogin = new Button();
            panelTop = new System.Windows.Forms.Panel();
            panelMid = new System.Windows.Forms.Panel();
            label3 = new Label();
            checkRemmemberMe = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            panelBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(bttnLogin);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 158);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(30, 0, 30, 0);
            panelBottom.Size = new Size(266, 43);
            panelBottom.TabIndex = 0;
            // 
            // bttnLogin
            // 
            bttnLogin.Dock = DockStyle.Fill;
            bttnLogin.Location = new Point(30, 0);
            bttnLogin.Name = "bttnLogin";
            bttnLogin.Size = new Size(206, 43);
            bttnLogin.TabIndex = 6;
            bttnLogin.Text = "Giriş Yap";
            bttnLogin.UseVisualStyleBackColor = true;
            bttnLogin.Click += bttnLogin_Click;
            // 
            // panelTop
            // 
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(266, 21);
            panelTop.TabIndex = 1;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(label3);
            panelMid.Controls.Add(checkRemmemberMe);
            panelMid.Controls.Add(label2);
            panelMid.Controls.Add(label1);
            panelMid.Controls.Add(txtPassword);
            panelMid.Controls.Add(txtUserName);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 21);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(266, 137);
            panelMid.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(0, 0, 192);
            label3.Location = new Point(141, 107);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 5;
            label3.Text = "Şifreyi Unuttum";
            // 
            // checkRemmemberMe
            // 
            checkRemmemberMe.AutoSize = true;
            checkRemmemberMe.Location = new Point(31, 106);
            checkRemmemberMe.Name = "checkRemmemberMe";
            checkRemmemberMe.Size = new Size(87, 19);
            checkRemmemberMe.TabIndex = 4;
            checkRemmemberMe.Text = "Beni Hatırla";
            checkRemmemberMe.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 59);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 3;
            label2.Text = "Şifre :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 15);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 2;
            label1.Text = "Kullanıcı Adı :";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(31, 77);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Şifre...";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(31, 33);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Kullanıcı Adı...";
            txtUserName.Size = new Size(200, 23);
            txtUserName.TabIndex = 0;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(266, 201);
            Controls.Add(panelMid);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Krop - Giriş";
            Load += frmLogin_Load;
            panelBottom.ResumeLayout(false);
            panelMid.ResumeLayout(false);
            panelMid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelMid;
        private Label label1;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private Label label3;
        private CheckBox checkRemmemberMe;
        private Label label2;
        private Button bttnLogin;
    }
}