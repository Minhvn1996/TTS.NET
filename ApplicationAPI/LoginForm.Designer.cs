namespace ApplicationAPI
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtEmail = new TextBox();
            txtPass = new TextBox();
            btnLogin = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            linkRegister = new LinkLabel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(164, 51);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(564, 39);
            txtEmail.TabIndex = 0;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(164, 108);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(564, 39);
            txtPass.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(47, 328);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 46);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(106, 33);
            label1.Name = "label1";
            label1.Size = new Size(630, 59);
            label1.TabIndex = 3;
            label1.Text = "LOGIN WITH YOUR ACCOUNT";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtPass);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Location = new Point(45, 130);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(753, 185);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Account Infomation";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 108);
            label3.Name = "label3";
            label3.Size = new Size(111, 32);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 59);
            label2.Name = "label2";
            label2.Size = new Size(71, 32);
            label2.TabIndex = 2;
            label2.Text = "Email";
            // 
            // linkRegister
            // 
            linkRegister.AutoSize = true;
            linkRegister.Location = new Point(503, 342);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(295, 32);
            linkRegister.TabIndex = 5;
            linkRegister.TabStop = true;
            linkRegister.Text = "Do you have not account?";
            linkRegister.LinkClicked += linkRegister_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 399);
            Controls.Add(linkRegister);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private TextBox txtPass;
        private Button btnLogin;
        private Label label1;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private LinkLabel linkRegister;
    }
}