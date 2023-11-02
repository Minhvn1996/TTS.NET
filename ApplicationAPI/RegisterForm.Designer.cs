namespace ApplicationAPI
{
    partial class RegisterForm
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
            groupBox1 = new GroupBox();
            txtLastname = new TextBox();
            txtFirstname = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label4 = new Label();
            txtPassCF = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtPass = new TextBox();
            txtEmail = new TextBox();
            label1 = new Label();
            btnRegister = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtLastname);
            groupBox1.Controls.Add(txtFirstname);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtPassCF);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtPass);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Location = new Point(43, 149);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1067, 324);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Account Infomation";
            // 
            // txtLastname
            // 
            txtLastname.Location = new Point(730, 69);
            txtLastname.Name = "txtLastname";
            txtLastname.Size = new Size(302, 39);
            txtLastname.TabIndex = 9;
            // 
            // txtFirstname
            // 
            txtFirstname.Location = new Point(217, 69);
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(302, 39);
            txtFirstname.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(602, 72);
            label5.Name = "label5";
            label5.Size = new Size(122, 32);
            label5.TabIndex = 7;
            label5.Text = "Last name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(86, 72);
            label6.Name = "label6";
            label6.Size = new Size(125, 32);
            label6.TabIndex = 6;
            label6.Text = "First name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 249);
            label4.Name = "label4";
            label4.Size = new Size(204, 32);
            label4.TabIndex = 5;
            label4.Text = "Password Confirm";
            // 
            // txtPassCF
            // 
            txtPassCF.Location = new Point(217, 246);
            txtPassCF.Name = "txtPassCF";
            txtPassCF.PasswordChar = '*';
            txtPassCF.Size = new Size(816, 39);
            txtPassCF.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(99, 190);
            label3.Name = "label3";
            label3.Size = new Size(111, 32);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 131);
            label2.Name = "label2";
            label2.Size = new Size(71, 32);
            label2.TabIndex = 2;
            label2.Text = "Email";
            // 
            // txtPass
            // 
            txtPass.Location = new Point(216, 187);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(816, 39);
            txtPass.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(216, 128);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(816, 39);
            txtEmail.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(301, 52);
            label1.Name = "label1";
            label1.Size = new Size(550, 59);
            label1.TabIndex = 7;
            label1.Text = "CREATE A NEW ACCOUNT";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(43, 488);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(195, 46);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1153, 585);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(btnRegister);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private TextBox txtPass;
        private TextBox txtEmail;
        private Label label1;
        private Button btnRegister;
        private TextBox txtLastname;
        private TextBox txtFirstname;
        private Label label5;
        private Label label6;
        private Label label4;
        private TextBox txtPassCF;
    }
}