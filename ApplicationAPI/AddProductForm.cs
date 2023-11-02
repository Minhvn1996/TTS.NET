using ApplicationAPI.ClientAPI;
using FluentValidation.Results;
using NetAPI.Data.Entities;
using NetAPI.Models;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ApplicationAPI
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        async Task LoadCategory()
        {
            try
            {
                CategoryClientAPI categoryClient = new CategoryClientAPI();
                List<Category> list = await categoryClient.GetList();

                cmbCategory.DataSource = list;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void AddProductForm_Load(object sender, EventArgs e)
        {
            await LoadCategory();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            int categoryId;

            if (cmbCategory.SelectedItem != null && int.TryParse(cmbCategory.SelectedValue!.ToString(), out categoryId))
            {
                if (txtPrice.Text.Length == 0)
                {
                    MessageBox.Show("Price is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string name = txtName.Text;
                string description = txtDescription.Text;
                decimal price = decimal.Parse(txtPrice.Text);

                ProductRequest productRequest = new ProductRequest
                {
                    CategoryId = categoryId,
                    Name = name,
                    Description = description,
                    Price = price
                };
                // Tạo validator
                ProductRequestValidator validator = new ProductRequestValidator();

                // Kiểm tra xem yêu cầu đăng nhập có hợp lệ hay không
                ValidationResult validationResult = validator.Validate(productRequest);
                if (!validationResult.IsValid)
                {
                    string errorMessage = string.Join("\n", validationResult.Errors.Select(x => x.ErrorMessage));
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    ProductClientAPI productClient = new ProductClientAPI();

                    ProductViewModel product = await productClient.AddProduct(productRequest);

                    MessageBox.Show("Add product successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Xử lý khi có lỗi
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid category selection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
