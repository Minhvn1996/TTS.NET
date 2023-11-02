using ApplicationAPI.ClientAPI;
using FluentValidation.Results;
using NetAPI.Data.Entities;
using NetAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationAPI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string pass = txtPass.Text;

            // Tạo yêu cầu đăng nhập
            LoginRequest loginRequest = new LoginRequest
            {
                Email = email,
                Password = pass
            };

            // Tạo validator
            LoginRequestValidator validator = new LoginRequestValidator();

            // Kiểm tra xem yêu cầu đăng nhập có hợp lệ hay không
            ValidationResult validationResult = validator.Validate(loginRequest);
            if (!validationResult.IsValid)
            {
                string errorMessage = string.Join("\n", validationResult.Errors.Select(x => x.ErrorMessage));
                MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Khởi tạo đối tượng AccountClientAPI
                AccountClientAPI accountClient = new AccountClientAPI();

                // Gọi phương thức GetAccount với yêu cầu đăng nhập
                AccountViewModel account = await accountClient.Login(loginRequest);

                // Xử lý đối tượng tài khoản trả về
                HomeForm frm = new HomeForm(account);
                this.Visible = false;
                frm.ShowDialog();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                // Xử lý khi có lỗi
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Xử lý đối tượng tài khoản trả về
            RegisterForm frm = new RegisterForm();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
