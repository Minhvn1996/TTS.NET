using ApplicationAPI.ClientAPI;
using FluentValidation;
using FluentValidation.Results;
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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string pass = txtPass.Text;
            string passCF = txtPassCF.Text;
            string firstName = txtFirstname.Text;
            string lastName = txtLastname.Text;

            // Tạo yêu cầu đăng ký
            RegisterRequest registerRequest = new RegisterRequest
            {
                Email = email,
                Password = pass,
                PasswordCF = passCF,
                FirstName = firstName,
                LastName = lastName
            };

            // Tạo validator
            RegisterRequestValidator validator = new RegisterRequestValidator();

            // Kiểm tra xem yêu cầu đăng ký có hợp lệ hay không
            ValidationResult validationResult = validator.Validate(registerRequest);
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
                AccountViewModel account = await accountClient.Register(registerRequest);

                MessageBox.Show("Registered successfully, log back in", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                // Xử lý khi có lỗi
                MessageBox.Show("Registration failed, please check again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
