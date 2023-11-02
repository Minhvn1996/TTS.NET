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
    public partial class ProductDetailForm : Form
    {
        int _id;
        public ProductDetailForm(int id)
        {
            _id = id;
            InitializeComponent();
        }

        async Task LoadData(int id)
        {
            try
            {
                ProductClientAPI productClient = new ProductClientAPI();
                ProductViewModel product = await productClient.GetById(id);

                txtName.Text = product.Name;
                txtDescription.Text = product.Description;
                txtPrice.Text = product.Price.ToString();
                ckbStatus.Checked = product.Status;
                int categoryIndex = cmbCategory.FindString(product.CategoryName);
                cmbCategory.SelectedIndex = categoryIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private async void ProductDetailForm_Load(object sender, EventArgs e)
        {
            await LoadCategory();
            await LoadData(_id);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
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
                bool status = ckbStatus.Checked;

                ProductRequest productRequest = new ProductRequest
                {
                    CategoryId = categoryId,
                    Name = name,
                    Description = description,
                    Price = price,
                    Status = status
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

                    Product product = await productClient.UpdateProduct(_id, productRequest);

                    MessageBox.Show("Update product successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ProductClientAPI productClient = new ProductClientAPI();
                Product product = await productClient.Delete(_id);
                MessageBox.Show($"Successfully deleted product: {product.Name}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
